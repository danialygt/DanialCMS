using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Models.Home
{
    public class ViewersStatisticsViewModel
    {
        public int TodayViews { get; set; }
        public int MonthViews { get; set; }
        public int AllViews { get; set; }
    }
}
