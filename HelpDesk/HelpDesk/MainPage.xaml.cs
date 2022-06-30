using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelpDesk
{
    public partial class MainPage : ContentPage
    {

        FirebaseClient firebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public MainPage()
        {
            InitializeComponent();


        }

         void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            firebaseClient.Child("Records").PostAsync(new DataShearing
            {
               // username = recordData.Text
            });

            recordData.Text = "";
        }

         void Button_Clicked_1(object sender, EventArgs e)
        {
      
           Navigation.PushAsync(new scenndpage());
        }
    }
}