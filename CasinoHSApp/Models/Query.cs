using System;
using System.Collections.Generic;
using System.Text;

namespace CasinoHSApp.Models
{
    public class Query
    {
        public SearchPicker SearchCriteria { get; set; }
        public TeamPicker TeamPicker { get; set; }
        public string Input { get; set; }

    }
}
