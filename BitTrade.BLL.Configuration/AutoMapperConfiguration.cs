using AutoMapper;
using BitTrade.Common.Models;
using BitTrade.DAL;

namespace BitTrade.BLL.Configuration
{
    public static class AutoMapperConfiguration
    {

        private static Mapper _mapper;

        public static Mapper Instance
        {
            get
            {
                if (_mapper == null)
                {
                    Register();
                }

                return _mapper;
            }
        }

        public static void Register()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<User, AccountModel>();
                cfg.CreateMap<RegisterModel, User>();
            });

            _mapper = new Mapper(config);
        }
    }
}
