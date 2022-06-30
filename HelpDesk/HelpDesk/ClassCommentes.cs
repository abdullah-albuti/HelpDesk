using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk
{
    class ClassCommentes
    {
        FirebaseClient DirebaseClient = new FirebaseClient("https://helpdask-a2483-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task<List<MyDatabaseRecord>> GetAllComens(string A)
        {

            return (await DirebaseClient
              .Child("Comeents")
              .OnceAsync<MyDatabaseRecord>()).Select(item => new MyDatabaseRecord
              {
                  COmment = item.Object.COmment,
                  idsubtitle = item.Object.idsubtitle,
                  Datecoment = item.Object.Datecoment,
                  nameUsercoment = item.Object.nameUsercoment,
         

              }).Where(a => a.idsubtitle == A).ToList();
        }



    }
}
