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
    public class PartyController : Controller
    {
        private readonly IConfiguration _configuration;
        public PartyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select PartyName,Address1, Address2,PartySymbol,contactno from
                            dbo.PartyDetail";

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
        public JsonResult Post(PartyDetail partyDetail)
        {
            string query = @"Insert Into PartyDetail(PartyName,Address1,Address2,PartySymbol,contactno) values(@PartyName,@Address1,@Address2,@PartySymbol,@contactno)";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@PartyName", partyDetail.PartyName);
                    mycommand.Parameters.AddWithValue("@contactno", partyDetail.ContactNo);
                    mycommand.Parameters.AddWithValue("@Address1", partyDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", partyDetail.Address2);
                    mycommand.Parameters.AddWithValue("@PartySymbol", partyDetail.PartySumbol);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpPut]
        public JsonResult Put(PartyDetail partyDetail)
        {
            string query = @"Update PartyDetail set PartyName =@PartyName , ContactNo = @ContactNo,Address1 =@Address1,Address2 =@Address2,PartySumbol=@PartySumbol where PartyId =@PartyId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@PartyName", partyDetail.PartyName);
                    mycommand.Parameters.AddWithValue("@ContactNo", partyDetail.ContactNo);
                    mycommand.Parameters.AddWithValue("@Address1", partyDetail.Address1);
                    mycommand.Parameters.AddWithValue("@Address2", partyDetail.Address2);
                    mycommand.Parameters.AddWithValue("@PartySumbol", partyDetail.PartySumbol);
                    mycommand.Parameters.AddWithValue("@PartyId", partyDetail.PartyId);
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
            string query = @"Delete from PartyDetail where PartyId =@PartyId ";

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
