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

        protected delegate void PopulateQueryMethodType(Dictionary<string, Object> val, QC.SqlCommand command);

        protected PopulateQueryMethodType QueryMethod;

        public LocationCollection()
        {
            LocationList = new List<Location>();
            QueryMethod = QueryConstructorViaArea;
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
            QueryMethod = new PopulateQueryMethodType(QueryConstructorViaArea);
            Dictionary<string, Object> d = new Dictionary<string, Object>();
            d["area"] = areaPart;
            PopulateHelper(d);
        }

        public void PopulateViaAreaAndLocus(string areaPart, string locPart)
        {
            QueryMethod = new PopulateQueryMethodType(QueryConstructorViaAreaAndLocus);
            Dictionary<string, Object> d = new Dictionary<string, Object>();
            d["area"] = areaPart;
            d["locus"] = locPart;
            PopulateHelper(d);
        }

        protected override void ConstructPopulateQueryCommand(Dictionary<string, Object> val, QC.SqlCommand command)
        {
            QueryMethod(val, command);
        }

        protected virtual void QueryConstructorViaArea(Dictionary<string,Object> dictAreaPart, QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM Location WHERE (Area LIKE CONCAT('%', @NP, '%'));";

            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 25);  // Fix Type and Length 
            parameter.Value = dictAreaPart["area"];
            command.Parameters.Add(parameter);
        }

        protected virtual void QueryConstructorViaAreaAndLocus(Dictionary<string, Object> dictAreaPart, QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM Location WHERE ((Area LIKE CONCAT('%', @Area, '%')) AND (Locus LIKE CONCAT('%', @Locus, '%')));";

            command.CommandText = query;

            parameter = new QC.SqlParameter("@Area", DT.SqlDbType.NVarChar, 25);  // Fix Type and Length 
            parameter.Value = dictAreaPart["area"];
            command.Parameters.Add(parameter);

            parameter = new QC.SqlParameter("@Locus", DT.SqlDbType.NVarChar, 25);  // Fix Type and Length 
            parameter.Value = dictAreaPart["locus"];
            command.Parameters.Add(parameter);
        }

        protected override ResultMessage GetResultMessageForPopulate()
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Success, "Location Collection " +
                " retrieved successfully!");
            return mesg;
        }

        protected override ResultMessage GetResultMessageForSave()
        {
            throw new NotImplementedException();
        }

        protected override ResultMessage GetErrorMessageForPopulate(Exception Ex)
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Error, "Error in retrieving Location Collection " +
                " from database!");
            return mesg;
        }

        protected override ResultMessage GetErrorMessageForSave(Exception Ex)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string retVal = "";
            for (int cnt = 0; cnt < LocationList.Count; cnt++)
            {
                retVal += LocationList[cnt].ToString();
            }

            return retVal;
        }

    }
}
