using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralCommand.Models
{
    public class MissionResponseViewModel
    {
        public bool Success { get; set; }
        public List<string> LocationUpdates { get; set; }
    }
}