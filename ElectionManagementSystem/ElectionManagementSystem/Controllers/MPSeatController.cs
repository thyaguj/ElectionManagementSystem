using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using ElectionManagementSystem.Model;
using ElectionManagementSystem.ElectionManagementBusiness.Interface;

namespace ElectionManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPSeatController :  ControllerBase
    {

        private readonly IConfiguration _configuration;
        public MPSeatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //DataTable mptable = new DataTable();
            //mptable =  _mpSeat.GetMPSeat();
            string query = @"Select State, Nationality,NoOfSeatPerState from
                            dbo.MPSeat";

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
        public JsonResult Post(MPSeat mpSeat)
        {
            string query = @"Insert Into MPSeat(State, Nationality,NoOfSeatPerState) values(@state,@Nationality,@NoOfSeat)";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@State", mpSeat.State);
                    mycommand.Parameters.AddWithValue("@Nationality", mpSeat.Nationality);
                    mycommand.Parameters.AddWithValue("@NoOfSeat", mpSeat.NoOfSeatsPerState);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpPut]
        public JsonResult Put(MPSeat mpSeat)
        {
            string query = @"Update MPSeat set State =@state , Nationality = @Nationality,NoOfSeatPerState =@NoOfSeat where seatid =@SeatId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@State", mpSeat.State);
                    mycommand.Parameters.AddWithValue("@Nationality", mpSeat.Nationality);
                    mycommand.Parameters.AddWithValue("@NoOfSeat", mpSeat.NoOfSeatsPerState);
                    mycommand.Parameters.AddWithValue("@SeatId", mpSeat.SeatId);
                    myreader = mycommand.ExecuteReader();
                    mptable.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(mptable);
        }

        [HttpDelete]
        public JsonResult Delete(MPSeat mpSeat)
        {
            string query = @"Delete from MpSeat where seatid =@SeatId ";

            DataTable mptable = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("ElectionManagement");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@SeatId", mpSeat.SeatId);
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
