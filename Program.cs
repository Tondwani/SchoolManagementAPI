
using AlrightAPI.Data;
using AlrightAPI.Interface;
using AlrightAPI.MappingProfiles;
using AlrightAPI.Repository;
using AlrightAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AlrightAPI
{
    public  static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container // Dependency Injection
            builder.Services.AddDbContext<SchoolDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbConnection"));
            });

            // Injecting/Register my IRepository Services in the program.cs for now !! //
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();


            // JWT Authentication Configuration

            var jwtSettings = builder.Configuration.GetSection("JWTSettings"); // Securely accessing the SecretKey


            // Authentication services
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"], //  Who gives the token, In my case it's me(#AlrightAPI) ...Your domian.. where you going to deployed the project
                        ValidAudience = jwtSettings["Audience"], // / Intended recipient of the token()Usually client-side application/consumers of the API(FrontEnd link)
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretKey")) // This is used to sign & validate the JWT, make if it's authentic and hasn't beeen tempered with  
                    };
                });

            builder.Services.AddScoped<JwtService>();
            // Auto Mapper  (Registeration)
            builder.Services.AddAutoMapper(typeof(MappingProfiles.MappingProfile));

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

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
