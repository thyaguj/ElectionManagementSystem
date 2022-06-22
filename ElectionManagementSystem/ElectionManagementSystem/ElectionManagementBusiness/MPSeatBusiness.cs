using ElectionManagementSystem.ElectionManagementBusiness.Interface;
using ElectionManagementSystem.ElectionManagementDataAccess.Interface;
using System.Data;

namespace ElectionManagementSystem.ElectionManagementBusiness
{
    public class MPSeatBusiness : IMPSeatBusiness
    {
        public readonly IMPSeatDataAccess _mpSeatDataAccess;
        public MPSeatBusiness(IMPSeatDataAccess mPSeatDataAccess)
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
