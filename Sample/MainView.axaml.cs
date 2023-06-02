using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Sample {
    public partial class MainView : UserControl {
        public MainView() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}