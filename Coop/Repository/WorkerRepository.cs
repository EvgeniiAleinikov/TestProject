using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class WorkerRepository : Repository<Worker>, IWorkerRepository
    {
        public WorkerRepository(BaseContext context) : base(context)
        {
        }
    }
}