using AutoMapper;
using MusicLibrary.Data.DTO;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SongDTO, Song>();
            CreateMap<Song, SongDTO>();
        }
    }
}
