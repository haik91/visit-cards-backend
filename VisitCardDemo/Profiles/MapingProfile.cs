using AutoMapper;
using VisitCardDemo.Entities;
using VisitCardDemo.Models;

namespace VisitCardDemo.Profiles
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            /// get mapping
            CreateMap<VisitCard, GetVisitCard>()
           .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
               src.Image != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(src.Image)}" : null));

            CreateMap<GetVisitCard, VisitCard>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src =>
                    !string.IsNullOrEmpty(src.Image) ? ConvertFromBase64String(src.Image) : null));

            /// post mapping
            CreateMap<PostVisitCard, VisitCard>()
           .ForMember(dest => dest.Image, opt => opt.Ignore());


            /// update mapping
            CreateMap<UpdateVisitCard, VisitCard>()
           .ForMember(dest => dest.Image, opt => opt.Ignore());
        }

        private byte[] ConvertFromBase64String(string base64String)
        {
            var base64Data = base64String.Substring(base64String.IndexOf(',') + 1);
            return Convert.FromBase64String(base64Data);
        }
    }
}
