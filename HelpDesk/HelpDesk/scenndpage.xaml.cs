using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpDesk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class scenndpage : ContentPage
    {


        public ObservableCollection<DataShearing> DatabaseItems { get; set; } = new ObservableCollection<DataShearing>();


        FirebaseClient firebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");

        String Name;
        String Email;
        String Photour;




        ClassData firebaseHelper = new ClassData();


        protected async override void OnAppearing()

        {


            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAlldata();
            Datagrid.ItemsSource = allPersons;

        


            //    Datagrid_ItemSelected(allPersons ,null);
            // Datagrid.ItemSelected += Datagrid_ItemSelected;

        }

        public scenndpage(String Name, String Email, String Photour)
        {

            InitializeComponent();
            this.Name = Name;
            this.Email = Email;
            this.Photour = Photour;
            BindingContext = this;

            yourname.Text = Lang.Resource.yourname + Name  ;

            Serarhbar1.Placeholder = Lang.Resource.Serarhbar1;
            uploud_b.Text = Lang.Resource.uploud_b;
            logout_b.Text = Lang.Resource.logout_b;




            //    Datagrid.ItemsSource = GetAlldata();



            // var collection = firebaseClient.Child("Chat")
            //.AsObservable<DataShearing>();

            // Datagrid.ItemsSource = collection.AsObservableCollection();


            // var collection = firebaseClient.Child("Chat").AsObservable<DataShearing>().AsObservableCollection();

            //   Datagrid.ItemsSource = collection;






            //  var collection = firebaseClient
            //.Child("Chat")
            //.AsObservable<DataShearing>()
            //.Subscribe((dbevent) =>
            //{
            //    if (dbevent.Object != null)
            //    {



            //        DatabaseItems.Add(X);
            //        listViewEvent.ItemsSource = dbevent.Object.Subtitle;
            //    }
            //});


        }













        public scenndpage()
        {
            InitializeComponent();



        }



        //private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{

        //}

        //private void LoginClicked(object sender, EventArgs e)
        //{

        //}



        //public async void InsertInfo()
        //{




        //}


        private void uploud_Clicked(object sender, EventArgs e)
        {




            Navigation.PushAsync(new PageInsertData(Name, Email, Photour));

        }



        private void Datagrid_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            ListView lv = (ListView)sender;
            DataShearing club = (DataShearing)lv.SelectedItem;
            Serarhbar1.Text = "";
            Navigation.PushAsync(new ViewDataPage(club.UserName, club.Email, club.Subject, club.imgproplme, club.Subtitle, club.IDSubtitle, club.NewsDateTime, Name, club.IsSolved));

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {







            var allPersons = await firebaseHelper.GetAlldata();

            if (Serarhbar1.Text != null)
            {

                Datagrid.ItemsSource = allPersons.Where(c => c.Subtitle.ToLower().Contains(Serarhbar1.Text.ToLower()));


            }
            else
            {

                Datagrid.ItemsSource = allPersons;

            }




        }
    }

}
