using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace Sample {
    public partial class App : Application {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted() {
            var vm = new MainViewModel();

            (this.ApplicationLifetime as ISingleViewApplicationLifetime)!.MainView = new MainView { DataContext = vm };

            base.OnFrameworkInitializationCompleted();
        }
    }
}