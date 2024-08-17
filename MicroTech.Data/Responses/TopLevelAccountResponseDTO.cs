using MicroTech.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTech.Data.Responses
{
    public class TopLevelAccountResponseDTO
    {
        public string Acc_Number { get; set; }
        public double TotalBalance { get; set; }
        public virtual List<Accounts> InverseAccParentNavigation { get; set; } = new List<Accounts>();
    }
}
