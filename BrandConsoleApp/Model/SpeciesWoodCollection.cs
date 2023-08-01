using System;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandConsoleApp.Model
{
    internal class SpeciesWoodCollection : BrandCollection
    {
        protected List<SpeciesWood> SpeciesWoodList;

        public SpeciesWoodCollection()
        {
            SpeciesWoodList = new List<SpeciesWood>();
            QueryMethod = QueryConstructorViaName;
        }

        // Fully helper methods
        protected override void ProcessPopulateQueryResult(QC.SqlDataReader reader)
        {
            while (reader.Read())
            {
                int locID = reader.GetInt32(0);
                string locName = reader.GetString(1);
                string locNotes = reader.GetString(2);
                SpeciesWoodList.Add(new SpeciesWood(locID, locName, locNotes));
            }
        }

        protected override void QueryConstructorViaName(string namePart, QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM SpeciesWood WHERE (Name LIKE CONCAT('%', @NP, '%'));";

            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 100);  // Fix Type and Length 
            parameter.Value = namePart;
            command.Parameters.Add(parameter);
        }


        protected override void QueryConstructorViaNotes(string notesPart, QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM SpeciesWood WHERE (Notes LIKE CONCAT('%', @NP, '%'));";

            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 1000);  // Fix Type and Length 
            parameter.Value = notesPart;
            command.Parameters.Add(parameter);
        }

        protected override ResultMessage GetResultMessageForPopulate()
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Success, "Wood Species Collection " +
                " retrieved successfully!");
            return mesg;
        }

        protected override ResultMessage GetErrorMessageForPopulate(Exception Ex)
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Error, "Error in retrieving Wood Species Collection " +
                " from database!");
            return mesg;
        }

        public override string ToString()
        {
            string retVal = "";
            for (int cnt = 0; cnt < SpeciesWoodList.Count; cnt++)
            {
                retVal += SpeciesWoodList[cnt].ToString();
            }

            return retVal;
        }
    }
}
