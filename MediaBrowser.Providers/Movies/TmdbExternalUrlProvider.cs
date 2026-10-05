using System.Collections.Generic;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.TV;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;

namespace MediaBrowser.Providers.Movies;

/// <summary>
/// External URLs for TMDb.
/// </summary>
public class TmdbExternalUrlProvider : IExternalUrlProvider
{
    /// <inheritdoc/>
    public string Name => "TMDb";

    /// <inheritdoc/>
    public IEnumerable<string> GetExternalUrls(BaseItem item)
    {
        var baseUrl = "https://www.themoviedb.org/";

        if (item is Season season)
        {
            if (season.Series?.TryGetProviderId(MetadataProvider.Tmdb, out var seriesTmdbId) == true)
            {
                if (season.IndexNumber.HasValue)
                {
                    yield return baseUrl + $"tv/{seriesTmdbId}/season/{season.IndexNumber.Value}";
                }
                else
                {
                    yield return baseUrl + $"tv/{seriesTmdbId}/seasons";
                }
            }

            yield break;
        }

        if (item is Episode episode)
        {
            if (episode.Series?.TryGetProviderId(MetadataProvider.Tmdb, out var seriesTmdbId) == true)
            {
                yield return baseUrl + $"tv/{seriesTmdbId}/season/{episode.Season.IndexNumber}/episode/{episode.IndexNumber}";
            }

            yield break;
        }

        if (item.TryGetProviderId(MetadataProvider.Tmdb, out var externalId))
        {
            if (item is Person)
            {
                yield return baseUrl + $"person/{externalId}";
            }
            else if (item is Series)
            {
                yield return baseUrl + $"tv/{externalId}";
            }
            else
            {
                yield return baseUrl + $"movie/{externalId}";
            }
        }
    }
}
