using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DriverTractorAssignmentHistory
    {

        public int DriverTractorAssignmentHistoryId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int? TractorId { get; set; }
        public Tractor Tractor { get; set; }

        public DateTime DateTimeAssigned { get; set; }
        public DateTime DateTimeUnAssigned { get; set; }


    }
}
