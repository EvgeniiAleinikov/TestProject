using Coop.IRepository;
using Coop.Models;
using Coop.ViewModels;
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

        public RoomerModel getRoomerModel(int userId)
        {
            var roomer = Context.Roomers
                .Find(userId);

            Context.Entry(roomer).Reference("House").Load();
            Context.Entry(roomer).Reference("UserProfile").Load();
            Context.Entry(roomer.House).Collection("Workers").Load();
            foreach (var item in roomer.House.Workers)
            Context.Entry(item).Collection("Tasks").Load();

            RoomerModel model = new RoomerModel(roomer);

            return model;
        }
    }
}