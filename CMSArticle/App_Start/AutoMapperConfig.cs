using AutoMapper;
using CMS.ModelLayer;
using CMSArticle.Views.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                t.CreateMap<CategoryViewModel,Category >().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<ArticleViewModel, Article>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<Article, ArticleViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            });
            mapper = configuration.CreateMapper();
        }
    }
}