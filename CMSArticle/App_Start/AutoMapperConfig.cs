using AutoMapper;
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
                /*t.CreateMap<Student, StudentViewModel>();*/

            });
            mapper = configuration.CreateMapper();
        }
    }
}