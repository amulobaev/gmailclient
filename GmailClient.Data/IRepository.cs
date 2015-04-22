using System;
using System.Collections.Generic;

namespace GmailClient.Data
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        void Create(T model);

        void Update(T model);

        void Delete(T model);
    }
}