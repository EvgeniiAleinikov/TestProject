using Coop.IRepository;
using Coop.Models;
using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(BaseContext context) : base(context)
        { }

        public bool IsValid(NewCompany newData)
        {
            return this.DbSet.FirstOrDefault(p => p.Name == newData.Name) == null;
        }

        public int CreateCompany(Company company, int id)
        {
            if (Context.Managers.Find(id) == null)
            {
                Context.Managers.Add(new Manager { Id = id });
                Role role1 = new Role { Name = "manager", UserProfile = Context.Users.Find(id) };
                Context.Roles.Add(role1);
                Context.SaveChanges();
            }

            company.SetManager(id);
            this.Create(company);

            return DbSet.FirstOrDefault(u => u.Name == company.Name).Id;
        }

        public List<CompanyModel> getCompanyModels()
        {
            var company = new CompanyRepository(new BaseContext()).GetAll().ToList();

            foreach (var item in company)
            {
                new CompanyRepository(new BaseContext()).CollectionLoad(item, "Houses");
            }
            return CompanyModel.GetCompanyModelList(company);
        }

    }
}