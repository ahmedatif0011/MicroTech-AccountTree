using MediatR;
using MicroTech.Core.Handlers.Accounts.Query.Models;
using MicroTech.Data.Responses;
using MicroTech.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTech.Core.Handlers.Accounts.Query
{
    public class GetTopLevelAccountsHandler : 
        IRequestHandler<GetTopLevelAccountsRequest, List<TopLevelAccountResponseDTO>>,
        IRequestHandler<GetParentDetailsRequest, List<string>>
    {
        private readonly IAccountsServices _accountsServices;

        public GetTopLevelAccountsHandler(IAccountsServices accountsServices)
        {
            _accountsServices = accountsServices;
        }

        public async Task<List<TopLevelAccountResponseDTO>> Handle(GetTopLevelAccountsRequest request, CancellationToken cancellationToken)
        {
            return await _accountsServices.GetTopLevelAccounts();
        }

        public async Task<List<string>> Handle(GetParentDetailsRequest request, CancellationToken cancellationToken)
        {
            return await _accountsServices.GetAccountDetalies(request.accountNumber);
        }
    }
}
