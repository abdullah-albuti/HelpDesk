using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.NetworkInformation;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Firebase.Auth;

namespace HelpDesk
    
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDml1S_162VPXUEh8K1WFA_lkZN1_mwALE";

        public LoginPage()
        {
            InitializeComponent();
            imglogin.Source = ImageSource.FromFile("helpdesk.png");

           
            login.Text = Lang.Resource.login;
            reg.Text = Lang.Resource.reg;
            emails.Placeholder = Lang.Resource.emails;
            Password.Placeholder = Lang.Resource.Password;

        }
   
    

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        async void login_Clicked(object sender, EventArgs e)

        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
               var auth = await authProvider.SignInWithEmailAndPasswordAsync(emails.Text, Password.Text);

             
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);

              var displayName =  content.User.DisplayName;
              var email = content.User.Email;
              var photoUrl = content.User.PhotoUrl;

                await Navigation.PushAsync(new scenndpage(displayName, email, photoUrl));
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
        }



        void InsertInfo(string userPar, string passPar)
        {
          
        }

        private void reg_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new SignUpPage());

        }
    }

}