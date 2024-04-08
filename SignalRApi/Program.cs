using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFreamework;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//SignalR Hubs Cors konfigrasyon in�as� bu �ekilde.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()//Bu y�ntem, gelen istekteki t�m ba�l�klar�n (headers) kabul edilmesine izin verir. Yani, iste�in herhangi bir ba�l��a (header) sahip olmas�na izin verir.
        .AllowAnyMethod()//Bu y�ntem, HTTP iste�inin herhangi bir HTTP y�ntemini (GET, POST, PUT, DELETE, vb.) kullanmas�na izin verir. Yani, t�m HTTP y�ntemlerini kabul eder.
        .SetIsOriginAllowed((host => true))//t�m k�kenlere izin verir.
        .AllowCredentials();//Bu, �zellikle kimlik do�rulamas� gerektiren durumlarda �nemlidir.
    });
});
builder.Services.AddSignalR();//SignalR Hubs Cors in�a edildikten sonra bu �ekilde ekleme yap
builder.Services.AddDbContext<SignalRContext>();//Database Ekleme i�lemi
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//AutoMapper i�in konfigrasyon

//ApiController tan�mland�ktan sonra serviceler,managerler,dal ve efler buraya ge�ildi
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();
builder.Services.AddScoped<IDiscountService, DiscountManager>();

builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();

builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();
builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();

builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();
builder.Services.AddScoped<IMenuTableService, MenuTableManager>();

builder.Services.AddScoped<ISliderDal, EfSliderDal>();
builder.Services.AddScoped<ISliderService, SliderManager>();

builder.Services.AddScoped<IBasketDal, EfBasketDal>();
builder.Services.AddScoped<IBasketService, BasketManager>();

builder.Services.AddScoped<INotificationDal, EfNotificationDal>();
builder.Services.AddScoped<INotificationService, NotificationManager>();

//�� i�e json hatas�
builder.Services.AddControllersWithViews()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");//CorsPolicy buraya ge�

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");//Signalrhub taraf�na istek atma i�lemi yapar�z burada.

app.Run();
