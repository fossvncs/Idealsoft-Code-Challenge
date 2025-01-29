using Domain.Entities;
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
using System.Windows.Shapes;
using WPF_App.ViewModels;

namespace WPF_App
{
    /// <summary>
    /// Lógica interna para EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User User { get; set; }
        public MainViewModel ViewModel { get; set; }

        public EditUserWindow(User user, MainViewModel viewModel)
        {
            InitializeComponent();
            User = user;
            ViewModel = viewModel;
            DataContext = this;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //await ViewModel.UpdateUser(User);
            Close();
        }
    }
}
