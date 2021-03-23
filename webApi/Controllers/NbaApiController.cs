using System;
using System.Collections.Generic;
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

        public NbaApiController(){
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
        
    }
}