using ElectionManagementSystem.ElectionManagementBusiness.Interface;
using ElectionManagementSystem.ElectionManagementDataAccess.Interface;
using System.Data;

namespace ElectionManagementSystem.ElectionManagementBusiness
{
    public class MPSeatDataAccess : IMPSeatBusiness
    {
        public readonly IMPSeatDataAccess _mpSeatDataAccess;
        public MPSeatDataAccess(IMPSeatDataAccess mPSeatDataAccess)
        {
             //_mpSeatDataAccess = mPSeatDataAccess;
        }
        public DataTable GetMPSeat()
        {
            DataTable DTable = new DataTable();

            //DTable =  _mpSeatDataAccess.GetMpSeat();

            return DTable;
        }
    }
}
