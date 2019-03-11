using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        //public int ApplicationUserId { get; set; }

        // property for first name
        public string FirstName { get; set; }

        // property for middle name
        public string MiddleName { get; set; }

        // property for Last name
        public string LastName { get; set; }

        //property for Street Number of Employee Address
        public string StreetNumber { get; set; }

        //property for Street Name of Employee Address
        public string StreetName { get; set; }

        //property for city of Employee Address
        public string City { get; set; }

        //property for ZipCode of Employee Address
        public string ZipCode { get; set; }

        // property for social security number
        public string SSN { get; set; }

        // property for social security number confirmation
        public string SsnConfirm { get; set; }

        // property for date of birth
        public DateTime Dob { get; set; }

        // for title of the employee
        public EmployeeType Title { get; set; }

        //public Role Role { get; set; }

        //property for license number
        public string LicNumber { get; set; }

        //property for license issuance
        public DateTime LicIssue { get; set; }

        //property for license expiration date
        public DateTime LicExpire { get; set; }

        //property for DOT Medical Card Number
        public string MedCardNumber { get; set; }

        //property for DOT Medical Card issance date
        public DateTime MedIssue { get; set; }

        //property for DOT Medical Card expiration date
        public DateTime MedExpire { get; set; }







        public int? TractorID { get; set; }
        public virtual Tractor Tractor { get; set; }

        //Driver Has many DriverTractorAssignmentHistories
        public virtual List<DriverTractorAssignmentHistory> DriverTractorAssignmentHistories { get; set; }





    }
}
