using System.Reflection;

namespace PrintManager.Domain.Common.Models;

public abstract class Enumeration : IComparable
{
    private readonly int _code;
    private readonly string _value;

    public int Code => _code;

    public string Value => _value;

    public string Description { get; } = string.Empty;

    protected Enumeration(int code, string value, string description = "") => 
        (_code, _value, Description) = (code, value, description);

    public override string ToString() => Value;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration, new() =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = _code.Equals(otherValue.Code);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object other) => 
        Code.CompareTo(((Enumeration)other).Code);

    public override int GetHashCode() =>
        _code.GetHashCode();
}
