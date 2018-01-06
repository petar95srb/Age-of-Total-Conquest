
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AgeOfTotalConquest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
            AutoMapper.Mapper.Initialize(cfg=>
            {

                // AOTC_DomainClasses to UnityClasses
                cfg.CreateMap<AOTC_DomainClasses.User, UnityClasses.User>();
                cfg.CreateMap<AOTC_DomainClasses.UserStat, UnityClasses.UserStat>().
                ForMember(destinationMember => destinationMember.Win,
                    memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Victories)).
                    ForMember(destinationMember=>destinationMember.Loss,
                    memberOptions=>memberOptions.MapFrom(sourceMember =>sourceMember.Losses)).
                    ForMember(destinationMember =>destinationMember.Total,
                    memberOptions =>memberOptions.Ignore());
                cfg.CreateMap<AOTC_DomainClasses.UserBoost, UnityClasses.UserBoost>();
                cfg.CreateMap<AOTC_DomainClasses.UserReinforcement, UnityClasses.UserReinforcement>();
                cfg.CreateMap<AOTC_DomainClasses.UserUnits, UnityClasses.UserUnit>();
                cfg.CreateMap<AOTC_DomainClasses.Unit, UnityClasses.Unit>();
                cfg.CreateMap<AOTC_DomainClasses.Reinforcement, UnityClasses.Reinforcement>();
                cfg.CreateMap<AOTC_DomainClasses.Boost, UnityClasses.Boost>();
                cfg.CreateMap<AOTC_DomainClasses.Message, UnityClasses.Message>().
                ForMember(destinationMember => destinationMember.SenderId,
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.UserId)).
                ForMember(destinationMember => destinationMember.Content,
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Body)).
                ForMember(destinationMember => destinationMember.Date,
                memberOptions => memberOptions.AllowNull()); 
                cfg.CreateMap<AOTC_DomainClasses.FriendRequest, UnityClasses.FriendRequest>().
                ForMember(destinationMember => destinationMember.Date,
                memberOptions => memberOptions.AllowNull());
                cfg.CreateMap<AOTC_DomainClasses.Friendship, UnityClasses.Friendship>().
                ForMember(destinationMember => destinationMember.Date,
                memberOptions => memberOptions.AllowNull());


                //UnityClasses to AOTC_DomainClasses
                cfg.CreateMap<UnityClasses.Boost, AOTC_DomainClasses.Boost>().
                ForMember(destinationMember=>destinationMember.Name,
                memberOptions=>memberOptions.MapFrom(x));
               // cfg.CreateMap<UnityClasses>
            });
        }
    }
}
