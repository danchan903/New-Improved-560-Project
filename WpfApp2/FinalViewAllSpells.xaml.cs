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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for FinalViewAllSpells.xaml
    /// </summary>
    public partial class FinalViewAllSpells : UserControl
    {
        public FinalViewAllSpells()
        {
            InitializeComponent();
        }

        public event EventHandler<CustomButtonEventArgs> backToMainMenuFromAllSpells;

        public void ClickBackInAllSpells(object sender, RoutedEventArgs e)
        {
            ButtonClick(sender, e);

        }

        public void ButtonClick(object sender, RoutedEventArgs e)
        {

            if (sender is Button b)
            {
                if (b.Name == "backFromAllSpells")
                {
                    backToMainMenuFromAllSpells?.Invoke(this, new CustomButtonEventArgs("BackToMainMenuFromAllSpells"));
                }


            }
        }

    }
}
