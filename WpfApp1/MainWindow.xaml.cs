using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.MultipleActiveResultSets = true;
            connectionStringBuilder.DataSource = @"DESKTOP-2IQ00BN\SQLEXPRESS";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.InitialCatalog = "MyDb";


            connectionStringBuilder.UserID = login.Text;
            connectionStringBuilder.Password = password.Text;
           
            MessageBox.Show(connectionStringBuilder.ToString());

            var connectionString = connectionStringBuilder.ToString();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Вы вошли");
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
