using Avalonia;
using System.Threading;

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
                    if (Console.KeyAvailable) {
                        _ = Console.ReadKey(true);
                    }
                    else {
                        Thread.Sleep(50);
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