using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TabViewGradientBackground
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Model> Tabs { get; } = new()
        {
            new Model { Title = "Home",   ContentText = "Home content" },
            new Model { Title = "Tasks",  ContentText = "Tasks content" },
            new Model { Title = "Reports",ContentText = "Reports content" }
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async Task OnRefreshClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Refreshed", "Content was refreshed.", "OK");
        }

        private async Task OnMoreClicked(object sender, EventArgs e)
        {
            await DisplayAlert("More", "More actions coming soon.", "OK");
        }


        private void OnCloseClicked(object sender, System.EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is Model tab && Tabs.Contains(tab))
                Tabs.Remove(tab);
        }
    }

    public class Model
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
    }
}
