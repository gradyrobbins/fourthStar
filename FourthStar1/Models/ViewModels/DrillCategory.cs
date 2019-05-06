using Microsoft.AspNetCore.Mvc.Rendering;
using FourthStar1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourthStar1.Models.ViewModels
{
    public class DrillCategory
    {
        public Drill Drill { get; set; }
        public List<SelectListItem> CategoryOptions { get; set; }

    }
}
