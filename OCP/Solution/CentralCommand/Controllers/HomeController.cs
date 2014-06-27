using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentralCommand.Models;

namespace CentralCommand.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index(MissionViewModel viewModel)
        {
            

            //if (viewModel != null)
            //    return View(viewModel);

            //var imageRow = new List<string>() { "Ground.png", "Rover.png", "Obstical.png" };

            //2 dimentional array of strings
            //var grid = new List<List<string>>() { 
            //    imageRow,
            //    imageRow,
            //    imageRow
            //};

            //This will be replaced by the Rover code control
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
            //foreach(var row in grid)
            //{
            //    foreach(var column in row)
            //    {
                    
            //    }
            //}
           


            

            viewModel.LinkResult = "Just some text about nothin'";

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DoAction(MissionViewModel viewModel)
        {
            if(viewModel != null)
                viewModel.LinkResult = "Link clicked";
            return Index(viewModel);
        }


        private List<string> GetGroundRow()
        { 
            var result = new List<string>();

            for(int i=0;i<50;i++)
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

    }
}
