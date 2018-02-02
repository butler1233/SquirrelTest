using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Squirrel;

namespace SquirrelTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var app = Application.Current;
            var assem = Assembly.GetEntryAssembly().GetName();

            AppVersion.Text = $"Name {assem.FullName} Ver {assem.Version.ToString()}";

            AppVersion_Copy.Text = AppVersion.Text;
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            using (var mgr = new UpdateManager("http://squirrel.ad.whitehinge.com/"))
            {
                await mgr.UpdateApp();
            }
        }
    }
}
