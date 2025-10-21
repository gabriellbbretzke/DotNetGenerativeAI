using Microsoft.SemanticKernel.ChatCompletion;

namespace DotnetGenerativeAI.Extensions;

public static class AuthorRoleExtension
{
    public static string Map(this AuthorRole role) => role.Label.ToLower();

    public static AuthorRole Map(this string role) => 
        role switch
        {
            "user" => AuthorRole.User,
            "assistant" => AuthorRole.Assistant,
            "system" => AuthorRole.System,
            "developer" => AuthorRole.Developer,
            "tool" => AuthorRole.Tool,
            _ => AuthorRole.User
        };
}
