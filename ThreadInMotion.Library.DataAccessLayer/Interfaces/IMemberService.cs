using System;
using System.Collections.Generic;
using System.Text;
using ThreadInMotion.Library.SharedModels.Models;

namespace ThreadInMotion.Library.DataAccessLayer.Interfaces
{
    public interface IMemberService : ICreateService<Member>, IReadService<Member>
    {
    }
}
