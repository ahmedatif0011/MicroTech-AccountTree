using MicroTech.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroTech.Infrastructure.Interfaces
{
    internal interface IUserInformation
    {
        ValueTask<UserInformationModel> GetUserInformation();
    }
}
