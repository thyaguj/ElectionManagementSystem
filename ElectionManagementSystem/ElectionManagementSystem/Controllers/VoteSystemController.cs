using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using ElectionManagementSystem.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ElectionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteSystemController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public VoteSystemController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select PartyName,Address1, Address2,PartySymbol,contactno from
                            dbo.VoteDetail";

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
            string query = @"Insert Into PartyContestingDetail(Address1,Address2,PartySymbol,contactno) values(@Address1,@Address2,@PartySymbol,@contactno)";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalpath = _env.ContentRootPath + "/Photos/" + filename;

                using(var stream = new FileStream(physicalpath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch(Exception ex)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
