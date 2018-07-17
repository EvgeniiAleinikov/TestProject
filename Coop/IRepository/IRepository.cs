using System;
using System.Collections.Generic;

interface IRepository<TModel> : IDisposable
    where TModel : class
{
    List<TModel> GetAll();
    TModel GetById(int id);
    void Create(TModel item);
    void Delete(TModel item);
    void SaveChanges();
}