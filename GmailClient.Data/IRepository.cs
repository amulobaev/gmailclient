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
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get one by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);

        /// <summary>
        /// Create entity in repository
        /// </summary>
        /// <param name="model"></param>
        void Create(T model);

        /// <summary>
        /// Update entity in repository
        /// </summary>
        /// <param name="model"></param>
        void Update(T model);

        /// <summary>
        /// Delete entity in repository
        /// </summary>
        /// <param name="model"></param>
        void Delete(T model);
    }
}