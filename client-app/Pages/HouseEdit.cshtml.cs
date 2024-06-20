using client_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace client_app.Pages
{
    public class HouseEditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public HouseEditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public House House { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5000/api/House/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                House = JsonConvert.DeserializeObject<House>(jsonData);
                return Page();
            }

            return RedirectToPage("DashBoard");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = new StringContent(JsonConvert.SerializeObject(House), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"http://localhost:5000/api/House/{House.Id}", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("DashBoard");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while updating the house.");
            return Page();
        }
    }
}
