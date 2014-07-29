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
        public List<List<string>> Map 
        { 
            get 
            {
                if (Session["Map"] == null)
                    Session["Map"] = new List<List<string>>();

                return (List<List<string>>)Session["Map"];
            } 
            set {
                Session["Map"] = value;
            } 
        }
        private Rover Vehicle
        {
            get
            {
                if (Session["Rover"] == null)
                    Session["Rover"] = new Rover(Planet);

                return (Rover)Session["Rover"];
            }
            set
            {
                Session["Rover"] = value;
            }
        }
        private Mars Planet
        {
            get
            {
                if (Session["Mars"] == null)
                    Session["Mars"] = new Mars();

                return (Mars)Session["Mars"];
            }
            set
            {
                Session["Mars"] = value;
            }
        }
        public MissionManager MissionManager
        {
            get
            {
                if (Session["MissionManager"] == null)
                    Session["MissionManager"] = new MissionManager(Vehicle);

                return (MissionManager)Session["MissionManager"];
            }
            set
            {
                Session["Rover"] = value;
            }
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Staging(MissionViewModel viewModel)
        {
            //Planet = new Mars();
            //Vehicle = new Rover(Planet);

            //Because MissionManager is not the single point of entry we have to make this call to ensure everything is 
            //instantiated before we begin.
            var foo = MissionManager;

            //NOTE: This map is only used to draw the initial map on the view. Afterwards all updates rely on the 
            //MissionManager and Mars objects (Refactor option: access to Mars should really be through MissionManager)
            var initialMap = new List<List<string>>();
            for (int i = 0; i < 50; i++)
            {
                if (i != Vehicle.Location.Y)
                    initialMap.Add(GetGroundRow());   
                else
                    initialMap.Add(GetRoverRow(Vehicle));
            }

            Map = initialMap;
            
            viewModel.Map = initialMap;

            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult UpdateObstacles(List<string> locations)
        {
            if(locations == null)
                return Json(new MissionResponseViewModel { Success = false, Obstacles = new List<ObstacleViewModel>() });

            var distinctLocations = (from location in locations 
                       select location).Distinct().ToList<string>();

            //REFACTOR: Move this logic into MissionManager
            foreach(var input in distinctLocations)
            {
                Obstacle obstacle = CreateObstacle(input);
                Planet.AddObstacle(obstacle);
            }

            var results = Planet.Obstacles.Select(x =>
                new ObstacleViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = x.GetType() == typeof(Rock) ? "rock.png" : "crater.jpg"
                }).ToList();

            return Json(new MissionResponseViewModel { Success = true, Obstacles = results });
        }

        //REFACTOR: Move this logic into MissionManager
        private static Obstacle CreateObstacle(string input)
        {
            var coordinates = input.Split('_');
            Point location = new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            return new Rock(location);
        }


        [HttpPost]
        public JsonResult SendCommands(List<string> commands)
        {
            var originalPosition = Vehicle.Location.X + "_" + Vehicle.Location.Y;

            var commandString = String.Join(",", commands);
            MissionManager.AcceptCommands(commandString);
            MissionManager.ExecuteMission();

            var roverNewPosition = Vehicle.Location.X + "_" + Vehicle.Location.Y;
            var roverFacing = GetFacingAsString(Vehicle.Facing);

            return Json(new MissionResponseViewModel {  Success = true, 
                                                        RoverLocation = roverNewPosition,
                                                        PreviousRoverLocation = originalPosition,
                                                        RoverFacing = roverFacing
                                                     });
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

        #region Fake Data

        private List<string> GetGroundRow()
        {
            var result = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                result.Add("Ground.png");
            }

            return result;
        }

        //private List<String> GetObstacleRow(Random rng)
        //{
        //    var result = GetGroundRow();

        //    result[rng.Next(0, 50)] = "rock.png";

        //    return result;
        //}

        private List<String> GetRoverRow(Rover vehicle)//Random rng)
        {
            var result = GetGroundRow();

            int centerIndex = vehicle.Location.X;//25;
            result[centerIndex] = "Rover.png";

            return result;
        }

        #endregion
    }
}
