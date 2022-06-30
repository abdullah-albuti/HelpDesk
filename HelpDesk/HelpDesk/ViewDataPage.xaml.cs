using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpDesk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDataPage : ContentPage
    {

        public ObservableCollection<DataShearing> DatabaseItems { get; set; } = new ObservableCollection<DataShearing>();

        FirebaseClient firebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public ObservableCollection<MyDatabaseRecord> DatabaseItemsx { get; set; } = new
        ObservableCollection<MyDatabaseRecord>();
                                                                           

        string displayName;
        string email;
        string photoUrl;
        String Title;
        string subjects;
        string idsubjects;
        string subTIME;
        string nameuser;
        string selved;
        ClassCommentes firebaseComenses = new ClassCommentes();
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allComens = firebaseComenses.GetAllComens(idsubjects);


            xlisty.ItemsSource = await allComens;


            var last = xlisty.ItemsSource.Cast<object>().LastOrDefault();
            xlisty.ScrollTo(last, ScrollToPosition.MakeVisible, true);







        }

        public ViewDataPage(string displayName, string email,string subjects,string photoUrl, string Title , string idsubjects,string subTIME  ,  string nameuser , string selved)
        {
            InitializeComponent();


            this.email = email;
            this.subjects = subjects;
            this.photoUrl = photoUrl;
            this.Title = Title;


            this.nameuser = nameuser;
            this.displayName = displayName;
            this.subTIME = subTIME;
            this.idsubjects = idsubjects;
            this.selved = selved;
            editsubjlab.IsVisible = false;
            editUserTitle.IsVisible = false;
            savedid.IsVisible = false;
            cnacleid.IsVisible = false;
            editid.IsVisible = false;
            PhotoEdit.IsVisible = false;


            //    UserName.Text = "Name: " + displayName + "\nEmail: " + email ;
            //  UserName.Text = "Name: " + displayName;
            UserTitle.Text = displayName + ": " +Title;
            subjlab.Text = subjects;

            editUserTitle.Text = Title ;
            editsubjlab.Text = subjects;


            PhotoEdit.Text = Lang.Resource.imgurl;
            savedid.Text = Lang.Resource.savedid;
            cnacleid.Text = Lang.Resource.cnacleid;
            editid.Text = Lang.Resource.editid;
             LCx.Text = Lang.Resource.LCx;
            commentuser.Placeholder = Lang.Resource.commentuser;
            SB.Text = Lang.Resource.SB;
            BB.Text = Lang.Resource.Back;
            if (photoUrl != null)
            {
                avatar.Source = photoUrl;
            }
            else
            {
                avatar.Source = "https://st4.depositphotos.com/14953852/24787/v/600/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
            }

            
            if (nameuser == displayName)
            {
                editid.IsVisible = true;
                LCx.IsVisible = true;
                LC.IsVisible = true;
                if (selved == "IsSolved")
                {
                    LC.IsToggled = true;

                }


            }
            else
            {
                LC.IsVisible = false;
                LCx.IsVisible = false;
                editsubjlab.IsVisible = false;
                editUserTitle.IsVisible = false;
                savedid.IsVisible = false;
                cnacleid.IsVisible = false;
                editid.IsVisible = false;
                PhotoEdit.IsVisible = false;


            }












            //res.Text = displayName + email + photoUrl  + Title ;

        }




        private async void SEnd_Clicked(object sender, EventArgs e)
        {

            //   idcoment = auto incerment ?

            //Console.Write("click");
            //firebaseClient.Child("Comeents").AsObservable<MyDatabaseRecord>().Subscribe((dbevent) =>
            //{
            //    Console.Write(dbevent.Object.COmment + "befor");

            //    if (dbevent.Object != null)
            //    {
            //        Console.Write(dbevent.Object.COmment + "after");
            //        DatabaseItemsx.Add(dbevent.Object);
            //    }

            //});


            var Result = firebaseClient
                .Child("Comeents")
                .PostAsync(new MyDatabaseRecord() { nameUsercoment = nameuser, idsubtitle = idsubjects, COmment = commentuser.Text, Datecoment = DateTime.Now.ToString("G") });
            commentuser.Text = "";
            var allComens = firebaseComenses.GetAllComens(idsubjects);


            xlisty.ItemsSource = await allComens;


            var last = xlisty.ItemsSource.Cast<object>().LastOrDefault();
            xlisty.ScrollTo(last, ScrollToPosition.MakeVisible, true);



            xlisty.ItemsSource = await allComens;
            xlisty.ScrollTo(last, ScrollToPosition.MakeVisible, true);









        }



        private void saved_Clicked(object sender, EventArgs e)
        {
            if (photoUrl == null)
            {
                photoUrl = "https://st4.depositphotos.com/14953852/24787/v/600/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
            }

            editUserTitle.IsVisible = false;
            UserTitle.IsVisible = true;

            editsubjlab.IsVisible = false;
            subjlab.IsVisible = true;
           


            editid.IsVisible = true;
            savedid.IsVisible = false;
            cnacleid.IsVisible = false;
            PhotoEdit.IsVisible = false;

            firebaseClient
          .Child("Chat")
           .Child(idsubjects)
             .PutAsync(new DataShearing() { UserName = displayName, Email = email, Subject = editsubjlab.Text, imgproplme = photoUrl, Subtitle = editUserTitle.Text, IDSubtitle = idsubjects, NewsDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") , IsSolved = selved });



            UserTitle.Text = displayName + ": " + editUserTitle.Text;
            subjlab.Text = editsubjlab.Text;






        }
        private void cancel_Clicked(object sender, EventArgs e)
        {



            UserTitle.IsVisible = true;
            editsubjlab.IsVisible = false;
            subjlab.IsVisible = true;
            editUserTitle.IsVisible = false;


            editid.IsVisible = true;
            savedid.IsVisible = false;
            cnacleid.IsVisible = false;
            PhotoEdit.IsVisible = false;









        }
        private void edit_Clicked(object sender, EventArgs e)
        {



            UserTitle.IsVisible = false;
            editsubjlab.IsVisible = true;
            subjlab.IsVisible = false;
            editUserTitle.IsVisible = true;


            editid.IsVisible = false;
            savedid.IsVisible = true;
            cnacleid.IsVisible = true;
            PhotoEdit.IsVisible = true;










        }








        private void Back_Clicked(object sender, EventArgs e)
        {

            //    DisplayAlert("alert", res, "ok");
             Navigation.PopAsync();




        }

        private void LC_Toggled(object sender, ToggledEventArgs e)
        {

            if (LC.IsToggled == false)
            {
                firebaseClient
                .Child("Chat")
                 .Child(idsubjects)
                   .PutAsync(new DataShearing() { UserName = displayName, Email = email, Subject = subjects, imgproplme = photoUrl, Subtitle = Title, IDSubtitle = idsubjects, NewsDateTime = subTIME, IsSolved = "" });


            }

            if (LC.IsToggled == true)
            {
                firebaseClient
            .Child("Chat")
            .Child(idsubjects)
            .PutAsync(new DataShearing() { UserName = displayName, Email = email, Subject = subjects, imgproplme = photoUrl, Subtitle = Title, IDSubtitle = idsubjects, NewsDateTime = subTIME, IsSolved = "IsSolved" });
            }
        }

        private void xlisty_ItemTapped(object sender, ItemTappedEventArgs e)
        {






            ListView lv = (ListView)sender;
            MyDatabaseRecord club = (MyDatabaseRecord)lv.SelectedItem;




            if (e.Item != null)
            {

                CrossShare.Current.Share(new ShareMessage
                {

                    Text = club.COmment
                });

            }







         

        }

        async void Button2_Clicked(object sender, EventArgs e)
        {
            


                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please pickaphoto"
                });
                var stream = await result.OpenReadAsync();
                string localPath = result.FullPath;
                avatar.Source = localPath;
                photoUrl = localPath;
                // ccc.Source = ImageSource.FromStream(() => stream);
                //  string localFilename = result.FileName;
                // await DisplayAlert("Alert", localPath, "OK");







        }
    }
}