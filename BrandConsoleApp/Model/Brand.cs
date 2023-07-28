using System.Globalization;
using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
using BrandConsoleApp.Util;

namespace BrandConsoleApp.Model
{

    public class Brand
    {

        protected int? ID { get; set; }
        protected string Name { get; set; }
        protected string Notes { get; set; }

        public Brand()
        {
            ID = 0;
            Name = "";
            Notes = "";
        }

        public Brand(int Id, string nm, string notes)
        {
            ID = Id;
            Name = nm;
            Notes = notes;
        }

        public Brand(string nm, string notes)
        {
            Name = nm;
            Notes = notes;
        }

        public void SetValues(string nm, string nts)
        {
            Name = nm;
            Notes = nts;
        }
        public void Populate(int idToUse)
        {
            // Code from website 
            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();

                PopulateHelper(idToUse, connection);
            }
        }

        protected void ConstructPopulateQueryCommand(int idToUse, QC.SqlCommand command)
        {
            string query = "SELECT * FROM Brand WHERE (ID = " + idToUse + ");";
            command.CommandText = query;

        }

        private void PopulateHelper(int idToUse, QC.SqlConnection connection)
        {

            using (var command = new QC.SqlCommand())
            {

                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;
                //command.CommandText = query;
                ConstructPopulateQueryCommand(idToUse, command);

                QC.SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                    Name = reader.GetString(1);
                    Notes = reader.GetString(2);
                }
            }
        }

        private void InsertIntoDB(QC.SqlConnection connection)
        {
            // Taking a 'PreparedStatement' approach here, avoids SQL Injection  
            // THIS IS IMPORTANT 

            QC.SqlParameter parameter;

            string insertQuery = "INSERT INTO Brand (Name, Notes) " +
                " OUTPUT INSERTED.ID " +
                " VALUES (@Name, @Notes);";

            using (var command = new QC.SqlCommand())
            {
                // Console.WriteLine("save mode: " + saveMode);

                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;

                command.CommandText = insertQuery;

                parameter = new QC.SqlParameter("@Name", DT.SqlDbType.NVarChar, 100);  // Fix Type and Length 
                parameter.Value = Name;
                command.Parameters.Add(parameter);

                parameter = new QC.SqlParameter("@Notes", DT.SqlDbType.NVarChar, 1000); // Fix Type and Length  
                parameter.Value = Notes;
                command.Parameters.Add(parameter);

                int genID = (int)command.ExecuteScalar();
                ID = genID;
            }
        }

        private void UpdateInDB(QC.SqlConnection connection)
        {
            QC.SqlParameter parameter;

            string updateQuery = "UPDATE Brand" +
               " SET Name = @Name, Notes = @Notes " +
               " WHERE (ID = @Id);";

            using (var command = new QC.SqlCommand())
            {
                // Console.WriteLine("save mode: " + saveMode);

                command.Connection = connection;
                command.CommandType = DT.CommandType.Text;

                command.CommandText = updateQuery;

                parameter = new QC.SqlParameter("@Name", DT.SqlDbType.NVarChar, 100);  // Fix Type and Length 
                parameter.Value = Name;
                command.Parameters.Add(parameter);

                parameter = new QC.SqlParameter("@Notes", DT.SqlDbType.NVarChar, 1000); // Fix Type and Length  
                parameter.Value = Notes;
                command.Parameters.Add(parameter);

                parameter = new QC.SqlParameter("@Id", DT.SqlDbType.Int);  // Fix Type and Length 
                parameter.Value = ID;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        protected bool IsNewObject()
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

        public void Save()
        {
            using (QC.SqlConnection connection = new QC.SqlConnection(Utilities.GetConnectionString()))
            {
                connection.Open();
                Save(connection);
            }
        }
        public void Save(QC.SqlConnection connection)
        {

            if (IsNewObject())
            {
                InsertIntoDB(connection);
            }
            else
            {
                UpdateInDB(connection);
            }
        }

        public override string ToString()
        {
            return "ID: " + ID + "; Name: " + Name + "; Notes: " + Notes;
        }

    }

}