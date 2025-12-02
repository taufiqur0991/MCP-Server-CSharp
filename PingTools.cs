using ModelContextProtocol.Server;

[McpServerToolType]
public static class PingTools
{
    [McpServerTool]
    public static string Ping(string host)
    {
        return $"PONG: {host}";
    }
}
