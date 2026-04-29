using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Champerof.Infra;
using Champerof.ServiceRepository.MenuAccessRepository;
using Champerof.ServiceRepository.MenuRepository;
using Champerof.ServiceRepository.RoleRepository;
using Champerof.ServiceRepository.UserRepository;
using Microsoft.AspNetCore.DataProtection;
using Champerof.ServiceRepository.ChangePasswordRepository;
using Champerof.ServiceRepository.LovRepository;
using Champerof.ServiceRepository.UserDemoRepository;
using Champerof.ServiceRepository.PropertyRepository;
using Champerof.ServiceRepository.ClientRepository;
using Champerof.ServiceRepository.ServiceRepository;
using Champerof.ServiceRepository.InvoiceRepository;
using Champerof.ServiceRepository.AdvancePaymentRepository;
using Champerof.ServiceRepository.PaymentRepository;
using Champerof.ServiceRepository.InvoiceItemRepository;
using Champerof.ServiceRepository.PaymentFollowUpRepository;
using Champerof.ServiceRepository.TermsRepository;
using Champerof.ServiceRepository.CompanyRepository;
using Champerof.ServiceRepository.InvoiceReportRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//for CROS_Po
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
          builder.AllowAnyOrigin()
      //  builder.WithOrigins("http://localhost:3000")
                 .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataProtection();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.Key);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero //For Removie extra 5 Minutes
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChamperofAPI", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token.\nExample: Bearer abcdef12345"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuAccessRepo, MenuAccessRepo>();
builder.Services.AddScoped<IChangePasswordRepository, ChangePasswordRepository>();
builder.Services.AddScoped<ILovRepository, LovRepository>();
builder.Services.AddScoped<ValidationService>();

builder.Services.AddScoped<IUserDemoRepository, UserDemoRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IAdvancePaymentRepository,AdvancePaymentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddScoped<IPaymentFollowUpRepository,PaymentFollowUpRepository>();
builder.Services.AddScoped<ITermsRepository,TermsRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IInvoiceReportRepository,InvoiceReportRepository>();



builder.Services.AddSwaggerGen();

var app = builder.Build();

AppHttpContextAccessor.Configure(
    app.Services.GetRequiredService<IHttpContextAccessor>(),
    app.Services.GetRequiredService<IHostEnvironment>(),
    app.Services.GetRequiredService<IWebHostEnvironment>(),
    app.Services.GetRequiredService<IDataProtectionProvider>(),
    app.Configuration,
    app.Services.GetRequiredService<IHttpClientFactory>()
);


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger(); // for live index
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommmonProject v1");
   // c.RoutePrefix = string.Empty; // ?? IMPORTANT
});


app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
//app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok("OK")); // new add simple liveness probe
app.MapControllers();

app.Run();
