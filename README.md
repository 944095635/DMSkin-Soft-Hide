# DMSkin-Soft-Hide

![](https://img.shields.io/badge/.NET-%3E%3D3.5-brightgreen.svg)
![](https://img.shields.io/badge/version-0.0.0.1-blue.svg)
![](https://img.shields.io/badge/license-MIT-green.svg)

#### 隐藏软件&amp;游戏的界面&amp;任务栏图标&amp;支持热键.

<img src="https://raw.githubusercontent.com/944095635/DMSkin-for-WPF/master/DMSkin.ScreenShot/demo.png" align="center">

## Preface 
DMSkin-for-WPF (aka DFW) is a powerful WPF borderless window framework and control library utility. It supports window border shadow, window transition animation, contains lots of elegant controls. It aimed to let developers create beautiful WPF window more efficient and faster.And It supports .NET framework from 3.5 to 4.7, and runs well from Windows XP to Windows 10.

DFW offers 2 plans for window borderless:
#### 1. ComplexWindow Plan
Use Windows 32 API to redraw non-client area and create a separate shadow window for shadow's presentation.
#### 2. SimpleWindow Plan
Delay Window message to prevent flickering blurred bug owning to setting `AllowsTransparency=true`, `WindowStyle=None`.

The follwing chart can show you the differences between `DMSkinComplexWindow` and `DMSkinSimlpeWindow`


| Plan                | Transparency   |Animation   |System      |
| :----:              | :---:          | :----:     | :----:     |
| DMSkinComplexWindow | Not Support    |  Support   |  Win7 BUG  |
| DMSkinSimpleWindow  |  Support       |Not Support |  All       |

## Notice
#### 1. DFW was developed on VS 2017 Community, .NET 4.0 Environment, contains some c# 6.0+ grammar codes.If you cannot compile it through VS 2015 and others previous VS versions, please modify the source code youself.
#### 2. The DMSkinComplexWindow plan still has drawback, Non-client area system button blocks operations on Windows 7 system.

## 下载直接运行程序
#### 1. [Download EXE](https://github.com/944095635/DMSkin-for-WPF/releases/download/2.5.0.1/Release.zip)

## 使用 & 配置
#### 1. 本项目使用VS 2017开发
#### 2. NUGET包 引用了 DMSkin.WPF 2.5.0.9
#### 3. Add App.xaml Resources
````xml
XXX
````
