using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface IBookService : ICreateService<Book>, IReadService<Book>
    {
    }
}
