# Caliburn.Micro and MahApps.Metro project template

Project template for [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro) WPF application using [MahApps.Metro](https://github.com/MahApps/MahApps.Metro) windows.

## What it uses

* Caliburn.Micro is the chosen MVVM framework, to bind your ViewModels to your Views. If you're not already using MVVM, use it.
* MahApps.Metro provides a quick and easy way to get a nice-looking application from the start.
* [MahApps.Metro.SimpleChildWindow](https://github.com/punker76/MahApps.Metro.SimpleChildWindow) (referenced but not used) will help you create nice-looking modal popups.
* `IPropertyChanged` notifications are implemented using [Fody.PropertyChanged](https://github.com/Fody/PropertyChanged). Just use `using PropertyChanged;` and add the `[ImplementPropertyChanged]` attribute to your ViewModel classes.
* NLog takes care of logging purposes; see `App.xaml.cs` for a sample usage using `Caliburn.Micro.Logging`.

## How to install

1. Run the `generate.bat` file. It will generate the Visual Studio template using the latest sources.
2. Restart Visual Studio.

The template is now located in new project > Visual C#. You might need to enable Nuget package restore by right clicking on the solution file and selecting `Enable NuGet Package Restore`.

Alternatively, you can use Visual Studio to generate the template :

* Open the CaliburnTemplate solution and make it so it can be built properly.
* Export the project as a template by following the steps under `File` > `Export template`. Choose "project template" and the project CaliburnTemplate, add a name/description/symbol to it and check the `Import template into Visual Studio` option.

## How it works

* A bootstrapper is registered in the `App.xaml` resources
* This bootstrapper then loads the `MasterViewModel` and the `AppWindowManager` through IoC
* The `AppWindowManager` instantiates either the `BaseWindow` or the `BaseDialogWindow`, which use MahApps.Metro
* The `MasterViewModel` is a Caliburn `Conductor`, which means it only "wires" the screens together. By default, it loads the `MainViewModel`.
