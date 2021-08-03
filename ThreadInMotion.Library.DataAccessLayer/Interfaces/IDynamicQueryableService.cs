using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface IDynamicQueryableService<T> where T : class
    {
        IEnumerable<T> GetEntities(string where = null);
    }
}
