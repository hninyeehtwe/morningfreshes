using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MondayAlert.Views.ViewModel
{
    public class SupriseQuestion
    {
        public int SupriseID { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string Answer { get; set; }
        public string Image { get; set; }
    }
}