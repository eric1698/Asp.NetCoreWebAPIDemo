using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRepositoryWrapper
    {

        Task<int> SaveChanges();
        IContentRepository Content { get; }
    }
}
