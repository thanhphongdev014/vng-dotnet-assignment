namespace Services.Product.Service.Exceptions;

public class InvalidProductQuantityException : BusinessException
{
    public InvalidProductQuantityException(string message) : base(message) { }
}
