using System;
using System.Windows.Input;
using Okta.Xamarin;
using Xamarin.Forms;

namespace CustomLoginUrlPOC
{
    public class MainPageViewModel
    {
        public ICommand LoginCommand { get; set; }

        public MainPageViewModel(MainPage mainPage)
        {
            LoginCommand = new Command(OnLogin);
            Page = mainPage;
        }

        public MainPage Page { get; set; }

        private void OnLogin()
        {
            try
            {
                Page.DisplayAlert("Demo", "Starting Sign-in", "OK");

                OktaContext.Current.SignInAsync();


                ///This method is not getting triggered if Custom login URL is used for <OktaDomain>
                OktaContext.Current.SignInCompleted += async (sender, args) =>
                {
                    await Page.DisplayAlert("Demo", "SignInCompleted event fired", "OK");
                    SignInEventArgs signInEventArgs = (SignInEventArgs)args;
                    IOktaStateManager oktaStateManager = signInEventArgs.StateManager;
                };
            }
            catch (Exception ex)
            {
            }
        }
    }
}
