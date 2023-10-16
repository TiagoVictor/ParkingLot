namespace Application;

public enum ErrorCodes
{
    // Car ErrorCode 1 to 99
    CAR_INVALID_PLATE = 1,
    CAR_INVALID_MODEL = 2,
    CAR_INVALID_MANUFACTURER = 3,
    CAR_COULD_NOT_SAVE = 4,
    CAR_COULD_NOT_UPDATE = 5,
    CAR_NOT_FOUND = 6,
}

public abstract class Response
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ErrorCodes ErrorCodes { get; set; }
}
