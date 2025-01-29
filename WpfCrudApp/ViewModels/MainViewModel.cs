using Domain.Entities;
using Idealsoft_Code_Test.Shared;
using Newtonsoft.Json;


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfCrudApp.ViewModels
{
    public class MainViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public MainViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:7248/api/") };
            Initialize();
        }

        public async void Initialize()
        {
            await LoadUsers();
        }

        public async Task LoadUsers()
        {
            var response = await _httpClient.GetAsync("GetUsers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<ApiResponse<List<User>>>(content);
                Users.Clear();
                if (users != null && users.Data != null)
                {
                    foreach (var user in users.Data)
                    {
                        Users.Add(user);
                    }
                }
            }
        }

        public async Task UpdateUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"UpdateUser", content);
        }

        public async Task DeleteUser(User user)
        {
            await _httpClient.DeleteAsync($"DeleteUserById?id={user.Id}");
        }
    }
}
