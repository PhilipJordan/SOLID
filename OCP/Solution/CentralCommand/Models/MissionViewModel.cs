using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarsRoverKata;

namespace CentralCommand.Models
{
    public class MissionViewModel
    {
        public string LinkResult { get; set; }
        public List<List<string>> Map { get; set; }


        public ICollection<Point> NewObsticles { get; set; }
    }
}