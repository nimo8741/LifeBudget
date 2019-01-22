using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using LifeBudget.Models;

namespace LifeBudget.Views.DetailViews.CustomRenders
{
    public class MenuPageStack : StackLayout
    {
        public MenuPageStack() { }
        public Type TargetType { get; set; }

    }
}
