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
	/// Interaction logic for FinalClassCustomization.xaml
	/// </summary>
	public partial class FinalClassCustomization : UserControl
	{
        SqlConnection connection;
        string connectionString;

		public static string ClassName { get; set; }
        public FinalClassCustomization()
		{
			InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["WpfApp2.Properties.Settings.Database1ConnectionString"].ConnectionString;
			PopulateCharacterTable();
		}

		public event EventHandler<CustomButtonEventArgs> backToCharacterCreatorFromClass;
		public event EventHandler<CustomButtonEventArgs> confirmToCharacterCreatorFromClass;

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
					FinalAllCharacterButtons.className = classCombo.Text;
				}

			}
		}

        private void PopulateCharacterTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Class", connection))
            {
                DataTable classTable = new DataTable();
                adapter.Fill(classTable);

				classCombo.DisplayMemberPath = "ClassType";
				classCombo.SelectedValuePath = "ClassType";
				classCombo.ItemsSource = classTable.DefaultView;
            }
        }
    }
}
