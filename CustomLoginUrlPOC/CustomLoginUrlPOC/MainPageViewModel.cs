using System;
using System.Windows.Input;
using Okta.Xamarin;
using Xamarin.Forms;

namespace CustomLoginUrlPOC
{
    public class MainPageViewModel
    {
        public ICommand LoginCommand { get; set; }

        public MainPageViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private void OnLogin()
        {
            try
            {

                OktaContext.Current.SignInAsync();


                ///This method is not getting triggered if Custom login URL is used for <OktaDomain>
                OktaContext.Current.SignInCompleted += async (sender, args) =>
                {
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
