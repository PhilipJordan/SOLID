using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATDD_and_MVC.Models;

namespace ATDD_and_MVC.Controllers
{
    public class MissionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Staging(BasicViewModel viewModel)
        {
            Random rng = new Random(DateTime.Now.Millisecond);
            var map = new List<List<string>>();
            for (int i = 0; i < 50; i++)
            {
                if (i != 24)
                    map.Add(GetObsticalRow(rng));
                else
                    map.Add(GetRoverRow(rng));
            }

            viewModel.Map = map;

            viewModel.LinkResult = "Just some text about nothin'";

            return PartialView(viewModel);
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

        private List<String> GetRoverRow(Random rng)
        {
            var result = GetGroundRow();

            int centerIndex = 24;
            result[centerIndex] = "Rover.png";

            return result;
        }

        #endregion
    }
}
