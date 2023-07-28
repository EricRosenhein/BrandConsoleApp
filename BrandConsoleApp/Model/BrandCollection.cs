using System.Text;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using BrandConsoleApp.Util;

namespace BrandConsoleApp.Model
{
    public class BrandCollection
    {
        protected List<Brand> BrandList;


        public BrandCollection()
        {
            BrandList = new List<Brand>();
        }



        public void PopulateViaName(string namePart)
        {

            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();
                PopulateViaName(namePart, connection);
            }

        }

        public void PopulateViaNotes(string notesPart)
        {
            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();
                PopulateViaNotes(notesPart, connection);
            }
        }

        private void PopulateHelper(QC.SqlCommand command)
        {

            QC.SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int locID = reader.GetInt32(0);
                string locName = reader.GetString(1);
                string locNotes = reader.GetString(2);
                BrandList.Add(new Brand(locID, locName, locNotes));
            }

        }

        private void PopulateViaName(string namePart, QC.SqlConnection connection)
        {

            // Taking a 'PreparedStatement' approach here, avoids SQL Injection  
            // THIS IS IMPORTANT 
            // NOT WORKING
            QC.SqlParameter parameter;


            using (QC.SqlCommand command = new QC.SqlCommand())
            {
                string query = @"SELECT * FROM Brand WHERE (Name LIKE CONCAT('%', @NP, '%'));";

                // string query = "SELECT * FROM Brand WHERE (Name LIKE '%" + namePart +"%');"; // UNSAFE - ERIC LIKES UNSAFE FOR NOW, BUT FIX IT

                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = query;

                parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 100);  // Fix Type and Length 
                parameter.Value = namePart;
                command.Parameters.Add(parameter);

                Console.WriteLine(command.CommandText);

                PopulateHelper(command);
            }
        }



        private void PopulateViaNotes(string notesPart, QC.SqlConnection connection)
        {

            // Taking a 'PreparedStatement' approach here, avoids SQL Injection  
            // THIS IS IMPORTANT 

            QC.SqlParameter parameter;


            using (QC.SqlCommand command = new QC.SqlCommand())
            {
                string query = @"SELECT * FROM Brand WHERE (Notes LIKE CONCAT('%', @NP, '%');";

                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = query;

                parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 1000);  // Fix Type and Length 
                parameter.Value = notesPart;
                command.Parameters.Add(parameter);

                PopulateHelper(command);
            }

        }



        public override string ToString()
        {
            string retVal = "";
            for (int cnt = 0; cnt < BrandList.Count; cnt++)
            {
                retVal += BrandList[cnt].ToString();
            }

            return retVal;
        }


    }





}
