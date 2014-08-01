using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentralCommand.Models;
using MarsRoverKata;

namespace CentralCommand.Controllers
{
    public class MissionController : Controller
    {
        private Rover Vehicle
        {
            get
            {
                return MissionManager.Rover;
            }
        }
        private Mars Planet
        {
            get
            {
                return MissionManager.Planet;
            }
        }
        public MissionManager MissionManager
        {
            get
            {
                if (Session["MissionManager"] == null)
                    Session["MissionManager"] = new MissionManager(new Rover(new Mars()));

                return (MissionManager)Session["MissionManager"];
            }
            set
            {
                Session["MissionManager"] = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Staging(MissionViewModel viewModel)
        {
            var initialMap = new List<List<string>>();
            for (int i = 0; i < 50; i++)
            {
                if (i != Vehicle.Location.Y)
                    initialMap.Add(GetGroundRow());   
                else
                    initialMap.Add(GetRoverRow(Vehicle));
            }
            
            viewModel.Map = initialMap;

            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult UpdateObstacles(List<string> locations)
        {
            if(locations == null)
                return Json(new MissionResponseViewModel { Success = false, Obstacles = new List<MapPositionViewModel>() });

            var distinctLocations = (from location in locations 
                       select location).Distinct().ToList<string>();

            foreach(var input in distinctLocations)
            {
                Obstacle obstacle = CreateObstacle(input);
                Planet.AddObstacle(obstacle);
            }

            var updatedObstacles = ConvertToViewModels(Planet.Obstacles);

            return Json(new MissionResponseViewModel { Success = true, Obstacles = updatedObstacles });
        }

        private static Obstacle CreateObstacle(string input)
        {
            var coordinates = input.Split('_');
            Point location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            return new Obstacle(location, true);
        }

        [HttpPost]
        public JsonResult SendCommands(List<string> commands)
        {
            var oldCollection = Planet.Obstacles.ToList();
            var originalPosition = Vehicle.Location.X + "_" + Vehicle.Location.Y;
            var commandString = String.Join(",", commands);

            MissionManager.AcceptCommands(commandString);
            MissionManager.ExecuteMission();

            var newCollection = Planet.Obstacles.ToList();

            var updatedObstacles = ConvertToViewModels(Planet.Obstacles);
            var removedObstacles = oldCollection.Except(newCollection).Select(x =>
                new MapPositionViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = "Ground.png"
                }).ToList();

            var rovers_new_position = Vehicle.Location.X + "_" + Vehicle.Location.Y;
            var roverNewPosition = Vehicle.Location.X + "_" + Vehicle.Location.Y;
            var roverFacing = GetFacingAsString(Vehicle.Facing);

            return Json(new MissionResponseViewModel {  Success = true, 
                                                        RoverLocation = roverNewPosition,
                                                        PreviousRoverLocation = originalPosition,
                                                        RoverFacing = roverFacing,
                                                        Obstacles = updatedObstacles,
                                                        RemovedObstacles = removedObstacles
                                                     });
        }

        private List<MapPositionViewModel> ConvertToViewModels(IReadOnlyList<Obstacle> obstacles)
        {
            return obstacles.Select(x =>
                new MapPositionViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = !x.IsDestructable ? "crater.jpg" : "rock.png"
                }).ToList();
        }

        private string GetFacingAsString(Direction roverFacing)
        {
            switch (roverFacing)
            { 
                case Direction.North:
                    return "N";
                case Direction.East:
                    return "E";
                case Direction.South:
                    return "S";
                case Direction.West:
                    return "W";
            }

            return "N";
        }

        private List<string> GetGroundRow()
        {
            var result = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                result.Add("Ground.png");
            }

            return result;
        }

        private List<String> GetRoverRow(Rover vehicle)
        {
            var result = GetGroundRow();

            int centerIndex = vehicle.Location.X;
            result[centerIndex] = "Rover.png";

            return result;
        }
    }
}
