using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Threading.Tasks;

namespace FirebaseTutorial
{
    class AutoIdManagement
    {
        readonly IFirebaseClient client;
        public AutoIdManagement()
        {
            client = new FireBaseManagement().InitialFireBase();
        }
        public async Task<int> GetCurrentId()
        {
            FirebaseResponse autoResponse = await client.GetTaskAsync("Auto");
            return Convert.ToInt32(autoResponse.ResultAs<AutoIncrement>().Counter);
        }
        public async Task<int> UpdateId(string newAutoId)
        {
            await client.UpdateTaskAsync("Auto", new AutoIncrement { Counter = newAutoId });
            FirebaseResponse autoResponse = await client.GetTaskAsync("Auto");
            return Convert.ToInt32(autoResponse.ResultAs<AutoIncrement>().Counter);
        }

    }
}
