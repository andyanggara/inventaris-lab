using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-UUJ05RB; Initial Catalog=db0; Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void summonLab(String lab)
        {
            adpt = new SqlDataAdapter("SELECT id_Item, nama_item, spec_Item, ketersediaan FROM dbo.tbl_Item WHERE nama_Lab =  '" + lab + "'", sqlCon);
            dt = new DataTable();
            adpt.Fill(dt);
            dt.Columns["id_item"].ColumnName = "ID";
            dt.Columns["nama_item"].ColumnName = "Nama Barang";
            dt.Columns["spec_item"].ColumnName = "Spesifikasi";
            dt.Columns["Ketersediaan"].ColumnName = "Ketersediaan";
            DataGridView.ItemsSource = dt.DefaultView;
        }

        private void labMesin_Click(object sender, RoutedEventArgs e)
        {
            summonLab("lab_mesin");
        }

        private void labListrik_Click(object sender, RoutedEventArgs e)
        {
            summonLab("lab_listrik");
        }

        private void labPangan_Click(object sender, RoutedEventArgs e)
        {
            summonLab("lab_pangan");
        }

        private void labTanah_Click(object sender, RoutedEventArgs e)
        {
            summonLab("lab_tanah");
        }

        private void labPasca_Click(object sender, RoutedEventArgs e)
        {
            summonLab("lab_pasca");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {            
            LoginScreen login = new LoginScreen();
            login.Show();
            this.Close();
        }
    }
}
