using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
using MySql.Data.MySqlClient;

namespace СамостоятельнаяLis1.Страницы
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Boolean expanded = false;
        public AdminPage()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Главная());
        }

        private void Things_Initialized(object sender, EventArgs e)
        {
            string connstring = "server=sql11.freemysqlhosting.net;uid=sql11657487;pwd=RhX6XSrzN5;database=sql11657487";
            MySqlConnection connect = new MySqlConnection(connstring);
            connect.Open();
            string sql = "SELECT Id, NameItem From Items";
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Things.Items.Add(reader.GetString(0) + " " + reader.GetString(1));
            }
            connect.Close();
            Console.WriteLine("Done.");
        }

        private void ImageOfThing_MouseEnter(object sender, MouseEventArgs e)
        {
            switch (expanded)
            {
                case true:
                    ImageOfThing.Width = 220; ImageOfThing.Height = 220;
                    expanded = false;
                    break;
                case false:
                    ImageOfThing.Width = 160; ImageOfThing.Height = 160;
                    expanded = true;
                    break;
                default:
                    ImageOfThing.Width = 160; ImageOfThing.Height = 160;
                    break;
            }
            Thread.Sleep(100);

        }


        private void Things_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = (ListBox)sender;

            string nameval = Regex.Replace(listbox.SelectedItem.ToString(), "[1-9, 0]", "");
            ThingName.Content = nameval;

            string value = Regex.Replace(listbox.SelectedItem.ToString(), "[А-Яа-я]", "");
            int IDS = Int32.Parse(value);

            try
            {
                String Descr = "\"" + listbox.SelectedItems.ToString() + "\"";

                string connstring = "server=sql11.freemysqlhosting.net;uid=sql11657487;pwd=RhX6XSrzN5;database=sql11657487";
                MySqlConnection connect = new MySqlConnection(connstring);
                connect.Open();
                string sql = "SELECT * FROM Items where Id='" + IDS + "'";
                MySqlCommand cmd = new MySqlCommand(sql, connect);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThingDescription.Text = ((string)reader["Description"]);
                    Coun.Content = ((int)reader["CountItem"]);
                    Provider.Content = ((string)reader["Provider"]);
                    Price.Content = ((int)reader["Price"]);
                }

                connect.Close();
                Console.WriteLine("ConnectionClosed");

            }
            catch (MySqlException ex) { MessageBox.Show("Error " + ex.ToString()); }
        }
    }
}
