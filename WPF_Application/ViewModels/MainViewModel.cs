using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Application.ViewModels
{
    public class MainViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public MainViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:5001/api/") }; // Altere a URL para a sua API
            LoadUsers();
        }

        public async Task LoadUsers()
        {
            var response = await _httpClient.GetAsync("User");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);
                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
        }

        public async Task UpdateUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"User/{user.Id}", content);
        }
    }
}
