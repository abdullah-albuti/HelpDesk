using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpDesk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInsertData : ContentPage
    {

        public PageInsertData()
        {
            InitializeComponent();
        }
        FirebaseClient firebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");


        string displayName;
        string email;
        string photoUrl;

        public PageInsertData(string displayName, string email, string photoUrl)
        {
            InitializeComponent();
            this.displayName = displayName;
            this.email = email;
            this.photoUrl = photoUrl;

            PhotoEdit.Text = Lang.Resource.imgurl;
            addcontent.Text = Lang.Resource.addcontent;
            Supject.Placeholder = Lang.Resource.Supject;
            Suptitle.Placeholder = Lang.Resource.Suptitle;
            imgurl.Placeholder = Lang.Resource.imgurl;
            SEnd.Text = Lang.Resource.SEnd;
            Back.Text = Lang.Resource.Back;
            // Suptitle.Text = "yourName: " + displayName + "\n Your Email: " + email + "\n your avatar: " + photoUrl;


            //.AsObservable<DataShearing>()
            //.Subscribe((dbevent) =>
            //{
            //    if (dbevent.Object != null)
            //    {
            //        DatabaseItems.Add(dbevent.Object);
            //    }
            //});


        }
        private void SEnd_Clicked(object sender, EventArgs e)
        {
            //Random generator = new Random();

            //int randomumber = generator.Next(100, 99999);

            //var res = randomumber.ToString();
            //res = res + res+999/2;

            if (imgurl.Text == null)
            {
                imgurl.Text = "https://st4.depositphotos.com/14953852/24787/v/600/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
            }


            var Result = firebaseClient
                .Child("Chat")
                .PostAsync(new DataShearing() { UserName = displayName, Email = email, Subtitle = Suptitle.Text, Subject = Supject.Text, imgproplme = imgurl.Text, NewsDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), IDSubtitle = "", IsSolved = "" });
            DisplayAlert("alert", "done", "ok");
            Navigation.PushAsync(new scenndpage(displayName, email, photoUrl));
        }

        private void Back_Clicked(object sender, EventArgs e)
        {

            //    DisplayAlert("alert", res, "ok");
            Navigation.PushAsync(new scenndpage(displayName, email, photoUrl));

        }

        async void Button_Clicked(object sender, EventArgs e)
        {

          


            var result = await  MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pickaphoto"
            });
            var stream = await result.OpenReadAsync();
            string localPath = result.FullPath;
            imgurl.Text = localPath;
            // ccc.Source = ImageSource.FromStream(() => stream);
            //  string localFilename = result.FileName;
            // await DisplayAlert("Alert", localPath, "OK");





        } 

    }
}