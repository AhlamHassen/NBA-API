using System;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Team
{
    public class Team
    {
        [JsonProperty("TeamName")]
        public string TeamName { get; set; }

        public Team(){
            this.TeamName = " ";
        }

        public Team(string tname){
            this.TeamName = tname;
        }

        public Team checkTeam(Team t){
            string connectionString = @"Data Source=databaseSourceHere;
            Initial Catalog=databaseNameHere;User ID=admin/TheIDUsed; Password=yourpassonAWS";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM Team WHERE TeamName = @team";

            SqlCommand command = new SqlCommand(queryString, con);
            command.Parameters.AddWithValue("@team", t.TeamName);
            con.Open();
            Team found = null;

            using(SqlDataReader reader = command.ExecuteReader()){
                while(reader.Read())
                {
                   found = new Team(reader[0].ToString());
                }
            }

            return found;
        }

        public string addTeam(Team t){
            string connectionString = @"Data Source=databaseSourceHere;
            Initial Catalog=databaseNameHere;User ID=admin/TheIDUsed; Password=yourpassonAWS";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "INSERT INTO Team (TeamName) VALUES (@team)"; 
            
            SqlCommand command = new SqlCommand(queryString, con);
            command.Parameters.AddWithValue("@team", t.TeamName);
            con.Open();
            int result = command.ExecuteNonQuery();

            //Check errors 
            if(result<0){
                return "Fail";
            }
            else{
                return "Success";
            }
        }

        
    }
}
