using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Lógica interna para CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private readonly HttpClient _httpClient;
        private MainViewModel _mainViewModel; //para fazer atualização automática após criação do usuário.

        public CreateUserWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7248/api/") };
            _mainViewModel = mainViewModel;
            
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newUser = new
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Phone = txtPhone.Text
                };

                string json = JsonConvert.SerializeObject(newUser);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("CreateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    await _mainViewModel.LoadUsers();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error creating user!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }


    }
}
