// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

// WAJIB: Matikan semua logging bawaan .NET agar tidak mengganggu STDIO MCP
builder.Logging.ClearProviders();
// MCP server memakai transport stdio (standar MCP)
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

await builder.Build().RunAsync();