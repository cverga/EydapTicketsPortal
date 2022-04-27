using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Models
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Area { get; set; }

        public bool Selected { get; set; }

        public MenuItem()
        {
            // NOOP
        }

        public MenuItem(string name, string text, string action, string controller)
            :this(name, text, action, controller, "", false)
        {
            // NOOP
        }

        public MenuItem(string name, string text, string action, string controller, bool selected)
            :this(name, text, action, controller, "", selected)
        {
            // NOOP
        }

        public MenuItem(string name, string text, string action, string controller, string area)
            :this(name, text, action, controller, area, false)
        {
            // NOOP
        }

        public MenuItem(string name, string text, string action, string controller, string area, bool selected)
        {
            Name = name;
            Text = text;
            Action = action;
            Controller = controller;
            Area = area;
            Selected = selected;
        }
    }
}
