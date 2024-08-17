using MediatR;
using MicroTech.Data.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTech.Core.Handlers.Accounts.Query.Models
{
    public class GetTopLevelAccountsRequest : IRequest<List<TopLevelAccountResponseDTO>>
    {
    }
}
