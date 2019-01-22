using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LifeBudget.Models
{
    class RootMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color Background { get; set; }
        public List<MasterMenuItem> PageList;     

        public RootMenuItem(string Title, string iconSource, Color color, List<PageType>TargetPages)
        {
            this.Title = Title;
            IconSource = iconSource;
            Background = color;
            PageList = new List<MasterMenuItem>();
            foreach (var target in TargetPages)
            {
                PageList.Add(new MasterMenuItem(target.Title, color, target.TargetType));
            }
        }
    }
}
