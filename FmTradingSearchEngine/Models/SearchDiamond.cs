using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FmTradingSearchEngine.Models
{

	public class SearchDiamond
    { 
        public List<string> Grading_Report { get; set; }
        public List<string> Shapes { get; set; }
        public List<string> Weight { get; set; } 
		public List<string> Color { get; set; }
		public List<string> Clarity { get; set; }
        public List<string> Cut { get; set; }
		public List<string>  Polish { get; set; }
		public List<string> Symmetry { get; set; }
		public List<string> Fluorescence { get; set; }
    }
}