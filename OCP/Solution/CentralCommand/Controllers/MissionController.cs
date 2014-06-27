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
        public List<List<string>> Map { get; set; }
        public Rover Vehicle { get; set; }
        public Mars Planet { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Staging(MissionViewModel viewModel)
        {
            Planet = new Mars();
            Vehicle = new Rover(Planet);




            //Random rng = new Random(DateTime.Now.Millisecond);
            var initialMap = new List<List<string>>();
            for (int i = 0; i < 50; i++)
            {
                if (i != Vehicle.Location.Y)
                    initialMap.Add(GetGroundRow());   //GetObsticalRow(rng));
                else
                    initialMap.Add(GetRoverRow(Vehicle));
            }

            viewModel.Map = initialMap;

            viewModel.LinkResult = "Just some text about nothin'";

            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult UpdateObstacles(List<string> locations)
        {
            //locations are capable of having duplicates
            var distinctLocations = (from location in locations 
                       select location).Distinct().ToList<string>();




            return Json(new MissionResponseViewModel { Success = true, LocationUpdates = distinctLocations });
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

        private List<String> GetObsticalRow(Random rng)
        {
            var result = GetGroundRow();

            result[rng.Next(0, 50)] = "Obstical.png";

            return result;
        }

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
