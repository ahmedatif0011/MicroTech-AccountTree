using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace MicroTech.Data.Entities
{
    public class Accounts
    {
        public string AccNumber { get; set; } = null!;

        public string? AccParent { get; set; }

        public decimal? Balance { get; set; }

        public virtual Accounts? AccParentNavigation { get; set; }

        public virtual List<Accounts> InverseAccParentNavigation { get; set; } = new List<Accounts>();
    }
}
