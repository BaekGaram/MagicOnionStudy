using Grpc.Net.Client;
using MagicOnion.Client;
using MagicOnion.Unity;
using Shared.Interfaces;
using UnityEngine;

[MagicOnionClientGeneration(typeof(IGamingHub))]
partial class MagicOnionClientInitializer
{
}

class InitialSettings
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void OnRuntimeInitialize()
    {
#if !MAGICONION_USE_GRPC_CCORE
        // Use Grpc.Net.Client instead of C-core gRPC library.
        GrpcChannelProviderHost.Initialize(
            new GrpcNetClientGrpcChannelProvider(() => new GrpcChannelOptions()
            {
                HttpHandler = new Cysharp.Net.Http.YetAnotherHttpHandler()
                {
                    Http2Only = true,
                }
            }));
#endif
#if MAGICONION_USE_GRPC_CCORE
            // Initialize gRPC channel provider when the application is loaded.
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(new GrpcCCoreChannelOptions(new[]
            {
                // send keepalive ping every 5 second, default is 2 hours
                new ChannelOption("grpc.keepalive_time_ms", 5000),
                // keepalive ping time out after 5 seconds, default is 20 seconds
                new ChannelOption("grpc.keepalive_timeout_ms", 5 * 1000),
            })));

            // NOTE: If you want to use self-signed certificate for SSL/TLS connection
            //var cred = new SslCredentials(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "server.crt")));
            //GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(new GrpcCCoreChannelOptions(channelCredentials: cred)));
#endif
    }
}