using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionManagementSystem.Model
{
    public class PartyContestDetail
    {
        public int PartyContestUId { get; set; }
        public string State { get; set; }
        public int PartyId { get; set; }
        public string ContestentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int ContactNo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifidBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
