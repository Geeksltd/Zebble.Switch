[logo]: https://raw.githubusercontent.com/Geeksltd/Zebble.Switch/master/icon.png "Zebble.Switch"


## Zebble.Switch

![logo]

A Zebble plugin that a toggle control allowing the user to select a status of ON or OFF.


[![NuGet](https://img.shields.io/nuget/v/Zebble.Switch.svg?label=NuGet)](https://www.nuget.org/packages/Zebble.Switch/)

> A Switch is an alternative to checkbox but is more commonly used in mobile apps.

<br>


### Setup
* Available on NuGet: [https://www.nuget.org/packages/Zebble.Switch/](https://www.nuget.org/packages/Zebble.Switch/)
* Install in your platform client projects.
* Available for iOS, Android and UWP.
<br>


### Api Usage

To use this plugin in markup or c# code you can use below code:
```xml
<Switch Id="MySwitch" Checked="true"></Switch>
```
```csharp
new Switch { Id = "MySwitch", Checked = true };
```

#### Checked changed
Like CheckBox, if you want to control what happens when a user toggles a switch you can use CheckedChanged action.
```csharp
MySwitch.CheckedChanged += CheckChange;
private void CheckChange() {/* Do something here. */}
```
#### Checked
You can set the value of Switch by changing Checked property. The default value is false.
#### Checked image
You can use CheckedImage field to set an image for the checked state, like the following:
```csharp
MySwitch.CheckedImage = new ImageView { Path = "Images/Something.png" };
```
### Properties
| Property     | Type         | Android | iOS | Windows |
| :----------- | :----------- | :------ | :-- | :------ |
| Checked            | bool           | x       | x   | x       |
| Path            | string           | x       | x   | x       |
| AnimationDuration            | TimeSpan           | x       | x   | x       |

### Events
| Event             | Type                                          | Android | iOS | Windows |
| :-----------      | :-----------                                  | :------ | :-- | :------ |
| CheckedChanged               | AsyncEvent    | x       | x   | x       |

### Methods
| Method       | Return Type  | Parameters                          | Android | iOS | Windows |
| :----------- | :----------- | :-----------                        | :------ | :-- | :------ |
| ToggleChanged         | Task| -| x       | x   | x       |
