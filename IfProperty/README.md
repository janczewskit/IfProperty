# IfProperty
==========
*.NET library for building attributes based validation rules*

This library add few useful validation attributes.

_Validation expressions:_
+ Is
+ EqualTo
+ GreaterThan
+ GreaterThanOrEqualTo
+ In
+ LessThan
+ LessThanOrEqualTo
+ NotEqualTo
+ Not in
+ Not Regex
+ Regex

_Custom required validators:_
+ RequiredIf
+ RequiredIfNotNull

## Installation
**NuGet:** _install-package_ [IfProperty](https://www.nuget.org/packages/IfProperty "IfProperty nuget package URL")
**no setup needed**
**Good practice** - Add using static IfProperty.IsOperatorEnumeration; on top of file.

## Examples

Equality
```csharp
using static IfProperty.IsOperatorEnumeration;

private class Model
{
    // Value of property Value2 equals constant value "test" verification
    [Is(EqualTo, Value = "test")]
    public string Value2 { get; set; }
}
        
private class Model
{
    public string Value1 { get; set; }
    
    // Value of property Value2 equal to value of property Value1 verification 
    [Is(EqualTo, Property = nameof(Value1), PassOnNull = true)]
    public string Value2 { get; set; }
}

private class Model
{
    public string Value1 { get; set; }
    
    // Value of property Value2 equal to value of property Value1 verification
    // PassOnNull - if both options are null -> true, if one is not null -> false
    [Is(EqualTo, Property = nameof(Value1), PassOnNull = true)]
    public string Value2 { get; set; }
}

private class Model
{
    public string Value1 { get; set; }
    
    // Value of property Value2 not equal to value of property Value1 verification
    [Is(NotEqualTo, Property = nameof(Value1), PassOnNull = true)]
    public string Value2 { get; set; }
}
```

GreaterThan/LessThan
```csharp
using static IfProperty.IsOperatorEnumeration;

private class Model
{
    // Value of property is greater than 1
    [Is(GreaterThan, Value = 1)]
    public int? Value1 { get; set; }
    
    // Value of property is greater than or equal to 1
    [Is(GreaterThan, Value = 1)]
    public int? Value2 { get; set; }
    
    //Value of property is less than 1
    [Is(LessThan, Value = 1)]
    public int? Value3 { get; set; }
    
    // Value of property is less than or equal to 1
    [Is(LessThanOrEqualTo, Value = 1)]
    public int? Value4 { get; set; }
    
    // Value of property is less than 1 or null
    [Is(LessThan, Value = 1, PassOnNull = true)]
    public int? Value5 { get; set; }
}
```

In/Not in
```csharp
using static IfProperty.IsOperatorEnumeration;

private class Model
{
    public string[] Value1 { get; set; }

    // Value of property Value2 is in Value1 array values or both values are null
    [Is(In, Property = nameof(Value1), PassOnNull = true)]
    public string Value2 { get; set; }
    
    // Value of property Value is in {"testStaticValue", "testStaticValue2" }
    [Is(In, Value = new [] {"testStaticValue", "testStaticValue2" })]
    public string Value { get; set; }
}
```

Regex
```csharp
using static IfProperty.IsOperatorEnumeration;

private class Model
{
    // Value of property Value is match email regex. If value is invalid validator return custom message.
    [Is(RegExMatch, Value = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", CustomMessage = "Format of the email address isn't correct")]
    public string Value { get; set; }
    
    // Value of property Value2 isn't match email regex
    [Is(NotRegExMatch, Value = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Value2 { get; set; }
}
```

Add custom expression attribute
```csharp
using static IfProperty.IsOperatorEnumeration;

// Register expression
// Important! Container and System.ComponentModel.DataAnnotations.Validator are static class.
// If you want to be sure that a custom expression will be used, you should register it on startup 
IfPropertyExpressionsContainer.AddOrOverride("invalid", new CustomInvalidPropertyExpression());

// Custom validator
private class CustomInvalidPropertyExpression : IIfPropertyExpression
{
    public string ErrorMessage => "invalid";

    public bool IsValid(object value, object dependentValue)
    {
        return false;
    }
}

// Override existing expression
IfPropertyExpressionsContainer.AddOrOverride(EqualTo, new CustomInvalidPropertyExpression());
```