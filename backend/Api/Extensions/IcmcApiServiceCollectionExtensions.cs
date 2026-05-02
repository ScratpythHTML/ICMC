using Services.BelayDevices.Add;
using Services.BelayDevices.Delete;
using Services.BelayDevices.Get;
using Services.BelayDevices.Update;
using Services.Carabiners.Add;
using Services.Carabiners.Delete;
using Services.Carabiners.Get;
using Services.Carabiners.Update;
using Services.Crashpads.Add;
using Services.Crashpads.Delete;
using Services.Crashpads.Get;
using Services.Crashpads.Update;
using Services.Harnesses.Add;
using Services.Harnesses.Delete;
using Services.Harnesses.Get;
using Services.Harnesses.Update;
using Services.Helmets.Add;
using Services.Helmets.Delete;
using Services.Helmets.Get;
using Services.Helmets.Update;
using Services.Quickdraws.Add;
using Services.Quickdraws.Delete;
using Services.Quickdraws.Get;
using Services.Quickdraws.Update;
using Services.Ropes.Add;
using Services.Ropes.Delete;
using Services.Ropes.Get;
using Services.Ropes.Update;
using Services.Users.Add;
using Services.Users.Delete;
using Services.Users.Get;
using Services.Users.Update;

public static class IcmcApiServiceCollectionExtensions
{
    public static IServiceCollection AddIcmcApiServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddBelayDevicesServices()
            .AddCarabinersServices()
            .AddCrashpadsServices()
            .AddHarnessesServices()
            .AddHelmetsServices()
            .AddQuickdrawsServices()
            .AddRopesServices()
            .AddUsersServices();
    }

    public static IServiceCollection AddBelayDevicesServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddBelayDeviceService, AddBelayDeviceService>()
            .AddTransient<IDeleteBelayDeviceService, DeleteBelayDeviceService>()
            .AddTransient<IGetBelayDeviceService, GetBelayDeviceService>()
            .AddTransient<IUpdateBelayDeviceService, UpdateBelayDeviceService>();
    }

    public static IServiceCollection AddCarabinersServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddCarabinerService, AddCarabinerService>()
            .AddTransient<IDeleteCarabinerService, DeleteCarabinerService>()
            .AddTransient<IGetCarabinerService, GetCarabinerService>()
            .AddTransient<IUpdateCarabinerService, UpdateCarabinerService>();
    }

    public static IServiceCollection AddCrashpadsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddCrashpadService, AddCrashpadService>()
            .AddTransient<IDeleteCrashpadService, DeleteCrashpadService>()
            .AddTransient<IGetCrashpadService, GetCrashpadService>()
            .AddTransient<IUpdateCrashpadService, UpdateCrashpadService>();
    }

    public static IServiceCollection AddHarnessesServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddHarnessService, AddHarnessService>()
            .AddTransient<IDeleteHarnessService, DeleteHarnessService>()
            .AddTransient<IGetHarnessService, GetHarnessService>()
            .AddTransient<IUpdateHarnessService, UpdateHarnessService>();
    }

    public static IServiceCollection AddHelmetsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddHelmetService, AddHelmetService>()
            .AddTransient<IDeleteHelmetService, DeleteHelmetService>()
            .AddTransient<IGetHelmetService, GetHelmetService>()
            .AddTransient<IUpdateHelmetService, UpdateHelmetService>();
    }

    public static IServiceCollection AddQuickdrawsServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddQuickdrawService, AddQuickdrawService>()
            .AddTransient<IDeleteQuickdrawService, DeleteQuickdrawService>()
            .AddTransient<IGetQuickdrawService, GetQuickdrawService>()
            .AddTransient<IUpdateQuickdrawService, UpdateQuickdrawService>();
    }

    public static IServiceCollection AddRopesServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddRopeService, AddRopeService>()
            .AddTransient<IDeleteRopeService, DeleteRopeService>()
            .AddTransient<IGetRopeService, GetRopeService>()
            .AddTransient<IUpdateRopeService, UpdateRopeService>();
    }

    public static IServiceCollection AddUsersServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddTransient<IAddUserService, AddUserService>()
            .AddTransient<IDeleteUserService, DeleteUserService>()
            .AddTransient<IGetUserService, GetUserService>()
            .AddTransient<IUpdateUserService, UpdateUserService>();
    }
}
