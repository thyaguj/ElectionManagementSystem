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
    public class PartyContestController : Controller
    {
        private readonly IConfiguration _configuration;
        public PartyContestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select Nationality,State, PartyId,ContestentName,Address1,Address2,ContactNo from
                            dbo.PartyContestingDetail";

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
        public JsonResult Post(PartyContestDetail partyContestentDetail)
        {
            string query = @"Insert Into PartyContestingDetail(State, PartyId,ContestentName,Address1,Address2,ContactNo) values(@State,@PartyId,@ContestentName,@Address1,@Address2,@ContactNo)";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@State", partyContestentDetail.State);
                    mycommand.Parameters.AddWithValue("@PartyId", partyContestentDetail.PartyId);
                    mycommand.Parameters.AddWithValue("@ContestentName", partyContestentDetail.ContestentName);
                    mycommand.Parameters.AddWithValue("@Address1", partyContestentDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", partyContestentDetail.Address2);
                    mycommand.Parameters.AddWithValue("@ContactNo", partyContestentDetail.ContactNo);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpPut]
        public JsonResult Put(PartyContestDetail partyContestentDetail)
        {
            string query = @"Update PartyContestingDetail set  State = @State,PartyId =@PartyId,
                            ContestentName =@ContestentName,Address1=@Address1,Address2=@Address2,ContactNo=@ContactNo 
                            where ContestingUId =@ContestingUId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@State", partyContestentDetail.State);
                    mycommand.Parameters.AddWithValue("@PartyId", partyContestentDetail.PartyId);
                    mycommand.Parameters.AddWithValue("@ContestentName", partyContestentDetail.ContestentName);
                    mycommand.Parameters.AddWithValue("@Address1", partyContestentDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", partyContestentDetail.Address2);
                    mycommand.Parameters.AddWithValue("@ContactNo", partyContestentDetail.ContactNo);
                    mycommand.Parameters.AddWithValue("@ContestingUId", partyContestentDetail.PartyContestUId);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpDelete]
        public JsonResult Delete(PartyContestDetail partyContestentDetail)
        {
            string query = @"Delete from PartyContestingDetail where PartyContestUId =@PartyContestUId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@PartyContestUId", partyContestentDetail.PartyContestUId);
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
