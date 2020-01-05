using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RassavadaNew.Interfaces
{
    public interface IFireBaseAuthenticator
    {
        Task<string> LoginWithFaceBook(string token);
        Task<string> LoginWithGoogle(string idTok, string accesTok);



    }
}
