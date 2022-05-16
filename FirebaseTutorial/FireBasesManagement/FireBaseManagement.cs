using FireSharp.Config;
using FireSharp.Interfaces;

namespace FirebaseTutorial
{
    class FireBaseManagement
    {
        readonly IFirebaseClient client;
        readonly IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "eLaD9VNfw6n4cRnDNYStNSMh8iil7YmqkARmg1sn",
            BasePath = "https://csharpworkshop-f8081-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        public FireBaseManagement()
        {
            client = new FireSharp.FirebaseClient(config);
        }

        public IFirebaseClient InitialFireBase() => client;


    }
}
