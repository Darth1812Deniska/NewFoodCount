using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Data;

namespace NewFoodCount
{
    public class FCP_BD
    {
        private SqlConnection _connection;

        public FCP_BD(string datasource, string database, string username, string password)
        {
            string conString = $"Data Source = { datasource}; " +
                $"Initial Catalog = { database };" +
                $"Persist Security Info=True;" +
                $"User ID={ username };" +
                $"Password={ password}";
            SqlConnection connection = new SqlConnection(conString);
            _connection = connection;

            try
            {
                _connection.Open();
            }
            catch 
            {
                
            }
        }

        public int SaveUser(string name, int gender, DateTime birthDate, float height, float weight,
            int userPurposeID, int trainingCount)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.FCP_SP_AddEditUser";

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@pGender", gender);
            cmd.Parameters.AddWithValue("@pBirthDay", birthDate);
            cmd.Parameters.AddWithValue("@pHeight", height);
            cmd.Parameters.AddWithValue("@pWeight", weight);
            cmd.Parameters.AddWithValue("@pUserPurposeID", userPurposeID);
            cmd.Parameters.AddWithValue("@pTrainingCount", trainingCount);

            cmd.Parameters.Add("@pResult", SqlDbType.Int);

            cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int result = Convert.ToInt32(cmd.Parameters["@pResult"].Value);

            return result;

        }

        public int SaveUser(int id, string name, int gender, DateTime birthDate, float height, float weight,
            int userPurposeID, int trainingCount)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.FCP_SP_AddEditUser";

            cmd.Parameters.AddWithValue("@@pID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@pGender", gender);
            cmd.Parameters.AddWithValue("@pBirthDay", birthDate);
            cmd.Parameters.AddWithValue("@pHeight", height);
            cmd.Parameters.AddWithValue("@pWeight", weight);
            cmd.Parameters.AddWithValue("@pUserPurposeID", userPurposeID);
            cmd.Parameters.AddWithValue("@pTrainingCount", trainingCount);

            cmd.Parameters.Add("@pResult", SqlDbType.Int);

            cmd.Parameters["@pResult"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            int result = Convert.ToInt32(cmd.Parameters["@pResult"].Value);

            return result;

        }

        public int SaveFinishedProduct(string name, float protein, float carbohydrate, float fat, float calorific)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.FCP_SP_AddEditFinishedProduct";
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pProtein", protein);
            command.Parameters.AddWithValue("@pCarbohydrate", carbohydrate);
            command.Parameters.AddWithValue("@pFat", fat);
            command.Parameters.AddWithValue("@pCalorific", calorific);
            command.Parameters.Add("@pResult", SqlDbType.Int);
            command.Parameters["@pResult"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();

            int result = Convert.ToInt32(command.Parameters["@pResult"].Value);

            return result;
        }

        public int SaveFinishedProduct(int id, string name, float protein, float carbohydrate, float fat, float calorific)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "dbo.FCP_SP_AddEditFinishedProduct";
            command.Parameters.AddWithValue("@pID", id);
            command.Parameters.AddWithValue("@pName", name);
            command.Parameters.AddWithValue("@pProtein", protein);
            command.Parameters.AddWithValue("@pCarbohydrate", carbohydrate);
            command.Parameters.AddWithValue("@pFat", fat);
            command.Parameters.AddWithValue("@pCalorific", calorific);
            command.Parameters.Add("@pResult", SqlDbType.Int);
            command.Parameters["@pResult"].Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();

            int result = Convert.ToInt32(command.Parameters["@pResult"].Value);

            return result;
        }

    }
}
