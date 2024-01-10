namespace Tera.Application.Common.Models;

public class Maybe<T> : ErrorModel where T : notnull
{
    public T Result { get; set; }
}

