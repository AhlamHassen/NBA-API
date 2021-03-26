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
            string connectionString = @"Data Source=nba-database.cipoitywrwyj.us-east-1.rds.amazonaws.com;
            Initial Catalog=NBA-Database;User ID=admin; Password=daniel180";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM tbl_TEAMS WHERE TEAM_NAME = @team";

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
            string connectionString = @"Data Source=nba-database.cipoitywrwyj.us-east-1.rds.amazonaws.com;
            Initial Catalog=NBA-Database;User ID=admin; Password=daniel180";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "INSERT INTO tbl_TEAMS (TEAM_NAME) VALUES (@team)";

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
