using System;
using System.Collections.Generic;
using System.Text;

namespace LifeBudget.Data
{
    public interface IToast
    {
        void Show(string message, ToastType type);
    }

    public enum ToastType { Default, Error, Info, Success, Warning};
}
