using Coop.IRepository;
using Coop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(BaseContext context) : base(context)
        {
        }
    }
}