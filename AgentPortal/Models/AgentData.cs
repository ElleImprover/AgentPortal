using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

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

        internal int AddNewAgent(Agents agent)
        {
            string connString = _configuration.GetConnectionString("default");
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();

                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Agents VALUES(@AgentCode, @AgentName, @WorkingArea, @Commission, @PhoneNo); ";
               
                cmd.Parameters.Add("@AgentCode", SqlDbType.NVarChar).Value = agent.AgentCode;
                cmd.Parameters.Add("@AgentName", SqlDbType.VarChar).Value = agent.AgentName;
                cmd.Parameters.Add("@WorkingArea", SqlDbType.NVarChar).Value = agent.WorkingArea;
                cmd.Parameters.Add("@Commission", SqlDbType.Decimal).Value = agent.Commission;
                cmd.Parameters.Add("@PhoneNo", SqlDbType.BigInt).Value = agent.PhoneNumber;

                cmd.Connection = connection;

               var num_rows= cmd.ExecuteNonQuery();
                return num_rows;
            }
        }

        public Agents Agent(string id)
        {
            var connection = _configuration.GetConnectionString("default");
            Agents agent;

            using (var conn = new SqlConnection(connection)) 
            {
                conn.Open(); 
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ID", SqlDbType.Char);
                cmd.Parameters["@ID"].Value = id;
                cmd.CommandText = "SELECT * FROM Agents where AgentCode=@id";

                var reader = cmd.ExecuteReader();

              
                var agCode = reader["AgentCode"].ToString();
                var agName = reader["AgentName"].ToString();
                var wArea = reader["WorkingArea"].ToString();
                var pNumber = Convert.ToInt64(reader["PhoneNo"]);
                var commission = Convert.ToDecimal(reader["Commission"]);

                agent = new Agents {
                    AgentCode = agCode,
                    AgentName = agName,
                    WorkingArea = wArea,
                    PhoneNumber = pNumber,
                    Commission = commission
                };
                
                return agent;
            }
        }

    }
}

