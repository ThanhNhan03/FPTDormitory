using client_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace client_app.Pages
{
    public class DashBoardModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DashBoardModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Houses = new List<House>(); // Khởi tạo danh sách Rooms
        }

        public List<House> Houses { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000/api/House");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Houses = JsonConvert.DeserializeObject<List<House>>(jsonData);
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5000/api/House/{id}");
            if (response.IsSuccessStatusCode)
            {
                // Reload the list of houses after a successful delete
                var updatedResponse = await _httpClient.GetAsync("http://localhost:5000/api/House");
                if (updatedResponse.IsSuccessStatusCode)
                {
                    var jsonData = await updatedResponse.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<List<House>>(jsonData);
                }

                return RedirectToPage();
            }

            // Handle the case when delete was not successful
            ModelState.AddModelError(string.Empty, "An error occurred while deleting the house.");
            return Page();
        }
    }
}
