using System;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace SudokuWpfApp.MarkupExtensions
{
    class MethodBindingExtension : MarkupExtension
    {
        public MethodBindingExtension() {}

        public MethodBindingExtension(string path)
        {
            MethodName = path;
        }

        public string MethodName { get; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var element = provideValueTarget.TargetObject as FrameworkElement;
            var addHandlerMethodInfo = provideValueTarget.TargetProperty as MethodInfo;

            Action<object, object> handler = (sender, e) =>
            {
                element.DataContext.GetType().GetMethod(MethodName).Invoke(element.DataContext, new object[0]);
            };

            var handlerParameter = addHandlerMethodInfo.GetParameters()[1] as ParameterInfo;
            return Delegate.CreateDelegate(handlerParameter.ParameterType, handler.Target, handler.Method);
        }
    }
}
