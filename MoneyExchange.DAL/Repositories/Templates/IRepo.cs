using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyExchange.DAL.Repository.Templates
{
    public interface IRepo<T> : IDisposable
    {
        int Add(T entity);
        List<T> GetAll();
    }
}
