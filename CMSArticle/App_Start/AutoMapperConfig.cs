using AutoMapper;
using CMS.ModelLayer;
using CMSArticle.Views.ViewModel;

namespace CodeFirst_EF.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void Configuration()
        {
            MapperConfiguration configuration = new MapperConfiguration(t =>
            {
                t.CreateMap<Category, CategoryViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<CategoryViewModel, Category>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<ArticleViewModel, Article>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<Article, ArticleViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<CommentViewModel,Comment >().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<Comment, CommentViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            });
            mapper = configuration.CreateMapper();
        }
    }
}