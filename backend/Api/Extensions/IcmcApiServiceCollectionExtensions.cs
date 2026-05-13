using Services.GearItems.Add;
using Services.GearItems.Delete;
using Services.GearItems.Get;
using Services.GearItems.Search;
using Services.GearItems.Update;
using Services.Users.Add;
using Services.Users.Delete;
using Services.Users.Get;
using Services.Users.Search;
using Services.Users.Update;

public static class IcmcApiServiceCollectionExtensions
{
    public static IServiceCollection AddIcmcApiServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddGearItemsServices()
            .AddUsersServices();
    }

    public static IServiceCollection AddGearItemsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddGearItemService, AddGearItemService>()
            .AddTransient<IDeleteGearItemService, DeleteGearItemService>()
            .AddTransient<IGetGearItemService, GetGearItemService>()
            .AddTransient<ISearchGearItemsService, SearchGearItemsService>()
            .AddTransient<IUpdateGearItemService, UpdateGearItemService>();
    }

    public static IServiceCollection AddUsersServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddUserService, AddUserService>()
            .AddTransient<ISearchUsersService, SearchUsersService>()
            .AddTransient<IDeleteUserService, DeleteUserService>()
            .AddTransient<IGetUserService, GetUserService>()
            .AddTransient<IUpdateUserService, UpdateUserService>();
    }
}
