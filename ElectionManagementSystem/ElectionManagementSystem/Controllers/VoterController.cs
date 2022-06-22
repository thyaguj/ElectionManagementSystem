using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using ElectionManagementSystem.Model;

namespace ElectionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : Controller
    {
        private readonly IConfiguration _configuration;
        public VoterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select Name,VoterId, Address1,Address2,IsApprove from
                            dbo.VoterDetail";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpPost]
        public JsonResult Post(VoterDetail voterDetail)
        {
            string query = @"Insert Into VoterDetail(Name,VoterId, Address1,Address2,IsApprove) values(@Name,@VoterId,@Address1,@Address2,@IsApprove)";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@Name", voterDetail.Name);
                    mycommand.Parameters.AddWithValue("@VoterId", voterDetail.VoterId);
                    mycommand.Parameters.AddWithValue("@Address1", voterDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", voterDetail.Address2);
                    mycommand.Parameters.AddWithValue("@IsApprove", voterDetail.IsApprove);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpPut]
        public JsonResult Put(VoterDetail voterDetail)
        {
            string query = @"Update VoterDetail set Name =@Name , VoterId = @VoterId,Address1 =@Address1,Address2 =@Address2,IsApprove=@IsApprove where VoterUId =@VoterUId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@Name", voterDetail.Name);
                    mycommand.Parameters.AddWithValue("@VoterId", voterDetail.VoterId);
                    mycommand.Parameters.AddWithValue("@Address1", voterDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", voterDetail.Address2);
                    mycommand.Parameters.AddWithValue("@IsApprove", voterDetail.IsApprove);
                    mycommand.Parameters.AddWithValue("@VoterUId", voterDetail.VoterUId);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpDelete]
        public JsonResult Delete(VoterDetail voterDetail)
        {
            string query = @"Delete from MpSeat where VoterUId =@VoterUId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@VoterUId", voterDetail.VoterUId);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }
    }
}
