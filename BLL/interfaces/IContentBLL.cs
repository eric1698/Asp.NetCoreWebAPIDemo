using Model;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.interfaces
{
    public interface IContentBLL
    {
        Task<IEnumerable<Content>> Read();

        Task<bool> Inert(ContentCreateViewModel viewModel);

        Task<bool> Update(ContentUpdateViewModel viewModel);

        Task<bool> Delete(int id);
    }
}
