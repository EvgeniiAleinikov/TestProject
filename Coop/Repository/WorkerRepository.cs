using Coop.IRepository;
using Coop.Models;
using Coop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(BaseContext context) : base(context)
        { }

        public WorkerModel getWorkerModel(int userId)
        {
            var roomer = Context.Workers
                .Find(userId);

            Context.Entry(roomer).Reference("House").Load();
            Context.Entry(roomer).Collection("Tasks").Load();
            foreach (var item in roomer.Tasks)
            Context.Entry(item).Collection("Roomer").Load();

            WorkerModel model = new WorkerModel(roomer);

            return model;
        }
    }
}