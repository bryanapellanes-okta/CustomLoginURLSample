
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Okta.Xamarin.Android;

namespace CustomLoginUrlPOC.Droid
{
    [Activity(Label = "LoginCallbackInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleInstance)]
    [
    IntentFilter
    (
        actions: new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataSchemes = new[] { "my.app.login" },
        DataPath = "/callback"
    )
]
    public class LoginCallbackInterceptorActivity : OktaLoginCallbackInterceptorActivity<MainActivity>
    {
        
    }
}
