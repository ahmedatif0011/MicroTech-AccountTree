using MicroTech.Data.Entities;
using MicroTech.Data.Responses;

namespace MicroTech.Services.Abstracts
{
    public interface IAccountsServices
    {
        ValueTask<List<TopLevelAccountResponseDTO>> GetTopLevelAccounts();
        ValueTask<List<string>> GetAccountDetalies(string accountNumber);
    }
}
