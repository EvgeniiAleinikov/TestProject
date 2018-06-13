using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(BaseContext context) : base(context)
        {
        }
    }
}