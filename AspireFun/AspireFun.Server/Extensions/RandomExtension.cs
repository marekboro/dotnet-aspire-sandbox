namespace AspireFun.Server.Extensions;

public static class RandomExtension
{
    public static bool NextBool(this Random random)
    {
        return random.Next(0, 2) == 1;
    }
}