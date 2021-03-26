using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Teams;

namespace webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NbaApiController : ControllerBase
    {
        public Team Team { get; set; }
        public List<Team> Teams;

        public NbaApiController()
        {
            this.Team = new Team();
            this.Teams = new List<Team>();
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
            string connectionString = @"Data Source=nba-database.cipoitywrwyj.us-east-1.rds.amazonaws.com;
            Initial Catalog=NBA-Database;User ID=admin; Password=daniel180";
            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "SELECT * FROM tbl_TEAMS";

            SqlCommand command = new SqlCommand(queryString, con);

            try
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Teams.Add(
                            new Team(reader[1].ToString())
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

    }
}