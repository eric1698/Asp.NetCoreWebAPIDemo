using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface IContentRepository: IRepositoryBase<Content>
    {
        void UpdatePartial(Content content);
    }
}
