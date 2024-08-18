using AutoShop.Services.ImplementationDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using AutoShop.Infrastructure;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;
using AutoShop.Utility;
using AutoShop.Handlers.BodyTypeHandlers;
using AutoShop.Handlers.EngineTypeHandlers;
using AutoShop.Handlers.FuelTypeHandlers;
using AutoShop.Handlers.TransmissionTypeHandlers;
using AutoShop.Handlers.BrandHandlers;
using AutoShop.Handlers.ModelHandlers;
using AutoShop.Handlers.ImageHandlers;
using AutoShop.Handlers.CarListingHandlers;

#pragma warning disable CS8601 // Possible null reference assignment.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Add authentication services for external logins.
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];
        options.CallbackPath = "/signin-google";
    });

// Add mailing service
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IEngineTypeService, EngineTypeServices>();
builder.Services.AddScoped<ITransmissionTypeService, TransmissionTypeService>();
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();
builder.Services.AddScoped<IBodyTypeService, BodyTypeService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICarListingService, CarListingService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Add MediatR services
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblyContaining<GetAllBrandsHandler>();
    config.RegisterServicesFromAssemblyContaining<GetBrandByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateBrandHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateBrandHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteBrandHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllModelsHandler>();
    config.RegisterServicesFromAssemblyContaining<GetModelByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateModelHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateModelHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteModelHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllEngineTypesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetEngineTypeByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateEngineTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateEngineTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteEngineTypeHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllTransmissionTypesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetTransmissionTypeByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateTransmissionTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateTransmissionTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteTransmissionTypeHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllFuelTypesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetFuelTypeByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateFuelTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateFuelTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteFuelTypeHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllBodyTypesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetBodyTypeByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateBodyTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateBodyTypeHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteBodyTypeHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllImagesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetAllImagesByCarIdHandler>();
    config.RegisterServicesFromAssemblyContaining<GetImageByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateImageHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateImageHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteImageHandler>();

    config.RegisterServicesFromAssemblyContaining<GetAllCarListingsHandler>();
    config.RegisterServicesFromAssemblyContaining<GetPaginatedCarListingsHandler>();
    config.RegisterServicesFromAssemblyContaining<GetTotalPagesHandler>();
    config.RegisterServicesFromAssemblyContaining<GetPaginatedCarListingsForFilteringsHandler>();
    config.RegisterServicesFromAssemblyContaining<GetTotalPagesForFilteringHandler>();
    config.RegisterServicesFromAssemblyContaining<GetCarListingByIdHandler>();
    config.RegisterServicesFromAssemblyContaining<CheckVINExistsHandler>();
    config.RegisterServicesFromAssemblyContaining<CreateCarListingHandler>();
    config.RegisterServicesFromAssemblyContaining<UpdateCarListingHandler>();
    config.RegisterServicesFromAssemblyContaining<DeleteCarListingHandler>();
    config.RegisterServicesFromAssemblyContaining<ArchiveCarListingHandler>();

});

var app = builder.Build();
UserSeeder.SeedUsersAndRolesAsync(app).Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
