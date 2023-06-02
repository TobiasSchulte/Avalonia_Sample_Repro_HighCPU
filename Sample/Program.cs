using Avalonia;

namespace Sample {
    internal sealed class Program {
        [STAThread]
        public static int Main(string[] args) {
            SilenceConsole();

            return BuildAvaloniaApp().StartLinuxDrm(args, null, 1);
        }

        private static void SilenceConsole() {
            new Thread(() => {
                Console.CursorVisible = false;
                while (true) {
                    _ = Console.ReadKey(true);
                }
            }) { IsBackground = true }.Start();
        }

        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseSkia();
        }
    }
}