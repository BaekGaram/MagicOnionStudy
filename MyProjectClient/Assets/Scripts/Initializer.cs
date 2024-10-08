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
        // Use Grpc.Net.Client instead of C-core gRPC library.
        GrpcChannelProviderHost.Initialize(
            new GrpcNetClientGrpcChannelProvider(() => new GrpcChannelOptions()
            {
                HttpHandler = new Cysharp.Net.Http.YetAnotherHttpHandler()
                {
                    Http2Only = true,
                }
            }));
    }
}