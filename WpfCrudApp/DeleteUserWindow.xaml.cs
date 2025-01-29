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
using static System.Net.Mime.MediaTypeNames;

namespace WpfCrudApp
{
    /// <summary>
    /// Lógica interna para DeleteUserWindow.xaml
    /// </summary>
    public partial class DeleteUserWindow : Window
    {
        public User User { get; set; }
        public MainViewModel ViewModel { get; set; }

        // Construtor que recebe o ID do usuário a ser deletado
        public DeleteUserWindow(User user, MainViewModel viewModel)
        {
            InitializeComponent();
            User = user;
            ViewModel = viewModel;
        }

        // Lógica para deletar o usuário
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Chama o método da camada de aplicação para deletar o usuário
                await ViewModel.DeleteUser(User);
                MessageBox.Show("User deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
