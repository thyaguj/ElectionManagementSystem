using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionManagementSystem.Model
{
    public class VoteDetail
    {
        public int VoterUniqueId { get; set; }
        public int PartyId { get; set; }
        public bool IsVote { get; set; }
        public int MpSeatId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifidBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
