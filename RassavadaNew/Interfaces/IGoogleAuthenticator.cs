using Android.App;
using RassavadaNew.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.Interfaces
{
    public interface IGoogleAuthenticator
    {
        void Login(Action<GoogleUser, string> OnLoginComplete);
        void Logout();
    }
}
