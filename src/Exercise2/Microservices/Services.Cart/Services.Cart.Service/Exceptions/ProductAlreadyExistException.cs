namespace Services.Product.Service.Exceptions;

public class ProductAlreadyExistException : BusinessException
{
    public ProductAlreadyExistException(string message) : base(message) { }
}
