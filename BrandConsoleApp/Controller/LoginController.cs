using BrandConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandConsoleApp.Controller
{
    public class LoginController
    {
        protected ICallback Observer;
        public LoginController(ICallback obs) { this.Observer = obs; }

        public void Execute(Dictionary<string, Object> incomingStateInfo, string username, string password)
        {

            AuthorizedUser someUser = new AuthorizedUser();

            someUser.Populate(username);

            // Console.WriteLine("Result: " + someUser); MIDDLE TIER DOES NOT WRITE BACK TO THE FRONT END DIRECTLY, ONLY VIA CALLBACK

            Dictionary<string, Object> stateInfo = new Dictionary<string, Object>();

            if (someUser.IsPopulated())
            {
                //Console.WriteLine(" You exist! Enter your password: ");   

                if (someUser.CheckIfPasswordsMatch(password))
                {
                    stateInfo["Message"] = " Passwords match: login successful! ";
                    stateInfo["LoginName"] = username;
                    Observer.OnCallback("LoginSuccess", stateInfo);
                }
                else
                {
                    stateInfo["Message"] = " Passwords don't match: you are an intruder - get out! ";
                    stateInfo["LoginName"] = "";
                    Observer.OnCallback("LoginFailed", stateInfo);
                }

            }
            else
            {
                stateInfo["Message"] = " You don't exist: you are an intruder - get out! ";
                stateInfo["LoginName"] = "";
                Observer.OnCallback("LoginFailed", stateInfo);
            }
        }
    }
}
