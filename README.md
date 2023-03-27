[![NuGet Version](https://img.shields.io/nuget/v/Drastic.Flipper.svg)](https://www.nuget.org/packages/Drastic.Flipper/) ![License](https://img.shields.io/badge/License-MIT-blue.svg)

# Drastic.Flipper

Drastic.Flipper is a .NET binding of [Flipper](https://fbflipper.com/), a library to help debug iOS, Android, and React Native layouts. It is currently bound for .NET iOS.

# Setup

- Install the `Drastic.Flipper` nuget
- Initalize the `FlipperProxy` when your Application has started

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
    global::Flipper.FlipperProxy.Shared.InitializeProxy();

    Window = new UIWindow (UIScreen.MainScreen.Bounds);
    ...
```

In MAUI, you can do this in your `MauiProgram.cs`

```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
#if IOS
        global::Flipper.FlipperProxy.Shared.InitializeProxy();
#endif

...
```