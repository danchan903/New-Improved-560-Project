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

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalItemsCustomization.xaml
	/// </summary>
	public partial class FinalItemsCustomization : UserControl
	{
		public FinalItemsCustomization()
		{
			Items = new ObservableCollection<string> { "Hello", "Hoho", "Muahaha" };
			InitializeComponent();
			DataContext = this;
		}

		public event EventHandler<CustomButtonEventArgs> backToCharacterCreatorFromInventory;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCreatorFromInventory;

		public ObservableCollection<string> Items { get; }

		public void BackToCharacterCreationFromInventory(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ConfirmToCharacterCreationFromInventory(object sender, RoutedEventArgs e)
		{
			ButtonClick(sender, e);

		}

		public void ButtonClick(object sender, RoutedEventArgs e)
		{

			if (sender is Button b)
			{
				if (b.Name == "BackButtonFromInventory")
				{
					backToCharacterCreatorFromInventory?.Invoke(this, new CustomButtonEventArgs("BackToCharacterCreationFromInventory"));
				}

				if (b.Name == "ConfirmButtonFromInventory")
				{
					confirmToCharacterCreatorFromInventory?.Invoke(this, new CustomButtonEventArgs("ConfirmToCharacterCreationFromInventory"));
				}

			}
		}
	}
}
