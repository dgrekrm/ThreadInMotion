using System.Collections.Generic;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface IReadService<T> where T : class
    {
        IEnumerable<T> Read(string where = null);
    }
}
