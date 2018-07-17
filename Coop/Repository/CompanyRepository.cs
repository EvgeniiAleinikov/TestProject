using Coop.IRepository;
using Coop.Models;
using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(BaseContext context) : base(context)
        { }

        public bool IsValid(NewCompany newData)
        {
            return this.DbSet.FirstOrDefault(p => p.Name == newData.Name) == null;
        }

        public void Create(Company company,Manager user)
        {
            company.SetManager(user);
            this.Create(company);
        }
    }
}