using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionManagementSystem.Model
{
    public class VoterDetail
    {

        public int VoterUId { get; set; }

        public string VoterId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Photos { get; set; }
        public bool IsApprove { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifidBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
