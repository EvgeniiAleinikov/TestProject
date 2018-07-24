using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coop.ViewModels;

namespace Coop.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(BaseContext context) : base(context)
        {
        }

        public bool IsUniqie(HouseModel house)
        {
            var address = house.getAddress();
            return this.DbSet.ToList().FirstOrDefault(u => new HouseModel(u).getAddress() == address) == null;
        }
    }
}