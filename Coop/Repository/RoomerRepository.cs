using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class RoomerRepository : Repository<Roomer>, IRoomerRepository
    {
        public RoomerRepository(BaseContext context) : base(context)
        { }
    }
}