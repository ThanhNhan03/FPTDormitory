using AutoMapper;
using DormitoryFPT.Models.Domain;
using DormitoryFPT.Models.Dto;
using DormitoryFPT.Models.Dto.HouseDataTransferObject;
using DormitoryFPT.Models.Dto.RoomDataTransferObject;

namespace DormitoryFPT.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Dorm, DormDto>()
           //.ForMember(dest => dest.Floors, opt => opt.MapFrom(src => src.Floors))
           .ReverseMap();

            CreateMap<Floor, FloorDto>()
                //.ForMember(dest => dest.Dorm, opt => opt.MapFrom(src => src.Dorm))
                //.ForMember(dest => dest.Houses, opt => opt.MapFrom(src => src.Houses))
                .ReverseMap();

            CreateMap<House, HouseDto>()
                //.ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor))
                //.ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ReverseMap();

            CreateMap<Room, RoomDto>()
                //.ForMember(dest => dest.House, opt => opt.MapFrom(src => src.House))
                .ReverseMap();

            //House mapping
            CreateMap<AddHouseRequestDto, House>();
            CreateMap<UpdateHouseRequestDto, House>(); 

            //Room mapping
            CreateMap<AddRoomRequestDto, Room>();
            CreateMap<UpdateRoomRequestDto, Room>();
            
        }
    }
}
