using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface IUpdateService<T> where T : class
    {
        void Update(T entity);
    }
}
