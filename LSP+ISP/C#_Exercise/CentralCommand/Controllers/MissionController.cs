using CentralCommand.Models;
using MarsRoverKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CentralCommand.Controllers
{
    public class MissionController : Controller
    {
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
            var initialMap = new List<List<string>>();
            for (int i = 0; i < MissionManager.Planet.Bounds.Height; i++)
            {
                if (i != MissionManager.Rover.Location.Y)
                    initialMap.Add(GetGroundRow());
                else
                    initialMap.Add(GetRoverRow(MissionManager.Rover));
            }

            var viewModel = new MissionViewModel
            {
                Map = initialMap
            };
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Reset()
        {
            MissionManager = null;
            return Redirect("/index.html");
        }

        [HttpPost]
        public JsonResult UpdateObstacles(List<ObstacleViewModel> inputs)
        {
            if (inputs == null)
                return Json(new MissionResponseViewModel { Success = false, Obstacles = new List<MapPositionViewModel>() });

            var distinctLocations = inputs.GroupBy(o => o.Coordinates).Select(g => g.Last()).Distinct();

            foreach (var input in distinctLocations)
            {
                var coordinates = input.Coordinates.Split('_');
                MissionManager.AddObstacle(int.Parse(coordinates[0]), int.Parse(coordinates[1]), input.Type);
            }

            var updatedObstacles = ConvertToViewModels(MissionManager.Planet.Obstacles);

            return Json(new MissionResponseViewModel { Success = true, Obstacles = updatedObstacles });
        }

        [HttpPost]
        public JsonResult SendCommands(List<string> commands)
        {
            if (commands == null)
            {
                return Json(new MissionResponseViewModel {Success = false});
            }
            var oldCollection = MissionManager.Planet.Obstacles.ToList();
            var removedObstacles = oldCollection.OfType<Alien>().Select(x =>
                new MapPositionViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = "Ground.png"
                }).ToList();
            var originalPosition = MissionManager.Rover.Location.X + "_" + MissionManager.Rover.Location.Y;
            var commandString = String.Join(",", commands);

            MissionManager.AcceptCommands(commandString);
            MissionManager.ExecuteMission();

            var newCollection = MissionManager.Planet.Obstacles.ToList();

            var updatedObstacles = ConvertToViewModels(MissionManager.Planet.Obstacles);
            removedObstacles.AddRange(oldCollection.Except(newCollection).Select(x =>
                new MapPositionViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = "Ground.png"
                }).ToList());

            var roverNewPosition = MissionManager.Rover.Location.X + "_" + MissionManager.Rover.Location.Y;
            var roverFacing = GetFacingAsString(MissionManager.Rover.Facing);

            return Json(new MissionResponseViewModel {  Success = true, 
                                                        RoverLocation = roverNewPosition,
                                                        PreviousRoverLocation = originalPosition,
                                                        RoverFacing = roverFacing,
                                                        Obstacles = updatedObstacles,
                                                        RemovedObstacles = removedObstacles
                                                     });
        }

        private List<MapPositionViewModel> ConvertToViewModels(IEnumerable<IObstacle> obstacles)
        {
            return obstacles.Select(x =>
                new MapPositionViewModel
                {
                    Location = x.Location.X + "_" + x.Location.Y,
                    Image = x.GetType().Name + ".png"
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

            for (int i = 0; i < MissionManager.Planet.Bounds.Width; i++)
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

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonDotNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
    }
}
