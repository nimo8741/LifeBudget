using System;
using System.Collections.Generic;
using System.Text;

namespace LifeBudget.Models
{
    public class PageType
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }

        public PageType (string title, Type target)
        {
            this.Title = title;
            this.TargetType = target;
        }

    }
}
