using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPF_App.ViewModels
{
    public class MainViewModel
    {
        private readonly HttpClient _httpClient;

        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public MainViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("https://localhost:7248/api/") }; 
            LoadUsers();
        }

        public async Task LoadUsers()
        {
            var response = await _httpClient.GetAsync("GetUsers");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();


                var users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Users.Clear();
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
        }

        //public async Task UpdateUser(User user)
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
        //    await _httpClient.PutAsync($"User/{user.Id}", content);
        //}
    }
}
