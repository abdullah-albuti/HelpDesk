using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace HelpDesk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDml1S_162VPXUEh8K1WFA_lkZN1_mwALE";
        public string FileBasesTokin = "https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/";
        public SignUpPage()
        {
            InitializeComponent();
            RegPage.Text = Lang.Resource.RegPage;
            UserName.Placeholder = Lang.Resource.UserName;
            email.Placeholder = Lang.Resource.emails;
            Passwords.Placeholder = Lang.Resource.Password;
            PasswordsConffert.Placeholder = Lang.Resource.PasswordsConffert;
            regis.Text = Lang.Resource.regis;
            Back.Text = Lang.Resource.Back;
        }

        async void signupbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (email.Text != null && Passwords.Text == PasswordsConffert.Text && UserName.Text != null )
                {
                    if (Passwords.Text.Length == 8)
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));

                        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email.Text, Passwords.Text, UserName.Text, false, null);
                        string gettoken = auth.FirebaseToken;
                        //await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
                        await Navigation.PushAsync(new LoginPage());


                    }
                    else
                    {

                        await App.Current.MainPage.DisplayAlert("Alert", "PASSWORD is not long 8 or up", "OK");

                    }

           
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Alert","PASSWORD OR EMAIL IS FAIL", "OK");

                }
                

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

        }

        private void Back_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new LoginPage());

        }
    }
}