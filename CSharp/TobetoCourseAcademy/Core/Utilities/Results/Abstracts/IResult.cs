namespace Core.Utilities.Results.Abstracts
{
    /// <summary>
    /// Temel voidler için başlangıç
    /// </summary>
    public interface IResult
    {
        //Sadece okunabilir get;
        bool Success { get; }
        string Message { get; }
    }
}
