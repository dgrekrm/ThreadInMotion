using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface ICreateService<T> where T : class
    {
        int Create(T entity);
    }
}
