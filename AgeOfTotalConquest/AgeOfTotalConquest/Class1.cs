using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace AgeOfTotalConquest
{
    public class AOTC_Mapper : AutoMapper.Mapper
    {
        public AOTC_Mapper(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        public AOTC_Mapper(IConfigurationProvider configurationProvider, Func<Type, object> serviceCtor) : base(configurationProvider, serviceCtor)
        {
        }
    }
}