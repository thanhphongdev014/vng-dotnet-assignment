namespace Services.Product.Service.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}
