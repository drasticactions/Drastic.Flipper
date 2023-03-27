[![NuGet Version](https://img.shields.io/nuget/v/Drastic.Flipper.svg)](https://www.nuget.org/packages/Drastic.Flipper/) ![License](https://img.shields.io/badge/License-MIT-blue.svg)

# Drastic.Flipper

Drastic.Flipper is a .NET binding of [Flipper](https://fbflipper.com/), a library to help debug iOS, Android, and React Native layouts. This binding supports .NET iOS and Android.

## Setup

- Install the `Drastic.Flipper` nuget
- Initalize the `FlipperProxy` when your Application has started

For iOS, you can do this in your AppDelegate...

```csharp
public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
{
    global::Flipper.FlipperProxy.Shared.InitializeProxy();

    Window = new UIWindow (UIScreen.MainScreen.Bounds);
    ...
```

In MAUI, you can do also this in your `MauiProgram.cs`

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

For Android, MAUI UI or Native, you should initialize it in your main Application, 'OnCreate'

```csharp
    public override void OnCreate()
    {
        base.OnCreate();
        Com.Facebook.Soloader.SoLoader.Init(this.ApplicationContext, false);
        var androidClient = Com.Facebook.Flipper.Android.AndroidFlipperClient.GetInstance(this.ApplicationContext);
        var flipperPlugin = new Com.Facebook.Flipper.Plugins.Inspector.InspectorFlipperPlugin(this.ApplicationContext, Com.Facebook.Flipper.Plugins.Inspector.DescriptorMapping.WithDefaults());
        androidClient.AddPlugin(flipperPlugin);
        androidClient.Start();
    }
...
```

## Note for Android

The default .NET Android SDK location is not the same as it can be for what Android Studio sets up. Check your Flipper Desktop app and make sure that the SDK is set to the one you use for .NET, or else your apps will not appear in the UI.