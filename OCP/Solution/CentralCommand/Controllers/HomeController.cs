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

            //This will be replaced by the Rover code control
            Random rng = new Random(DateTime.Now.Millisecond);
            var map = new List<List<string>>();
            for (int i = 0; i < 50; i++)
            {
                if (i != 24)
                    map.Add(GetObstacleRow(rng));
                else
                    map.Add(GetRoverRow(rng));
            }

            viewModel.Map = map;

            return View(viewModel);
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

        private List<String> GetObstacleRow(Random rng)
        {
            var result = GetGroundRow();

            result[rng.Next(0, 50)] = "rock.png";

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
