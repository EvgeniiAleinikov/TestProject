using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop.Repository
{
    public class Repository<TModel>:BaseRepository<BaseContext,TModel> where TModel:class
    {
        public Repository(BaseContext context): base(context)
        {
        }
    }
}