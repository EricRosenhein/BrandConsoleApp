using System.Text;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using BrandConsoleApp.Util;
using System.Reflection.Metadata;

namespace BrandConsoleApp.Model
{
    public class BrandCollection
    {
        protected List<Brand> BrandList;


        public BrandCollection()
        {
            BrandList = new List<Brand>();
        }

        // Fully helper methods
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

        public void PopulateViaName(string namePart)
        {
            // Given the similarity in code between this method and the other populate method below,
            // maybe this code right below can be moved to another helper method which takes a delegate
            // parameter (a feature of C#) and invokes that method. But the challenge would be the
            // parameter profile. This method below (QueryConstructorViaName) takes a string, a command
            // and a connection as a parameter. Suppose the other method we want to use - say from a 
            // PopulateViaNameAndNotes method, takes in two strings, a command and a connection as parameters.
            // The stupid old teacher does not think delegates will work in that context, but maybe the smart
            // young kids can teach him something different!!
            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();
                using (QC.SqlCommand command = new QC.SqlCommand())
                {
                    // set up the query to retrieve the data
                    QueryConstructorViaName(namePart, command, connection);

                   // DEBUG Console.WriteLine(command.CommandText);

                    // set up the list with the data retrieved - i.e., with the query results
                    PopulateHelper(command);
                }
            }

        }

        public void PopulateViaNotes(string notesPart)
        {

            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();
                using (QC.SqlCommand command = new QC.SqlCommand())
                {
                    // set up the query to retrieve the data
                    QueryConstructorViaNotes(notesPart, command, connection);

                    // DEBUG Console.WriteLine(command.CommandText);

                    // set up the list with the data retrieved - i.e., with the query results
                    PopulateHelper(command);
                }
            }
        }


        protected void QueryConstructorViaName(string namePart, QC.SqlCommand command, QC.SqlConnection connection)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM Brand WHERE (Name LIKE CONCAT('%', @NP, '%'));";

            // string query = "SELECT * FROM Brand WHERE (Name LIKE '%" + namePart +"%');"; // UNSAFE - ERIC LIKES UNSAFE FOR NOW, BUT FIX IT

            command.Connection = connection;
            command.CommandType = DT.CommandType.Text;
            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 100);  // Fix Type and Length 
            parameter.Value = namePart;
            command.Parameters.Add(parameter);
        }


        protected void QueryConstructorViaNotes(string notesPart, QC.SqlCommand command, QC.SqlConnection connection)
        {
            QC.SqlParameter parameter;

            string query = @"SELECT * FROM Brand WHERE (Notes LIKE CONCAT('%', @NP, '%'));";

            // string query = "SELECT * FROM Brand WHERE (Name LIKE '%" + namePart +"%');"; // UNSAFE - ERIC LIKES UNSAFE FOR NOW, BUT FIX IT

            command.Connection = connection;
            command.CommandType = DT.CommandType.Text;
            command.CommandText = query;

            parameter = new QC.SqlParameter("@NP", DT.SqlDbType.NVarChar, 1000);  // Fix Type and Length 
            parameter.Value = notesPart;
            command.Parameters.Add(parameter);
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
