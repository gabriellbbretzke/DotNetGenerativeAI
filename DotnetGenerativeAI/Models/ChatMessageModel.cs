namespace DotnetGenerativeAI.Models;

public class ChatMessageModel
{
    public Guid Id { get; set; }
    public string Role { get; set; } = "user"; // "user" or "assistant"
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid ChatId { get; set; }
    public ChatModel ChatModel { get; set; } = null!;
}
