namespace Services.Product.Service.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }

    public static EntityNotFoundException FromId(Guid id)
    {
        var message = $"Entity not found !, Id: {id}";
        return new EntityNotFoundException(message);
    }
}
