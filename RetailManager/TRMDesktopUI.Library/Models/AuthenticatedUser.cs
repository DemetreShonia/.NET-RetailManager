using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Models
{
    public class AuthenticatedUser
    {

        /*
          {
            "access_token": "xAy1zCZX8G6AJwczMJqMvYdmx2x1NV7EBkpzk-Gn09Tu0G-aKZtYswZ8zwKRaWWQvm1n9jLjslZt_kBCLDuX9r46M6KJ6MSe2tf1VgTRWHMIGsYcYpK5ejyPX0v7JEQJwja5KyZJ590efekuWOKG-5JolajgsuWc_5mLX_BPGK0dxO8yTweBHQT2Zr_geVXxS9CbZXUZ-N1tgEz3SOJXGxAEeC-TC_11QrMNIa3Io9RzEZeichd8nt9rfNK7vQ3awQKRxhCuBk0SFn4yXCqtoeX4BFVlmOf7OkunKorcpC9dJbVYCStCD0wjRkkw8tBazhawcDiXkLtOwjFPfD79gvINxV8nqQJJZBB5VN4VWxuUQjKF3oB_8HLJBv053Fql0fjlY4eKinMi0nF8Ejpy9GmOsFsO8NVRbDWJEcXd-3Y7vxdN234_1pg26z1O9toeZxVvPe3HQNqX5YUNJEPKQzfRF0gOTCju_EW_ZsR57TLUh2HC-CdB5tyv9xcmhzcQ",
            "token_type": "bearer",
            "expires_in": 1209599,
            "userName": "shonik1121@gmail.com",
            ".issued": "Fri, 31 Jan 2025 18:27:27 GMT",
            ".expires": "Fri, 14 Feb 2025 18:27:27 GMT"
            }
         */

        public string Access_Token { get; set; }
        public string UserName { get; set; }
    }
}
