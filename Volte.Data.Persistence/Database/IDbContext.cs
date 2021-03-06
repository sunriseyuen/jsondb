﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Volte.Data.Dapper
{
    public interface IDbContext : IDisposable
    {
        bool Writeable { get; set; }
        string DbName { get; }
        int CommandTimeout { get; set; }
        void Open(string _DbName);
        void Close();
        void BeginTransaction();
        void Commit();
        void RollBack();
        Task<int> AddNew<T>(IDataObject entity) where T : class, new();
        Task<int> Update<T>(IDataObject entity) where T : class, new();
        Task<int> Delete<T>(IDataObject entity) where T : class, new();
        Task<IEnumerable<T>> Query<T>() where T : class;
        Task<T> SingleOrDefault<T>() where T : class;
    }
}
