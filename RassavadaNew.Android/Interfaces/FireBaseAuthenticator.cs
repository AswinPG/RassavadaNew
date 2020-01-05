using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using RassavadaNew.Droid.Interfaces;
using RassavadaNew.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FireBaseAuthenticator))]

namespace RassavadaNew.Droid.Interfaces
{
    public class FireBaseAuthenticator : IFireBaseAuthenticator
    {
        public async Task<string> LoginWithFaceBook(string token)
        {
            
            
            var cred = FacebookAuthProvider.GetCredential(token);
            
            var user = await FirebaseAuth.Instance.SignInWithCredentialAsync(cred);
            if (user != null)
            {
                return user.User.DisplayName;
            }
            else
                return null;
            
        }

        public async Task<string> LoginWithGoogle(string IdTok, string accessTok )
        {
            var cred = GoogleAuthProvider.GetCredential(IdTok,accessTok);

            var user = await FirebaseAuth.Instance.SignInWithCredentialAsync(cred);
            if (user != null)
            {
                return user.User.DisplayName;
            }
            else
                return null;
        }
    }
}