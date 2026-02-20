using AspireFun.Server.Extensions;

namespace AspireFun.Server.Models;

public record TestResponse(string TestMessage, int TestNumber, bool TestBool)
{
    public static TestResponse CreateTestResponse() 
    {
        var random1 = Random.Shared.Next(0, 10);
        var random2 = Random.Shared.Next(0, 10);
        var message = $"Hello {random1}";
        var randomBool = Random.Shared.NextBool();
        return new TestResponse(message, random2, randomBool);
    }
};