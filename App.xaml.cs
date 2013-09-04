using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FirstFloor.ModernUI.Presentation;
using NowListeningParserTool.Properties;

namespace NowListeningParserTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppearanceManager.Current.AccentColor = ApplicationSettings.Default.SelectedAccentColor;
            AppearanceManager.Current.ThemeSource = ApplicationSettings.Default.SelectedThemeSource;
        }
    }
}
