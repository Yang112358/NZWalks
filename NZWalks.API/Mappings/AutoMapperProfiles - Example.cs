//using AutoMapper;

//namespace NZWalks.API.Mappings
//{
//    public class AutoMapperProfiles : Profile
//    {
//        public AutoMapperProfiles() 
//        {
//            CreateMap<UserDTO, UserDomain>();
//            CreateMap<UserDTO, UserDomain>()
//                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FUllName))
//                .ReverseMap();
//        }
//    }

//    public class UserDTO
//    {
//        public string FUllName { get; set; }
//    }

//    public class UserDomain
//    {
//        public string Name { get; set; }
//    }
//}
