using System;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BrandConsoleApp.Model
{
    internal class LocationCollection : PersistableCollection
    {
        protected List<Location> LocationList;

        protected delegate void PopulateQueryMethodType(string val, QC.SqlCommand command);

        protected PopulateQueryMethodType QueryMethod;

        public LocationCollection()
        {
            LocationList = new List<Location>();
            //QueryMethod = QueryContructorViaArea;
        }

        protected override void ProcessPopulateQueryResult(SqlDataReader reader)
        {
            while (reader.Read())
            {
                int locID = reader.GetInt32(0);
                string locArea = reader.GetString(1);
                string locLocus = reader.GetString(2);
                LocationList.Add(new Location(locID, locArea, locLocus));
            }
        }

        public void PopulateViaArea(string areaPart)
        {
           // QueryMethod = new PopulateQueryMethodType(QueryConstructorViaArea);
            Dictionary<string, Object> d = new Dictionary<string, Object>();
            d["area"] = areaPart;
            PopulateHelper(d);
        }

        public void PopulateViaAreaAndLocus(string areaPart, string locPart)
        {
            //QueryMethod = new PopulateQueryMethodType(QueryConstructorViaAreaAndLocus);
            Dictionary<string, Object> d = new Dictionary<string, Object>();
            d["locus"] = locPart;
            PopulateHelper(d);
        }

        protected override ResultMessage GetErrorMessageForSave(Exception excep)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage GetResultMessageForSave()
        {
            throw new NotImplementedException();
        }

        protected override void ConstructPopulateQueryCommand(Dictionary<string, object> populateData, SqlCommand command)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage GetErrorMessageForPopulate(Exception excep)
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage GetResultMessageForPopulate()
        {
            throw new NotImplementedException();
        }
    }
}
