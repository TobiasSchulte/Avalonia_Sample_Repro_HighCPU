using Avalonia;

namespace Sample {
    internal sealed class Program {
        [STAThread]
        public static int Main(string[] args) {
            SilenceConsole();

            return BuildAvaloniaApp().StartLinuxDrm(args, null, 1);
        }

        private static void SilenceConsole() {
            // Don't try to read from the console when it is not attached. In
            // framebuffer scenarios the console might be redirected which can
            // cause exceptions or unnecessary CPU usage.
            if (Console.IsInputRedirected) {
                return;
            }

            new Thread(() => {
                try {
                    Console.CursorVisible = false;
                } catch (Exception) {
                    // Some environments don't allow changing the cursor state.
                }

                while (true) {
                    try {
                        _ = Console.ReadKey(true);
                    } catch (InvalidOperationException) {
                        // If there is no console available ReadKey will throw,
                        // so pause briefly to avoid a tight loop.
                        Thread.Sleep(100);
                    }
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