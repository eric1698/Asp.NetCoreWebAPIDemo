using AutoMapper;
using BLL.interfaces;
using IDAL;
using Model;
using Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class ContentBLL : IContentBLL
    {
        IRepositoryWrapper repository;
        IMapper mapper;
        public ContentBLL(IRepositoryWrapper repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Content>> Read()
        {
            return await repository.Content.Reads(m => true);
        }

        public async Task<bool> Inert(ContentCreateViewModel viewModel)
        {
            Content content = mapper.Map<Content>(viewModel);

            repository.Content.Create(content);
            var result = await repository.SaveChanges();
            return result > 0;
        }

        public async Task<bool> Update(ContentUpdateViewModel viewModel)
        {
            Content content = mapper.Map<Content>(viewModel);
            repository.Content.UpdatePartial(content);
            var result = await repository.SaveChanges();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            repository.Content.Delete(id);
            var result = await repository.SaveChanges();
            return result > 0;
        }
    }
}
