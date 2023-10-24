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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model1.User.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.IDRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте Администатор " + userObj.Name + "!",
                         "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Товары());
                            break;

                        case 2:
                            MessageBox.Show("Здравствуйте Ученик " + userObj.Name + "!",
                     "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new Товары());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";

            if (page is Главная)
            {
                ButtonGuest.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonGuest.Visibility = Visibility.Visible;
            }
        }
    }


    public class xTextBox : TextBox
    {
        public xTextBox()
        {
            Loaded += delegate
            {
                TextBox placetext = new TextBox() { Foreground = SystemColors.GrayTextBrush };
                Binding bind = new Binding("PlaceHolder");
                bind.Source = this;
                placetext.SetBinding(TextBlock.TextProperty, bind);

                ContentControl host = Template.FindName("PART_ContentHost", this) as ContentControl;
                FrameworkElement tbw = host.Content as FrameworkElement;

                Grid grid = new Grid();
                host.Content = grid;
                grid.Children.Add(placetext);
                grid.Children.Add(tbw);

                this.TextChanged += delegate
                {
                    placetext.Opacity = string.IsNullOrWhiteSpace(Text) ? 1 : 0;
                };
            };
        }
    }

}

