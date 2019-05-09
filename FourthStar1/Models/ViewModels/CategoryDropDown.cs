using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace FourthStar1.Models.ViewModels
{
    public class CategoryDropDown

    {
        public List<Drill> Drills { get; set; }
        public SelectList Categories { get; set; }
        public string DrillCategory { get; set; }
        public string SearchString { get; set; }
    }
}