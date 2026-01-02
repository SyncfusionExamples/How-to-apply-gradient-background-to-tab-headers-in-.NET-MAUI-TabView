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
    <ContentPage.BindingContext>
    <local:MainPageViewModel/>
</ContentPage.BindingContext>
 
<tabView:SfTabView x:Name="tabView" ItemsSource="{Binding TabItems}" IndicatorPlacement="Fill"
                   SelectionChanged="tabView_SelectionChanged">
 
    <tabView:SfTabView.HeaderItemTemplate>
        <DataTemplate>
            <Border Background="{Binding HeaderBrush}">
                <Label Text="{Binding Title}"
                   WidthRequest="132"
                   HorizontalTextAlignment="Center"
                   VerticalTextAlignment="Center"
                   TextColor="White"/>
            </Border>
        </DataTemplate>
    </tabView:SfTabView.HeaderItemTemplate>
   
       <!--ContentItemTemplate-->
 
   </tabView:SfTabView>
```
 
**Mainpage.Xaml.cs**
```
protected override void OnAppearing()
{
    base.OnAppearing();
    if (BindingContext is MainPageViewModel viewModel)
    {
        if (tabView.SelectedIndex < 0 && viewModel.TabItems?.Count > 0)
            tabView.SelectedIndex = 0;
 
        viewModel.UpdateSelectedIndex((int)tabView.SelectedIndex);
    }
}
private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
{
    int selectedIndex = -1;
 
    if (sender is SfTabView tabView)
        selectedIndex = (int)tabView.SelectedIndex;
 
    if (BindingContext is MainPageViewModel viewModel && selectedIndex >= 0)
    {
        viewModel.UpdateSelectedIndex(selectedIndex);
    }
}
```
 
**ViewModel**
```
public class MainPageViewModel : INotifyPropertyChanged
{
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public ObservableCollection<Model> TabItems { get; set; }
 
        private readonly Brush staticBrush = new LinearGradientBrush(
            new GradientStopCollection
            {
        new GradientStop(Color.FromArgb("#6A11CB"), 0.0f),
        new GradientStop(Color.FromArgb("#2575FC"), 1.0f)
            },
            new Point(0, 0), new Point(1, 0));
 
        private readonly Brush selectedBrush = new LinearGradientBrush(
            new GradientStopCollection
            {
        new GradientStop(Color.FromArgb("#FF512F"), 0.0f),
        new GradientStop(Color.FromArgb("#DD2476"), 1.0f)
            },
            new Point(0, 0), new Point(1, 0));
 
        public MainPageViewModel()
        {
            TabItems = new ObservableCollection<Model>
        {
           new Model
            {
                Title = "Home",
                ContentText = "Welcome to the Home tab. Here you can find an overview of your application and quick access to essential features."
            },
            new Model
            {
                Title = "Tasks",
                ContentText = "Manage your tasks efficiently. Add new tasks, track progress, and stay organized to meet your goals."
            },
            new Model
            {
                Title = "Reports",
                ContentText = "View detailed reports and analytics. Gain insights into your performance and make informed decisions."
            }
        };
 
            foreach (var item in TabItems)
                item.HeaderBrush = staticBrush;
        }
 
        public void UpdateSelectedIndex(int selectedIndex)
        {
            if (TabItems == null || TabItems.Count == 0) return;
            if (selectedIndex < 0 || selectedIndex >= TabItems.Count) return;
 
            for (int i = 0; i < TabItems.Count; i++)
            {
                TabItems[i].HeaderBrush = (i == selectedIndex) ? selectedBrush : staticBrush;
            }
        }
 
    }
```
 
**Model**
```
public class Model : INotifyPropertyChanged
{
    private string title;
    private string contentText;
    private Brush headerBrush;
 
    public string Title
    {
        get => title;
        set { title = value; OnPropertyChanged(nameof(Title)); }
    }
 
    public string ContentText
    {
        get => contentText;
        set { contentText = value; OnPropertyChanged(nameof(ContentText)); }
    }
 
    public Brush HeaderBrush
    {
        get => headerBrush;
        set { headerBrush = value; OnPropertyChanged(nameof(HeaderBrush)); }
    }
 
    public event PropertyChangedEventHandler? PropertyChanged;
 
    protected void OnPropertyChanged(string? propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }
}
```