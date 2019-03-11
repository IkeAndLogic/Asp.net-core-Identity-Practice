using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Tractor
    {

         public int TractorId { get; set; }

        //Tractor Has many DriverTractorAssignmentHistories
        public virtual List<DriverTractorAssignmentHistory> DriverTractorAssignmentHistories { get; set; }

        public ApplicationUser User { get; set; }


    }
}
