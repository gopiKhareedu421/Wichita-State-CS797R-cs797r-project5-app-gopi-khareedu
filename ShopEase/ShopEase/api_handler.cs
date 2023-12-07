using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;

namespace ShopEase
{
    public class api_handler
    {
        int result = -1;
        string content;
        string content_type = "application/json";
        HttpClient http_client = new();

        public async Task<int?> AddUser(User new_user)
        {
            try
            {
                result = -1;
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/User/AddUser");
                http_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content_type));
                http_client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", content_type);
                StringContent content = new(JsonConvert.SerializeObject(new_user), Encoding.UTF8, content_type);
                HttpResponseMessage response = await http_client.PostAsync("", content);
                if (response.IsSuccessStatusCode) { result = int.Parse(response.Content.ReadAsStringAsync().Result); }
                return result;
            }
            catch { return null; }
        }

        public async Task<int?> AddProduct(Product new_product)
        {
            try
            {
                result = -1;
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/Product/AddProduct");
                http_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content_type));
                http_client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", content_type);
                StringContent content = new(JsonConvert.SerializeObject(new_product), Encoding.UTF8, content_type);
                HttpResponseMessage response = await http_client.PostAsync("", content);
                if (response.IsSuccessStatusCode) { result = int.Parse(response.Content.ReadAsStringAsync().Result); }
                return result;
            }
            catch { return null; }
        }

        public async Task<int?> UpdateUser(User edited_user)
        {
            try
            {
                result = -1;
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/User/UpdateUser");
                http_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content_type));
                http_client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", content_type);
                StringContent content = new(JsonConvert.SerializeObject(edited_user), Encoding.UTF8, content_type);
                HttpResponseMessage response = await http_client.PutAsync("", content);
                if (response.IsSuccessStatusCode) { result = int.Parse(response.Content.ReadAsStringAsync().Result); }
                return result;
            }
            catch { return null; }
        }

        public async Task<int?> UpdateProduct(Product edited_product)
        {
            try
            {
                result = -1;
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/Product/UpdateProduct");
                http_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(content_type));
                http_client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", content_type);
                StringContent content = new(JsonConvert.SerializeObject(edited_product), Encoding.UTF8, content_type);
                HttpResponseMessage response = await http_client.PutAsync("", content);
                if (response.IsSuccessStatusCode) { result = int.Parse(response.Content.ReadAsStringAsync().Result); }
                return result;
            }
            catch { return null; }
        }

        public async Task<User?> CheckUserLogin(string email_id, string password)
        {
            try
            {
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/User/CheckUserLogin");
                string parameters = $"?email_id={email_id}&password={password}";
                HttpResponseMessage response = await http_client.GetAsync(parameters);
                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonConvert.DeserializeObject<User>(content));
                }
                else { return null; }
            }
            catch { return null; }
        }

        public async Task<User?> SearchUser(String user_id)
        {
            try
            {
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/User/SearchUser");
                string parameters = $"?user_id={user_id}";
                HttpResponseMessage response = await http_client.GetAsync(parameters);
                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonConvert.DeserializeObject<User>(content));
                }
                else { return null; }
            }
            catch { return null; }
        }

        public async Task<IEnumerable<Product>?> GetRetailerProducts(String retailer_id)
        {
            try
            {
                http_client = new HttpClient();
                http_client.BaseAddress = new Uri("https://localhost:7223/api/Product/GetRetailerProducts");
                string parameters = $"?retailer_id={retailer_id}";
                HttpResponseMessage response = await http_client.GetAsync(parameters);
                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<Product>>(content));
                }
                else { return null; }
            }
            catch { return null; }
        }
    }
}
