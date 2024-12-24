using AutoMapper;
using DigitalKeyMarket.BL.Mappers;

namespace DigitalKeyMarket.BL.UnitTests;

public static class Utils
{
    public static IMapper Mapper { get; }

    static Utils()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(UsersBLProfile)));
        Mapper = new Mapper(config);
    }
}