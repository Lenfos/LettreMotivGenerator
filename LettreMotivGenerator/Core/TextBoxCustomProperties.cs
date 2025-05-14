using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyModel;

namespace LettreMotivGenerator.Core;

public static class TextBoxCustomProperties
{
    public static readonly DependencyProperty CustomTextProperty = 
        DependencyProperty.RegisterAttached(
            "CustomText",
            typeof(string),
            typeof(TextBoxCustomProperties),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));

    public static void SetCustomText(UIElement element, string value)
    {
        element.SetValue(CustomTextProperty, value);
    }

    public static string GetCustomText(UIElement element)
    {
        return (string)element.GetValue(CustomTextProperty);
    }
}