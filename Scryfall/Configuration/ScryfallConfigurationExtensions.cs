using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scryfall.Domain;
using Scryfall.Domain.Services;
using Scryfall.Infrastructure;

namespace Scryfall.Configuration;

public static class ScryfallConfigurationExtensions
{
    public static void UseScryfall(this IServiceCollection services, IConfiguration configuration)
    {
        var scryfallConfiguration = configuration.GetSection(nameof(ScryfallConfiguration)).Get<ScryfallConfiguration>();

        UseScryfall(services, scryfallConfiguration);
    }

    public static void UseScryfall(this IServiceCollection services, ScryfallConfiguration? scryfallConfiguration)
    {
        if(scryfallConfiguration == null)
            throw new ArgumentNullException(nameof(scryfallConfiguration));

        //Configuration
        services.Configure<ScryfallClientConfiguration>(config =>
        {
            config.BaseUrl = scryfallConfiguration.ScryfallClientConfiguration?.BaseUrl;
        });

        //Services
        services.AddHttpClient();
        services.TryAddScoped<IScryfallClient, ScryfallClient>();
        services.TryAddScoped<ICatalogService, CatalogService>();
        services.TryAddScoped<ISymbologyService, SymbologyService>();
        services.TryAddScoped<IRulingsService, RulingsService>();
        services.TryAddScoped<ISetService, SetService>();
        services.TryAddScoped<ICardService, CardService>();
    }
}