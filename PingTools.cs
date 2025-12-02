using ModelContextProtocol.Server;

[McpServerToolType]
public static class PingTools
{
    [McpServerTool]
    public static string Ping(string message)
    {
        return $"PONG: {message}";
    }
}
