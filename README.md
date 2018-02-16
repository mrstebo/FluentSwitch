# FluentSwitch
Inspired by Ruby syntax for returning a value from a switch statement

[![Build status](https://ci.appveyor.com/api/projects/status/a5eaiaxk8s2skn0r/branch/master?svg=true)](https://ci.appveyor.com/project/mrstebo/fluentswitch/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/FluentSwitch/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/FluentSwitch?branch=master)
[![NuGet](http://img.shields.io/nuget/v/FluentSwitch.svg?style=flat)](https://www.nuget.org/packages/FluentSwitch/)

This package is available via install the [NuGet](https://www.nuget.org/packages/FluentSwitch):

```powershell
Install-Package FluentSwitch
```

## Basic usage

In Ruby you can assign a variable based off of the result of a switch statement, like so:

```ruby
my_value = 7

my_variable = case my_value
  when 1
    "Not this one?"
  when 7
    "Dang!"
  else
    "David Brent"
end

p my_variable # Outputs: Dang!
```


This package adds a similar behaviour by chaining methods:

_Enums_
```cs
public enum MyTestEnum
{
    Value1,
    Value2
}
```

_The code_
```cs
const MyTestEnum myEnum = MyTestEnum.Value2;

var result = myEnum.Switch()
    .When(MyTestEnum.Value1, () => "Not this one?")
    .When(MyTestEnum.Value2, () => "Dang!")
    .Else("David Brent")
    .Value();

Console.WriteLine(result); // Outputs: Dang!
```
