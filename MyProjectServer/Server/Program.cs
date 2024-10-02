using MagicOnion.Serialization;
using MagicOnion.Serialization.MemoryPack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// http2 사용 처리 
builder.WebHost.ConfigureKestrel(options =>
{
    // WORKAROUND: Accept HTTP/2 only to allow insecure HTTP/2 connections during development.
    options.ConfigureEndpointDefaults(endpointOptions =>
    {
        endpointOptions.Protocols = HttpProtocols.Http2;
    });
});

MagicOnionSerializerProvider.Default = MemoryPackMagicOnionSerializerProvider.Instance;

// MagicOnion depends on ASP.NET Core gRPC Service.
builder.Services.AddGrpc();
builder.Services.AddMagicOnion(opt =>
{
    // todo : Thinking about how to use this feature.
});

var app = builder.Build();
app.MapMagicOnionService();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine("#### MagicOnionServer Start ####");
});

lifetime.ApplicationStopped.Register(() => { Console.Write("Server app has stopped."); });

// 서버 시작 
app.Run();