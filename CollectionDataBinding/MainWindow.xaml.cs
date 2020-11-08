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

namespace CollectionDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }
        private void LoadUsers()
        {
            users = new List<User>();
            users.Add(new User() { Name = "Peter Parker" });
            users.Add(new User() { Name = "Tony Stark" });
            users.Add(new User() { Name = "Natasha Romanoff" });
            ltbxuser.ItemsSource = users;
        }

        private void btnadduser_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbxuser.Text))
            {
                User user = new User() { Name = txtbxuser.Text };
                users.Add(user);
                ltbxuser.SelectedItem = user;
                UpdateView();
            }

        }

        private void btnchangeuser_Click(object sender, RoutedEventArgs e)
        {
            if (ltbxuser.SelectedItem != null)
            {
                User user = ltbxuser.SelectedItem as User;
                user.Name = txtbxuser.Text;
                ltbxuser.SelectedItem = user;
                UpdateView();
            }
        }

        private void btndeleteuser_Click(object sender, RoutedEventArgs e)
        {
            if (ltbxuser.SelectedItem != null)
            {
                users.Remove(ltbxuser.SelectedItem as User);
                txtbxuser.Text = "";
                UpdateView();
            }
                }

        private void UpdateView()
        {
            ltbxuser.Items.Refresh();
            if (users.Count > 0)
            {
                btndeleteuser.IsEnabled = true;
                btnchangeuser.IsEnabled = true;
            }
            else
            {
               ltbxuser.SelectedIndex = -1;
               btndeleteuser.IsEnabled = false;
               btnchangeuser.IsEnabled = false;
            }
        }

        private void ltbxuser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            {
                if (ltbxuser.SelectedItem != null)
                {
                    txtbxuser.Text = (ltbxuser.SelectedItem as User).Name;
                }
            }
        }
    }
}
