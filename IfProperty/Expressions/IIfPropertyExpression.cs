namespace IfProperty.Expressions
{
    public interface IIfPropertyExpression
    {
        string ErrorMessage { get; }
        bool IsValid(object value, object dependentValue);
    }
}