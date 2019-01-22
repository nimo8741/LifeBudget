using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LifeBudget.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public Color Background { get; set; }
        public Type TargetType { get; set; }


        public MasterMenuItem(string Title, Color color, Type Target)
        {
            this.Title = Title;
            this.Background = color;
            this.TargetType = Target;
        }

    }
}
