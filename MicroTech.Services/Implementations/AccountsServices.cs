using Microsoft.EntityFrameworkCore;
using MicroTech.Data.Entities;
using MicroTech.Data.Responses;
using MicroTech.Infrastructure.Interfaces.Repository;
using MicroTech.Services.Abstracts;

namespace MicroTech.Services.Implementations
{
    public class AccountsServices : IAccountsServices
    {
        private readonly IRepositoryQuery<Accounts> _AccountsQuery;

        public AccountsServices(IRepositoryQuery<Accounts> accountsQuery)
        {
            _AccountsQuery = accountsQuery;
        }

        public async ValueTask<List<TopLevelAccountResponseDTO>> GetTopLevelAccounts()
        {
            var _Accounts = await GetAccountHierarchyAsync();
            var accountsDTO = new List<TopLevelAccountResponseDTO>();
            foreach (var item in _Accounts)
            {
                decimal totalBalance = 0;
                BuildTotalBalance(item, ref totalBalance);

                accountsDTO.Add(new TopLevelAccountResponseDTO
                {
                    Acc_Number = item.AccNumber.Trim(),
                    TotalBalance = (double)totalBalance,
                    InverseAccParentNavigation = item.InverseAccParentNavigation
                    
                });
            }
            
            return accountsDTO;
        }

        public async ValueTask<List<string>> GetAccountDetalies(string AccNumber)
        {
            var account = await GetAccountHierarchyAsync(AccNumber);
            var detalies = GetParentDetails(AccNumber, account.FirstOrDefault());
            return detalies;
        }



        public async Task<List<Accounts>> GetAccountHierarchyAsync(string accNumber = "0",string? AccParent = null)
        {
            var accounts = _AccountsQuery.TableNoTracking.Where(a => a.AccParent == AccParent && (accNumber != "0" ? a.AccNumber.Trim() == accNumber : true )).ToList();

            foreach (var account in accounts)
            {
                account.InverseAccParentNavigation = await GetAccountHierarchyAsync("0",account.AccNumber);
            }

            return accounts;
        }
        private void BuildTotalBalance(Accounts account, ref decimal totalBalance)
        {
            totalBalance += account.Balance.GetValueOrDefault(0);
            if (account.InverseAccParentNavigation.Any())
            {
                foreach (var child in account.InverseAccParentNavigation)
                {
                    BuildTotalBalance(child, ref totalBalance);
                }
            }
        }

        public List<string> GetParentDetails(string parentAccountNumber,Accounts parentAccount)
        {
            if (parentAccount == null)
            {
                return null;
            }

            var accountDetails = new List<string>();
            BuildAccountPath(parentAccount, parentAccount.AccNumber, accountDetails);
            return accountDetails;
        }
        private void BuildAccountPath(Accounts account, string currentPath, List<string> accountDetails)
        {
            if (!account.InverseAccParentNavigation.Any())
            {
                accountDetails.Add($"{currentPath.Trim()} = {(double)account.Balance}");
            }
            else
            {
                foreach (var child in account.InverseAccParentNavigation)
                {
                    BuildAccountPath(child, $"{currentPath.Trim()}-{child.AccNumber.Trim()}", accountDetails);
                }
            }
        }

    }
}
