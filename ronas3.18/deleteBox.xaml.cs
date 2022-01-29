using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ronas
{
    /// <summary>
    /// Interaktionslogik für deleteBox.xaml
    /// </summary>
    public partial class deleteBox : UserControl
    {
        public deleteBox()
        {
            InitializeComponent();
        }

        private void confirmClick(object sender, MouseButtonEventArgs e)
        {
            Main.main.deleteProject();
        }

        private void backClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
