using Coop.Models;
using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coop.IRepository
{
    interface ICompanyRepository:IRepository<Company>
    {
        bool IsValid(NewCompany newData);
        void Create(Company company,Manager manager);
    }
}
