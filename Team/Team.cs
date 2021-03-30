using System;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Teams
{
    public class Team
    {
        [JsonProperty("TeamName")]
        public string TeamName { get; set; }

        public Team()
        {
            this.TeamName = " ";
        }

        public Team(string tname)
        {
            this.TeamName = tname;
        }

        public Team checkTeam(Team t)
        {
            string connectionString = @"Data Source=nba-db-main.cp0wohpwv9ub.us-east-1.rds.amazonaws.com;
            Initial Catalog=nba-db-main;User ID=admin; Password=nbaadmin1234";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM Team WHERE TeamName = @team";

            SqlCommand command = new SqlCommand(queryString, con);
            command.Parameters.AddWithValue("@team", t.TeamName);
            Team found = null;

            try
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        found = new Team(reader[0].ToString());
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                con.Close();
            }

            return found;
        }

        public string addTeam(Team t)
        {
            string connectionString = @"Data Source=nba-db-main.cp0wohpwv9ub.us-east-1.rds.amazonaws.com;
            Initial Catalog=nba-db-main;User ID=admin; Password=nbaadmin1234";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "INSERT INTO Team (TeamName) VALUES (@team)";

            SqlCommand command = new SqlCommand(queryString, con);
            command.Parameters.AddWithValue("@team", t.TeamName);

            int result = 0;
            try{
                con.Open();
                result = command.ExecuteNonQuery();
            }
            catch(SqlException ex){
                Console.WriteLine(ex.Message);
                con.Close();
            }
            
            //Check errors 
            if (result < 0)
            {
                return "Fail";
            }
            else
            {
                return "Success";
            }
        }


    }
}
