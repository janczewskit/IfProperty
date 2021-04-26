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

class SetStatusCommand
{
    // Value of property equals constant value true verification
    [Is(EqualTo, Value = true)]
    public string IsSuccess { get; set; }
}
        
class SetNewPasswordCommand
{
    [Required]
    public string Password { get; set; }
    
    // Value of property RepeatedPassword equal to value of property Password verification 
    [Is(EqualTo, Property = nameof(Password)]
    public string RepeatedPassword { get; set; }
}

class SetOrClearPasswordCommand
{
    public string Password { get; set; }
    
    // Value of property RepeatedPassword equal to value of property Password verification
    // PassOnNull - if both options are null -> true, if one is not null -> false
    [Is(EqualTo, Property = nameof(Password), PassOnNull = true)]
    public string RepeatedPassword { get; set; }
}

class ChangePasswordCommand
{
    public string OldPassword { get; set; }
    
    // Value of property NewPassword not equal to value of property OldPassword verification
    [Is(NotEqualTo, Property = nameof(OldPassword), PassOnNull = true)]
    public string NewPassword { get; set; }
}
```

GreaterThan/LessThan
```csharp
using static IfProperty.IsOperatorEnumeration;

class AddBuildingCommand
{

    // Value of property is greater than 1
    [Is(GreaterThan, Value = 1)]
    public int? UsableArea { get; set; }
    
    // Value of property is greater than or equal to 1
    [Is(GreaterThanOrEqual, Value = 1)]
    public int? BuildingArea { get; set; }
    
    //Value of property is less than 200
    [Is(LessThan, Value = 200)]
    public int? BuiltUpArea { get; set; }
    
    // Value of property is less than or equal to 4000
    [Is(LessThanOrEqualTo, Value = 4000)]
    public int? BuildingPlot { get; set; }
    
    // Value of property is less than int.MaxValue or null
    [Is(LessThan, Value = int.MaxValue, PassOnNull = true)]
    public int? NumberOfFloors { get; set; }
}
```

In/Not in
```csharp
using static IfProperty.IsOperatorEnumeration;

class GroupAffiliationCommand
{
    public string[] AvailableTypes { get; set; }

    // Value of property CurrentType is in AvailableTypes array values or both values are null
    [Is(In, Property = nameof(AvailableTypes), PassOnNull = true)]
    public string CurrentType { get; set; }
    
    // Value of property AffiliationType is in {"full", "temporal" }
    [Is(In, Value = new [] {"full", "temporal"})]
    public string AffiliationType  { get; set; }
}
```

Regex
```csharp
using static IfProperty.IsOperatorEnumeration;

class AddUserCommand
{
    // Value of property Email is match email regex. If value is invalid validator return custom message.
    [Is(RegExMatch, Value = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", CustomMessage = "Format of the email address isn't correct")]
    public string Email { get; set; }
    
    // Value of property Domain isn't match google.com domain
    [Is(NotRegExMatch, Value = @"(\w)+\.google\.com")]
    public string Domain { get; set; }
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