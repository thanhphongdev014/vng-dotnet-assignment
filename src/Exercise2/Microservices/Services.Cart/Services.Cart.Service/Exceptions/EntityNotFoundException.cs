namespace Services.Product.Service.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }

    public static EntityNotFoundException FromId(Guid id, string entity)
    {
        var message = $"Entity {entity} not found !, Id: {id}";
        return new EntityNotFoundException(message);
    }
}
