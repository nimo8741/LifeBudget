using Xamarin.Forms;
using LifeBudget.Droid.Data;
using LifeBudget.Data;
using PolishedToast_Xamarin;

[assembly: Dependency(typeof(Toast_Android))]
namespace LifeBudget.Droid.Data
{
    public class Toast_Android : IToast
    {
        public void Show(string Message, ToastType type)
        {
            switch (type)
            {
                case ToastType.Default:
                    PolishedToast.Create(Android.App.Application.Context, Message).Show();
                    break;
                case ToastType.Error:
                    PolishedToast.Error(Android.App.Application.Context, Message).Show();
                    break;
                case ToastType.Info:
                    PolishedToast.Info(Android.App.Application.Context, Message).Show();
                    break;
                case ToastType.Success:
                    PolishedToast.Success(Android.App.Application.Context, Message).Show();
                    break;
                case ToastType.Warning:
                    PolishedToast.Warning(Android.App.Application.Context, Message).Show();
                    break;
            }
        }
    }

}