using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandConsoleApp
{
    public interface ICallback
    {
        public void OnCallback(string key, Dictionary<string, object> value);
    }
}
