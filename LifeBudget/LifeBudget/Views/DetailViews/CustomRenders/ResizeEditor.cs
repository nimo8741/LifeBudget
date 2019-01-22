using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LifeBudget.Views.DetailViews.CustomRenders
{
    class ResizeEditor : Editor
    {
        public ResizeEditor()
        {
            this.TextChanged += (sender, e) =>
            {
                this.InvalidateMeasure();
            };
        }
    }
}
