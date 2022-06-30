using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk
{

    class ClassData
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task<List<DataShearing>> GetAlldata()
        {

            return (await firebaseClient
              .Child("Chat")
              .OnceAsync<DataShearing>()).Select(item => new DataShearing
              {
                  Subtitle = item.Object.Subtitle,
                  IDSubtitle = item.Key,
                  Email = item.Object.Email,
                   NewsDateTime = item.Object.NewsDateTime,
                  UserName = item.Object.UserName,
                  imgproplme = item.Object.imgproplme,
                  Subject = item.Object.Subject,
                  IsSolved = item.Object.IsSolved,

              }).OrderByDescending(Item => Item.NewsDateTime ).ToList();
        }





   







        //public async Task<List<MyDatabaseRecord>> GetAllComments()
        //{

        //    return (await firebaseClient
        //      .Child("Comeents")
        //      .OnceAsync<MyDatabaseRecord>()).Select(item => new MyDatabaseRecord
        //      {
        //          COmment = item.Object.COmment,
        //          Datecoment = item.Object.Datecoment,
        //          idsubtitle = item.Object.idsubtitle,
        //          nameUsercoment = item.Object.nameUsercoment,

        //      }).ToList();
        //}

    }


}


