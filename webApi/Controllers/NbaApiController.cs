using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Teams;
using Players;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NbaApiController : ControllerBase
    {
        public Team Team { get; set; }        
        public List<Team> Teams;
        public List<Player> Players;



        public NbaApiController()
        {
            this.Team = new Team();
            this.Teams = new List<Team>();
            this.Players = new List<Player>();
        }

        [HttpPost("CheckTeam")]
        public bool teamExist([FromBody] Team team)
        {
            // if this team exists in the team table return true else return false
            if (this.Team.checkTeam(team) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPost("AddTeam")]
        public string addTeam([FromBody] Team team)
        {
            string message = this.Team.addTeam(team);
            return message;
        }

        [HttpGet("GetTeams")]
        public List<Team> getTeams()
        {
            string connectionString = @"Data Source=nba-db-main.cp0wohpwv9ub.us-east-1.rds.amazonaws.com;
            Initial Catalog=nba-db-main;User ID=admin; Password=nbaadmin1234";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM Team";

            SqlCommand command = new SqlCommand(queryString, con); 

            try
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        Teams.Add(
                            new Team(reader[0].ToString())
                        );
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                con.Close();
            }

            return Teams;
        }

        [HttpGet("GetPlayers")]
        public List<Player> getPlayers(){
            string connectionString = @"Data Source=nba-db-main.cp0wohpwv9ub.us-east-1.rds.amazonaws.com;
            Initial Catalog=nba-db-main;User ID=admin; Password=nbaadmin1234";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM allPlayers";
            SqlCommand command = new SqlCommand(queryString, con); 

            try
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader()) 
                {                  
                    while (reader.Read())
                    {
                            Players.Add(
                            new Player(reader[0].ToString(), reader[1].ToString(), (int)reader[2], (int)reader[3],
                            (decimal)reader[4], (decimal)reader[5], (decimal)reader[6], (decimal)reader[7], (decimal)reader[8],
                            (decimal)reader[9], (decimal)reader[10], (decimal)reader[11], (decimal)reader[12],
                            (decimal)reader[13], (decimal)reader[14], (decimal)reader[15], (decimal)reader[16],
                            (decimal)reader[17], (decimal)reader[18], (decimal)reader[19], (int)reader[20],
                            (int)reader[21], (decimal)reader[22], (decimal)reader[23], (decimal)reader[24], (decimal)reader[25], (decimal)reader[26], (decimal)reader[27], (decimal)reader[28])
                            
                        );
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                con.Close();
            }

            return Players;
        }

    }
}