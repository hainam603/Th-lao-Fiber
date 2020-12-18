using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Connection.SQLServer
{
    public interface Isqlserver<T> where T:class
    {
        IEnumerable<T> getAll();
        T getById(object id);
        void insert(T obj);
        void update(T obj);
        void delete(object id);
        void save();
    }
}
