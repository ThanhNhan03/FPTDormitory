using client_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace client_app.Pages
{
    public class HouseFormModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public HouseFormModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public House House { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = new StringContent(JsonConvert.SerializeObject(House), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("http://localhost:5000/api/House", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("DashBoard");
            }

            ModelState.AddModelError(string.Empty, "An error occurred while adding the house.");
            return Page();
        }
    }
}
