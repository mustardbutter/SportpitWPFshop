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
    /// Логика взаимодействия для Товары.xaml
    /// </summary>
    public partial class Товары : Page
    {
        public Товары()
        {
            InitializeComponent();
            UserList.ItemsSource = art_prak1Entities4.GetContext().Items.ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Главная());
        }

        private void MainFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page)) return;
            this.Title = $"LESSON - {page.Title}";

            if (page is Главная)
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
