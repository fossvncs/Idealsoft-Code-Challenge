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
using WpfCrudApp.ViewModels;

namespace WpfCrudApp
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

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Chama o método da camada de aplicação para deletar o usuário
                await ViewModel.UpdateUser(User);
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                await ViewModel.LoadUsers();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Cancelar a exclusão e fechar a janela
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
