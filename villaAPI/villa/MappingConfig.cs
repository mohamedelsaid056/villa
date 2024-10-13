using AutoMapper;
using villa.DTO;
using villa.Models;


namespace villa
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // mapping between villa and villa and DTO 
            CreateMap<Models.villa, villaDTO>().ReverseMap();

        }

    }
}

//using AutoMapper;

//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        // Example mapping
//        CreateMap<SourceModel, DestinationModel>();
//        // Add more mappings here
//    }
//}
