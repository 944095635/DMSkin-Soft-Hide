# DMSkin-Soft-Hide

![](https://img.shields.io/badge/.NET-%3E%3D3.5-brightgreen.svg)
![](https://img.shields.io/badge/version-0.0.0.1-blue.svg)
![](https://img.shields.io/badge/license-MIT-green.svg)

#### 隐藏软件&amp;游戏的界面&amp;任务栏图标&amp;支持热键.

[中文说明请点这里](./DMSkin.Docs/)

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

## Installation
You can get the **`DMSkin.WPF.dll`** through 2 two different ways.

#### 1. [Download DMSkin.WPF.dll](https://github.com/944095635/DMSkin-for-WPF/releases/download/2.5.0.1/Release.zip)

The drawback of this way is the **dll** you downloaded is not always up to date.

#### 2. [Download the source code](https://github.com/944095635/DMSkin-for-WPF/archive/master.zip) and compile it yourself
Click `DMSkin-for-WPF.sln` to open the project, right click DMSkin.WPF in the solution resource manager window and click build button to complile. And then open the project folder with `file explorer`, you will find the DMSkin.WPF.dll is in `bin\Debug` folder.

There are some other ways to fetch `DMSkin.WPF.dll` and source code.

- Nuget  `PM> Install-Package DMSkin.WPF -Version 2.5.0.4`
- Git  `git clone git@github.com:944095635/DMSkin-for-WPF.git`

## Usage & Configration
#### 1. Create a new WPF project
#### 2. [Add DMSkin.WPF.dll reference](http://p40kjburh.bkt.clouddn.com/18-6-13/50043356.jpg)
#### 3. Add App.xaml Resources
````xml
<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!--  样式分离 不用的可以不引用 减少内存暂用  -->
                <!--  DMSKin内置转换器 配色  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Styles/DMSkin.xaml" />
                <!--  DMSKin内置滚动容器  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Styles/DMScrollViewer.xaml" />
                <!--  DMSKin内置SVG图标  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMIcon.xaml" />
                <!--  DMSKin内置按钮  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMButton.xaml" />
                <!--  DMSKin内置选择框  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMCheckBox.xaml" />
                <!--  DMSKin内置动画  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;Component/Styles/Animation.xaml" />
                <!--  DMSKin内置输入框  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMTextBox.xaml" />
                <!--  DMSKin内置滑动  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMSlider.xaml" />
                <!--  DMSKin提示框  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMToolTip.xaml" />
                <!--  DMSKin右键菜单  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMContextMenu.xaml" />
                <!--  DMSKin其他样式  -->
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMTabControl.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMRadioButton.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMTreeView.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMDataGrid.xaml" />
                <ResourceDictionary Source="pack://application:,,,/DMSkin.WPF;component/Styles/DMListBox.xaml" />
                <!--  最后加载项目其他的样式  -->
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
````
