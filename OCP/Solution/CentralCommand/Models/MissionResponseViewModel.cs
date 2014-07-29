using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCommand.Models
{
    public class MissionResponseViewModel
    {
        public bool Success { get; set; }
        public string RoverLocation { get; set; }
        public List<ObstacleViewModel> Obstacles { get; set; }
        public string PreviousRoverLocation { get; set; }
        public string RoverFacing { get; set; }
    }
}