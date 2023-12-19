using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.View
{
    public static class SessionState
    {
        public static UserAccount CurrentUser { get; set; }


        public static bool IsLoggedIn { get; set; }
    }

}
