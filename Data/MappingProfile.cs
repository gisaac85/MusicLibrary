using AutoMapper;
using MusicLibrary.Data.DTO;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDTO>().ReverseMap();
            CreateMap<Song, SongEditDTO>().ReverseMap();
            CreateMap<Song, SongDeleteDTO>().ReverseMap();
        }
    }
}
