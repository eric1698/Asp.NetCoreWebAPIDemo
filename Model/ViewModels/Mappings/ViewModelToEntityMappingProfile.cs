using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<ContentCreateViewModel, Content>()
                .ForMember(e => e.CreateTime, v => v.MapFrom(vm => DateTime.Now))
                .ForMember(e => e.ModifyTime, v => v.MapFrom(vm => DateTime.Now));

            CreateMap<ContentUpdateViewModel, Content>();
        }
    }
}
