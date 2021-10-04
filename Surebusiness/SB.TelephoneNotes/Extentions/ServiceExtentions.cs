using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SB.TelephoneNotes.BLL.Services;
using SB.TelephoneNotes.DAL.EF.Repositories;
using SB.TelephoneNotes.BLL.Interfaces;
using SB.TelephoneNotes.DAL.EF;
using Microsoft.EntityFrameworkCore;
using SB.TelephoneNotes.DAL.Interfaces;
using FluentValidation;
using SB.TelephoneNotes.BLL.Interfaces.Commands;
using SB.TelephoneNotes.BLL.Validators;

namespace SB.TelephoneNotes.Api.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreatePhoneNote>, CreatePhoneNoteValidator>();
            return services;
        }
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services
                .AddSwaggerDocument(c =>
                {
                    c.PostProcess = document =>
                    {
                        document.Info.Version = "v1";
                        document.Info.Title = "Surebusiness Telefoonnotities API";
                        document.Info.Description = ".NET Core Web API voor het beheren van Telefoonnotities";
                        document.Info.TermsOfService = "None";
                    };
                })
                .AddRouting(options => options.LowercaseUrls = true);

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddScoped<IPersistPhoneNotesService, PersistPhoneNotesService>()
               .AddScoped<IQueryPhoneNotesService, QueryPhoneNotesService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var phoneNotesConnectionString = configuration.GetConnectionString("PhoneNotes");
            services
                .AddDbContext<PhoneNotesDbContext>(options =>
                {
                    options.UseSqlServer(phoneNotesConnectionString);
                });

            services
               .AddScoped<INotesRepository,NotesRepository>();

            return services;
        }
    }
}
