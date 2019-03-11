using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class RemoveViewModel
    {
        public int Id { get; set; }
        public List<ApplicationUser> User { get; set; }

        public RemoveViewModel(List<ApplicationUser> users)
        {
            User = users;
            foreach (var user in users)
            {
                Id = user.Id;
            }
        }
    }
}
