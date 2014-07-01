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
                if (ViewData["Map"] == null)
                    ViewData["Map"] = new List<List<string>>();

                return (List<List<string>>)ViewData["Map"];
            } 
            set {
                ViewData["Map"] = value;
            } 
        }
        public Rover Vehicle
        {
            get
            {
                if (ViewData["Rover"] == null)
                    ViewData["Rover"] = new Rover(Planet);

                return (Rover)ViewData["Rover"];
            }
            set
            {
                ViewData["Rover"] = value;
            }
        }
        public Mars Planet
        {
            get
            {
                if (ViewData["Mars"] == null)
                    ViewData["Mars"] = new Mars();

                return (Mars)ViewData["Mars"];
            }
            set
            {
                ViewData["Mars"] = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Staging(MissionViewModel viewModel)
        {
            Planet = new Mars();
            Vehicle = new Rover(Planet);

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
            var distinctLocations = (from location in locations 
                       select location).Distinct().ToList<string>();

            return Json(new MissionResponseViewModel { Success = true, LocationUpdates = distinctLocations });
        }

        [HttpPost]
        public JsonResult SendCommands(List<string> commands)
        {
            var rovers_new_position = "";

            return Json(new MissionResponseViewModel { Success = true, LocationUpdates = new List<string>() { rovers_new_position }});
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

        //    result[rng.Next(0, 50)] = "Obstacle.png";

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
