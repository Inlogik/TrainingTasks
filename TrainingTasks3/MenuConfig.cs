using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingTasks3
{
    public class MenuConfig
    {
        public List<MenuItem> StaticMenuItems { get; set; }
        public Func<MenuContext, IEnumerable<MenuItem>> DynamicMenuItemsFunc { get; set; }
        public Func<MenuContext, MenuItem, bool> IsVisibleFunc { get; set; }
    }
}