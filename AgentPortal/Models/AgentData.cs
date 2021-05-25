using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AgentPortal.Models
{
    public class AgentData
    {
        private readonly IConfiguration _configuration;
        public AgentData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Agents> AllAgentsData()
        {
            var agents = new List<Agents>();
            var connection = _configuration.GetConnectionString("default");

            using (var conn = new SqlConnection(connection))

            {
                conn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Agents";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var agCode = reader["AgentCode"].ToString();
                    var agName = reader["AgentName"].ToString();
                    var wArea = reader["WorkingArea"].ToString();
                    var pNumber = Convert.ToInt64(reader["PhoneNo"]);
                    var commission = Convert.ToDecimal(reader["Commission"]);

                    agents.Add(new Agents
                    {
                        AgentCode = agCode,
                        AgentName = agName,
                        WorkingArea = wArea,
                        PhoneNumber = pNumber,
                        Commission = commission
                    });
                }
            }

            return agents;
        }
    }
}

