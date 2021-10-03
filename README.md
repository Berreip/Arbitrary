# Arbitrary

Library used for generating arbitrary values for unit testing. Allow extension for your own type

## Quick start:

#### To generate a value

``` csharp
var value = Arbitraty.GetNew<int>()    
```

#### To generate a range of values:

``` csharp
// generate a range of 12 random int
var value = Arbitraty.GetNewRange<int>(12)    
```

***Static method generation use an internal, immutable default generator*** 

## ArbitraryGeneratorBag:

A default generator bag including every following types is available for usage and modification using ***ArbitratyPredefined*** static class

``` csharp
// retrieve a default generator:
var generator = ArbitratyPredefined.GetDefault();
```

---

### Default generator included types


 - Int
 - Uint
 - Float
 - Long
 - Double
 - String
 - Char
 - Byte
 - Bool
 - DateTime
 - TimeSpan
 - Guid

---
 
You could also retrieve an empty one and populate it:

``` csharp
// retrieve an empty generator:
var emptyGenerator = ArbitratyPredefined.GetEmpty();
```

### Add a specific generator

To add a generator, use the RegisterGenerator method:

``` csharp
// retrieve an empty generator:
var emptyGenerator = ArbitratyPredefined.GetEmpty();
    
// register a default int generator
emptyGenerator.RegisterGenerator(ArbitraryGeneratorPredefined.IntGenerator);
```

it could be chained in a fluent manner:

``` csharp
var generator = ArbitratyPredefined
                  .GetEmpty()                      
                  .RegisterGenerator(ArbitraryGeneratorPredefined.IntGenerator)
                  ...
                  .RegisterGenerator(ArbitraryGeneratorPredefined.DoubleGenerator);
```

***When registering a generator, if a matching type is found, it is overriden***

## Types generators

Types generators inherit from ArbitraryGeneratorBase<T> and define a GetNew<T>.

you could create whatever generator suit your needs
