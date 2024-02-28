using Firebase.Auth;
using Firebase.Storage;

namespace HomeTravelAPI.Common
{
    public class UploadFile
    {
        private static string ApiKey = "AIzaSyDFkrafvWs8UauKu4rvjGoPZBwxY22-tbY";
        private static string Bucket = "hometravel-acdf6.appspot.com";
        private static string AuthEmail = "tranngoctu.root@gmail.com";
        private static string AuthPassword = "Matkhau9";

        public static async Task<string> Upload(FileStream stream, String fileName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(Bucket,
            new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            }).Child("images").Child(fileName).PutAsync(stream, cancellation.Token);
             return await task;
            
        } 
    }
}
