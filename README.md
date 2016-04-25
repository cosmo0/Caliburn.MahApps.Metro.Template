# Caliburn.Micro and MahApps.Metro template

Template project for [Caliburn.Micro](https://github.com/Caliburn-Micro/Caliburn.Micro) WPF application using [MahApps.Metro](https://github.com/MahApps/MahApps.Metro) windows.

## What it uses

* Caliburn.Micro is the chosen MVVM framework, to bind your ViewModels to your Views. If you're not already using MVVM, use it.
* MahApps.Metro provides a quick and easy way to get a nice-looking application from the start.
* [MahApps.Metro.SimpleChildWindow](https://github.com/punker76/MahApps.Metro.SimpleChildWindow) will help you create nice-looking modal popups.
* `IPropertyChanged` notifications are implemented using [Fody.PropertyChanged](https://github.com/Fody/PropertyChanged). Just use `using PropertyChanged;` and add `[ImplementPropertyChanged]` to your ViewModels.
* NLog takes care of logging purposes; see `App.cs` for a sample usage using `Caliburn.Micro.Logging`.

## How it works

* A bootstrapper is registered in the `App.xaml` resources
* This bootstrapper then loads the `MainViewModel` through IoC and makes use of the `AppWindowManager`
* The `AppWindowManager` makes use of the `BaseWindow` or the `BaseDialogWindow`, which are using MahApps.Metro
* The `MasterViewModel` is a `Conductor`, which means it only "wires" the screens together. By default, it loads the `MainViewModel`.

## How to use it

Until I find out how to create a project template (or you help me do it), you'll have to set it up manually.

* Copy the CaliburnTemplate folder into your project and rename it as you want
* Rename the csproj file
* Open all .cs files and do a global replace of `namespace CaliburnTemplate` with `namespace whatever` and `using CaliburnTemplate` with `using whatever`
* Open all .xaml files and do a global replace of `x:Class="CaliburnTemplate` with `x:Class="whatever` and `clr-namespace:CaliburnTemplate` with `clr-namespace:whatever`
* Open the csproj file and change the RootNamespace and AssemblyName nodes values
* Open the AssemblyInfo.cs file and change the infos
* Add the project to your solution