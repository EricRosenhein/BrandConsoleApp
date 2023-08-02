﻿using System;
using System.Collections.Generic;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BrandConsoleApp.Model
{
    public class Location : Persistable
    {
        protected int? ID { get; set; }
        protected string Area { get; set; }
        protected string Locus { get; set; }

        public Location()
        {
            ID = 0;
            Area = string.Empty;
            Locus = string.Empty;
        }

        public Location(int? idToUse, string area, string locus)
        {
            ID = idToUse;
            Area = area;
            Locus = locus;
        }   

        public Location (string area, string locus)
        {
            Area = area;
            Locus = locus;
        }

        public void SetValues (string area, string locus)
        {
            Area = area;
            Locus = locus;
        }

        public void Populate(int idToUse)
        {
            string IDStr = idToUse + "";
            Dictionary<string, Object> d = new Dictionary<string, Object>();
            d["id"] = IDStr;
            PopulateHelper (d);
        }

        protected override void ConstructPopulateQueryCommand(Dictionary<string,Object> dictIdToUse, QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM Location WHERE (ID = @NP);";

            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.Int);
            parameter.Value = dictIdToUse["id"];
            command.Parameters.Add(parameter);
        }

        protected override void ProcessPopulateQueryResult(QC.SqlDataReader reader)
        {
            while (reader.Read())
            {
                ID = reader.GetInt32(0);
                Area = reader.GetString(1);
                Locus = reader.GetString(2);
            }
        }

        protected override void SetupCommandForInsert(QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string insertQuery = "INSERT INTO Location (Area, Locus) " +
                " OUTPUT INSERTED.ID " +
                " VALUES (@Area, @Locus);";

            command.CommandText = insertQuery;

            parameter = new QC.SqlParameter("@Area", DT.SqlDbType.NVarChar, 10);  // Fix Type and Length 
            parameter.Value = Area;
            command.Parameters.Add(parameter);

            parameter = new QC.SqlParameter("@Locus", DT.SqlDbType.NVarChar, 25); // Fix Type and Length  
            parameter.Value = Locus;
            command.Parameters.Add(parameter);

        }

        protected override void SetAutogeneratedIDFromInsert(int genID)
        {
            this.ID = genID;
        }

        protected override void SetupCommandForUpdate(QC.SqlCommand command)
        {
            QC.SqlParameter parameter;

            string updateQuery = "UPDATE Location" +
               " SET Name = @Area, Notes = @Locus " +
               " WHERE (ID = @Id);";

            command.CommandText = updateQuery;

            parameter = new QC.SqlParameter("@Area", DT.SqlDbType.NVarChar, 10);  // Fix Type and Length 
            parameter.Value = Area;
            command.Parameters.Add(parameter);

            parameter = new QC.SqlParameter("@Locus", DT.SqlDbType.NVarChar, 25); // Fix Type and Length  
            parameter.Value = Locus;
            command.Parameters.Add(parameter);

            parameter = new QC.SqlParameter("@Id", DT.SqlDbType.Int);  // Fix Type and Length 
            parameter.Value = ID;
            command.Parameters.Add(parameter);
        }

        protected override bool IsNewObject()
        {
            if (ID == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override ResultMessage GetResultMessageForPopulate()
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Success, "Location with ID: " + this.ID +
                " retrieved successfully!");
            return mesg;
        }

        protected override ResultMessage GetResultMessageForSave()
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Success, "Location with Area and Locus: " + this.Area + this.Locus
                    + " saved successfully into database!");
            return mesg;
        }

        protected override ResultMessage GetErrorMessageForPopulate(Exception Ex)
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Error, "Error in retrieving Location with ID: " + this.ID +
                " from database!");
            return mesg;
        }

        protected override ResultMessage GetErrorMessageForSave(Exception Ex)
        {
            ResultMessage mesg = new ResultMessage(ResultMessage.ResultMessageType.Error, "Error in saving Location with Area and Locus: " + this.Area + this.Locus +
                " into database!") ;
            return mesg;
        }

        public override string ToString()
        {
            return "ID: " + ID + "; Name: " + Area + "; Notes: " + Locus;
        }

    }
}