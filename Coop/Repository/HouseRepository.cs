using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(BaseContext context) : base(context)
        {
        }
    }
}