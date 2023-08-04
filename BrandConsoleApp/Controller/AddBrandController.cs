using BrandConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandConsoleApp.Controller
{
    public class AddBrandController
    {

        protected ICallback Observer;

        public AddBrandController(ICallback obs) { this.Observer = obs; }

        public void Execute(Dictionary<string, Object> incomingStateInfo, string name, string notes)
        {
            Dictionary<string, Object> stateInfo = new Dictionary<string, Object>();
            string loginName = null;

            try
            {
                loginName = incomingStateInfo["LoginName"].ToString();

                if ( loginName != null)
                {
                    string username = incomingStateInfo["LoginName"].ToString();
                    if ((username != null) && (username.Length > 0))
                    {
                        Brand someBrand = new Brand(name, notes);

                        someBrand.Save();

                        stateInfo["Message"] = " Brand added successfully!";
                        stateInfo["LoginName"] = loginName;
                        stateInfo["Brand"] = someBrand;
                        Observer.OnCallback("AddBrandSuccess", stateInfo);


                    }
                    else
                    {
                        stateInfo["Message"] = " No login credentials found!";
                        stateInfo["Brand"] = null;
                        stateInfo["LoginName"] = loginName;
                        Observer.OnCallback("AddBrandFailed", stateInfo);
                    }
                }
                else
                {
                    stateInfo["Message"] = " No login credentials found!";
                    stateInfo["Brand"] = null;
                    stateInfo["LoginName"] = loginName;
                    Observer.OnCallback("AddBrandFailed", stateInfo);
                }
            }
            catch (KeyNotFoundException Excep)
            {
                stateInfo["Message"] = " No login credentials found!";
                stateInfo["Brand"] = null;
                stateInfo["LoginName"] = loginName;
                Observer.OnCallback("AddBrandFailed", stateInfo);
            }
            catch (Exception Ex)
            {

                stateInfo["Message"] = " No login credentials found!";
                stateInfo["Brand"] = null;
                stateInfo["LoginName"] = loginName;
                Observer.OnCallback("AddBrandFailed", stateInfo);
            }
               
        }
    }
}
