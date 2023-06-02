using System.Reflection;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace Sample {
    public class ViewLocator : IDataTemplate {
        public Control? Build(object? param) {
            if (param is null) {
                return null;
            }

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture);

            var type = Assembly.GetExecutingAssembly().GetType(name);
            return type != null ? (Control)Activator.CreateInstance(type)! : new TextBlock { Text = $"Type '{name}' not found" };
        }

        public bool Match(object? data) => true;
    }
}