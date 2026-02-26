namespace AspireFun.Server.Models;

public enum AccountType
{
    Unknown, // setting unknown here as 0 might prevent deserialization issue later where wrong/missing values default to 0 and result in an actual type.
    SmallFish,
    BigFish
};