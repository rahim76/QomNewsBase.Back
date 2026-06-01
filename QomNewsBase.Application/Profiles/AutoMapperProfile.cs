using AutoMapper;
using QomNewsBase.Application.CQRS;
using QomNewsBase.Application.Utilities;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.Profiles;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region News

        CreateMap<News, CreateNewsCommand>().ReverseMap();
        CreateMap<News, NewsResultDto>()
            .ForMember(dest => dest.Thumbnail, config => config.MapFrom(src => !string.IsNullOrEmpty(src.Thumbnail) ? PathBuilder.GetThumbnailUrl(src.Thumbnail) : string.Empty))
            .ForMember(dest => dest.NewsGroupTitle, config => config.MapFrom(src => src.NewsGroup.Title))
            .ForMember(dest => dest.CreatedAtLocal, config => config.MapFrom(src => new DateAndTimeConverter().ConvertToShamsi(src.CreatedAt)))
            .ForMember(dest => dest.UpdatedAtLocal, config => config.MapFrom(src => src.UpdatedAt != null ? new DateAndTimeConverter().ConvertToShamsi(src.UpdatedAt.Value) : null))
            .ForMember(dest => dest.CommentsCount, config => config.MapFrom(src => src.Comments.Count()))
            .ReverseMap();

        CreateMap<News, MostVisitedResult>()
            .ForMember(dest => dest.Thumbnail, config => config.MapFrom(src => !string.IsNullOrEmpty(src.Thumbnail) ? PathBuilder.GetThumbnailUrl(src.Thumbnail) : string.Empty))
            .ForMember(dest => dest.NewsGroupTitle, config => config.MapFrom(src => src.NewsGroup.Title))
            .ForMember(dest => dest.CreatedAtLocal, config => config.MapFrom(src => new DateAndTimeConverter().ConvertToPersianString(src.CreatedAt)))
            .ForMember(dest => dest.CommentsCount, config => config.MapFrom(src => src.Comments.Count()))
            .ReverseMap();


        CreateMap<News, GetOneNewsQueryResult>()
            .ForMember(dest => dest.Thumbnail, config => config.MapFrom(src => !string.IsNullOrEmpty(src.Thumbnail) ? PathBuilder.GetThumbnailUrl(src.Thumbnail) : string.Empty))
            .ForMember(dest => dest.NewsGroupTitle, config => config.MapFrom(src => src.NewsGroup.Title))
            .ForMember(dest => dest.CreatedAtLocal, config => config.MapFrom(src => new DateAndTimeConverter().ConvertToPersianString(src.CreatedAt)))
            .ForMember(dest => dest.UpdatedAtLocal, config => config.MapFrom(src => src.UpdatedAt != null ? new DateAndTimeConverter().ConvertToShamsi(src.UpdatedAt.Value) : null))
            .ForMember(dest => dest.CommentCount, config => config.MapFrom(src => src.Comments.Count()))
            .ForMember(dest => dest.Comments, config => config.MapFrom(src => src.Comments))
            .ReverseMap();

        #endregion

        #region NewsGroup

        CreateMap<NewsGroup, NewsGroupResultDto>()
            .ForMember(dest => dest.NewsCount, config => config.MapFrom(src => src.News.Count()))
            .ReverseMap();

        #endregion

        #region Comment

        CreateMap<Comment, CommentResultDto>()
            .ForMember(dest => dest.CreatedAtLocal, config => config.MapFrom(src => new DateAndTimeConverter().ConvertToShamsi(src.CreatedAt)))
            .ForMember(dest => dest.UpdatedAtLocal, config => config.MapFrom(src => src.UpdatedAt != null ? new DateAndTimeConverter().ConvertToShamsi(src.UpdatedAt.Value) : null))
            .ForMember(dest => dest.NewsTitle, config => config.MapFrom(src => src.News.Title))
            .ReverseMap();

        CreateMap<Comment, CreateCommentCommand>().ReverseMap();


        #endregion

    }
}