using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;
using System.Data.SqlClient;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalClassCustomization.xaml
	/// </summary>
	public partial class FinalClassCustomization : UserControl
	{
		public FinalClassCustomization()
		{
			Spells = new ObservableCollection<string> { "Hello", "Hoho", "Muahaha" };
			ClassSpells = new ObservableCollection<string> { "Hello", "Hoho", "Muahaha" };
			InitializeComponent();
			DataContext = this;
		}

		public event EventHandler<CustomButtonEventArgs> backToCharacterCreatorFromClass;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCreatorFromClass;

		public ObservableCollection<string> Spells { get; }

		public ObservableCollection<string> ClassSpells { get; }


		public void BackToCharacterCreationFromClass(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ConfirmToCharacterCreationFromClass(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackButtonFromClass")
				{
					backToCharacterCreatorFromClass?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCreationFromClass"));
				}

				if (b.Name == "ConfirmButtonFromClass")
				{
					confirmToCharacterCreatorFromClass?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCreationFromClass"));
				}

			}
		}
	}
}
