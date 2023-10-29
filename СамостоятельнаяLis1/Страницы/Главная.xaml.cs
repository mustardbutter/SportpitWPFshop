using Org.BouncyCastle.Utilities;
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
using MySql.Data.MySqlClient;

namespace СамостоятельнаяLis1.Страницы
{
    /// <summary>
    /// Логика взаимодействия для Главная.xaml
    /// </summary>
    public partial class Главная : Page
    {
        public Главная()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Товары());
        }

        public string roleName(int rol) {
            int roleid = rol;
            switch (roleid)
            {
                default:
                    return "пользователь "; 

                case 1:
                    return "администратор ";

                case 2:
                    return "менеджер ";

                case 3:
                    return "пользователь ";

            }
        }
        public int roleid = 777;
        public string Name;


        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                String loginUser = "\"" + login.Text + "\"";
                String passUser = "\"" + password.Text + "\"";

                string connstring = "server=sql11.freemysqlhosting.net;uid=sql11657487;pwd=RhX6XSrzN5;database=sql11657487";
                MySqlConnection connect = new MySqlConnection(connstring);
                connect.Open();
                string sql = "SELECT * FROM Users WHERE Login =" + loginUser + " AND Pass =" + passUser + ";";
                MySqlCommand cmd = new MySqlCommand(sql, connect);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {       
                roleid = (int)reader["Roles"];
                Name = (string)reader["FIO"];
                MessageBox.Show("Здравствуйте " + roleName((int)reader["Roles"]) + reader["FIO"]);
                }

                if (roleid == 777)
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
                else { 
                    
                }

                connect.Close();
                Console.WriteLine("ConnectionClosed");

            }
            catch(MySqlException ex) { MessageBox.Show("Error " + ex.ToString());  }
        }
    }
}


    public class xTextBox : TextBox
    {
    }

