using Emby.Server.Implementations;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Server.Migrations.PreStartupRoutines;

/// <inheritdoc />
#pragma warning disable CS0618 // Type or member is obsolete
[JellyfinMigration("2025-04-20T02:00:00", nameof(MigrateMusicBrainzTimeout), "A6DCACF4-C057-4Ef9-80D3-61CEF9DDB4F0", Stage = Stages.JellyfinMigrationStageTypes.PreInitialisation)]
public class MigrateMusicBrainzTimeout : IMigrationRoutine
#pragma warning restore CS0618 // Type or member is obsolete
{
    private readonly ServerApplicationPaths _applicationPaths;
    private readonly ILogger<MigrateMusicBrainzTimeout> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MigrateMusicBrainzTimeout"/> class.
    /// </summary>
    /// <param name="applicationPaths">An instance of <see cref="ServerApplicationPaths"/>.</param>
    /// <param name="loggerFactory">An instance of the <see cref="ILoggerFactory"/> interface.</param>
    public MigrateMusicBrainzTimeout(ServerApplicationPaths applicationPaths, ILoggerFactory loggerFactory)
    {
        _applicationPaths = applicationPaths;
        _logger = loggerFactory.CreateLogger<MigrateMusicBrainzTimeout>();
    }

    /// <inheritdoc />
    public void Perform()
    {
        return;
    }

#pragma warning disable
    public sealed class OldMusicBrainzConfiguration
    {
        private string _server = string.Empty;

        private long _rateLimit = 0L;

        public string Server
        {
            get => _server;
            set => _server = value.TrimEnd('/');
        }

        public long RateLimit
        {
            get => _rateLimit;
            set => _rateLimit = value;
        }

        public bool ReplaceArtistName { get; set; }
    }
}
