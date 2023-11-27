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
using System.Data.Common;
using System.Data;

namespace WpfApp2
{
	/// <summary>
	/// Interaction logic for FinalItemsCustomization.xaml
	/// </summary>
	public partial class FinalItemsCustomization : UserControl
	{
        SqlConnection connection;
        string connectionString;

        public FinalItemsCustomization()
		{
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            PopulateItemsTable();
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
					FinalAllCharacterButtons.allItemsOwned = new List<string>();
					foreach (var item in BetterItemBox.SelectedItems)
					{
						string itemName = item.ToString();
						FinalAllCharacterButtons.allItemsOwned.Add(itemName);
					}
				}

			}
		}

        private void PopulateItemsTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Item", connection))
            {
                DataTable itemTable = new DataTable();
                adapter.Fill(itemTable);

                BetterItemBox.ItemsSource = itemTable.DefaultView;
            }
        }
    }
}
