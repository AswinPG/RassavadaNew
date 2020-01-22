using RassavadaNew.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace RassavadaNew.RefreshLogic
{
    public static class Refresh
    {
        public static readonly HomePage home;
        static HomePage Home;
        public static void SetHome(HomePage homePage)
        {
            Home = homePage;
        }
        public static void RefreshHome()
        {
            Home.GetUser();
        }
    }
}
