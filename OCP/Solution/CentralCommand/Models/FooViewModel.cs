using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentralCommand.Models
{
    public class FooViewModel
    {
        [Required]
        [DisplayName("Foo Value")]
        [Range(3, 9, ErrorMessage = "Foo must be between 3 and 9. Why? I dunno I was just told to do it.")]
        public int FooInt { get; set; }

    }
}