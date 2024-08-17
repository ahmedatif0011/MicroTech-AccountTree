using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTech.Core.Handlers.Accounts.Query.Models
{
    public class GetParentDetailsRequest : IRequest<List<string>>
    {
        public string accountNumber { get; set; }
    }
}
