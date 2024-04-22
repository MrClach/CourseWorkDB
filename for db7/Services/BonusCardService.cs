using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using spp3.Data.Models;

namespace for_db7
{
    public class BonusCardService
    {
        public readonly HttpClient _httpClient;
        public const string BaseUrl = "https://localhost:7088/";

        public BonusCardService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<ObservableCollection<BonusCard>> GetBonusCardsAsync()
        {
            var response = await _httpClient.GetAsync("bonuscards");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<ObservableCollection<BonusCard>>();
            return content;
        }

        public async Task<BonusCard> GetBonusCardByNumberAsync(string number)
        {
            var response = await _httpClient.GetAsync($"bonuscards/{number}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadFromJsonAsync<BonusCard>();
            return content;
        }

        public async Task AddBonusCardAsync(float discount, Customer customer)
        {
            string phoneNumber = customer.phoneNumber;
            var json = JsonConvert.SerializeObject(discount);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"bonuscards/{phoneNumber}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateBonusCardAsync(string oldNumber, string number, float discount, Customer? customer)
        {
            var bonusCard = new BonusCard
            {
                number = number,
                discount = discount,
                Customer = customer
            };

            var json = JsonConvert.SerializeObject(bonusCard);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"bonuscards/{oldNumber}", data);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBonusCardAsync(string number)
        {
            var response = await _httpClient.DeleteAsync($"bonuscards/{number}");
            response.EnsureSuccessStatusCode();
        }
    }
}
