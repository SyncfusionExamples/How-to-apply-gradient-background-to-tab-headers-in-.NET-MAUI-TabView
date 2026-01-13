# How-to-apply-a-gradient-background-to-each-tab-header-in-.NET-MAUI-TabView
 
A sample application that demonstrates how to apply a gradient background to each tab header in .NET MAUI TabView. You can achieve this by customizing the `HeaderItemTemplate` and using a ViewModel to dynamically switch gradient brushes based on the selected tab.
 
## Prerequisites
 
* Visual Studio 2026 with .NET MAUI workload
 
## How to run this sample
 
1. Clone the repository.
2. Open the solution file `TabViewGradientBackground.sln` in Visual Studio 2026.
3. Build and run the project.
 
## Code Snippet
 
To achieve the glass-like effect, use below code.
 
**Mainpage.Xaml**
 
```xml
    <ContentPage.Resources>
<LinearGradientBrush x:Key="NormalGradient" StartPoint="0,0" EndPoint="1,0">
<GradientStop Color="#6A11CB" Offset="0.0" />
<GradientStop Color="#2575FC" Offset="1.0" />
</LinearGradientBrush>
 
    <LinearGradientBrush x:Key="SelectedGradient" StartPoint="0,0" EndPoint="0,1">
<GradientStop Color="#FF512F" Offset="0.0" />
<GradientStop Color="#DD2476" Offset="1.0" />
</LinearGradientBrush>
 
    <ResourceDictionary>
<Style TargetType="tabView:SfTabItem">
<Setter Property="VisualStateManager.VisualStateGroups">
<VisualStateGroupList>
<VisualStateGroup>
<VisualState x:Name="NormalFilled">
<VisualState.Setters>
<Setter Property="Background" Value="{DynamicResource NormalGradient}" />
</VisualState.Setters>
</VisualState>
<VisualState x:Name="SelectedFilled">
<VisualState.Setters>
<Setter Property="Background" Value="{DynamicResource SelectedGradient}" />
</VisualState.Setters>
</VisualState>
</VisualStateGroup>
</VisualStateGroupList>
</Setter>
</Style>
</ResourceDictionary>
</ContentPage.Resources>
 
 
<tabView:SfTabView x:Name="TabView" IndicatorPlacement="Fill">
<tabView:SfTabItem Header="Home" TextColor="White">
<tabView:SfTabItem.Content>
<Label Padding="12" Text="Welcome to the Home tab. Here you can find an overview of your application and quick access to essential features."
                       FontSize="16"  LineBreakMode="WordWrap"/>
</tabView:SfTabItem.Content>
</tabView:SfTabItem>
 
    <tabView:SfTabItem Header="Tasks" TextColor="White">
<tabView:SfTabItem.Content>
<Label Padding="12" Text="Manage your tasks efficiently. Add new tasks, track progress, and stay organized to meet your goals."
                       FontSize="16" LineBreakMode="WordWrap"/>
</tabView:SfTabItem.Content>
</tabView:SfTabItem>
 
    <tabView:SfTabItem Header="Reports" TextColor="White">
<tabView:SfTabItem.Content>
<Label Padding="12" Text="View detailed reports and analytics. Gain insights into your performance and make informed decisions."
                       FontSize="16" LineBreakMode="WordWrap"/>
</tabView:SfTabItem.Content>
</tabView:SfTabItem>
</tabView:SfTabView>
```