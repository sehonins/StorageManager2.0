using StorageManagerData;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace StorageManagerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data = new Data();
        public MainWindow()
        {
            InitializeComponent();
            Show();
        }
        /// <summary>
        /// View
        /// </summary>
        void ShowData()
        {
            DataOutput.ItemsSource = data.LoadData();
        }
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            ShowData();
        }
        private void BtnFiltered_Click(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void Show()
        {
            DataTable table = new DataTable();
            GetData(table);
        }

        private void GetData(DataTable table)
        {
            if (data.LoadData == null)
            {
                MessageBox.Show("");
                return;
            }
            else
            {
                List<Emploee> emploes = data.LoadData();
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Second name", typeof(string));
                table.Columns.Add("Job to do", typeof(string));

                foreach (var item in emploes)
                {
                    table.Rows.Add(item.Id, item.Name, item.SecondName, item.AlocatedJob);
                }

                DataOutput.ItemsSource = table.AsDataView();
            }
            
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DataOutput.ItemsSource = null;
        }

        /// <summary>
        /// DataBase
        /// </summary>
       
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "")
            {
                MessageBox.Show("ID requaired");
                ClearTextFields();
                return;
            }
            if (TextJob.Text == "")
            {
                MessageBox.Show("Job requaired");
                ClearTextFields();
                return;
            }
            string job = TextJob.Text;
            bool success = int.TryParse(job, out int id);
            if (id >= 1)
            {
                data.UpdateEmploeeJob(id, job);
                Show();
            }
            ClearTextFields();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            data.AddEmploee(txtName.Text, txtSecondName.Text, txtContacts.Text, TextJob.Text);
            Show();
            ClearTextFields();
        }

        private void ClearTextFields()
        {
            TxtId.Text = "";
            txtName.Text = "";
            txtSecondName.Text = "";
            txtContacts.Text = "";
            TextJob.Text = "";
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            bool success = int.TryParse(TxtId.Text, out int id);
            if (!success)
            {
                MessageBox.Show("Enter correct ID");
                ClearTextFields();
            }
            else
            {
                try
                {
                    data.DeleteEmploee(id);
                    Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    ClearTextFields();
                }
            }
        }

       
    }
}
