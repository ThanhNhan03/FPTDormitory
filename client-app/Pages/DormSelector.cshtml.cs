using client_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace client_app.Pages
{
   
        public class DormSelectorModel : PageModel
        {
            private readonly HttpClient _httpClient;

            public DormSelectorModel(HttpClient httpClient)
            {
                _httpClient = httpClient;
                Dorms = new List<Dorm>();
                SelectedDormFloors = new List<Floor>();
            }

            public List<Dorm> Dorms { get; set; }
            public List<Floor> SelectedDormFloors { get; set; }
            public Guid SelectedDormId { get; set; }

            public async Task OnGetAsync()
            {
                var response = await _httpClient.GetAsync("http://localhost:5000/api/Dorm");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    Dorms = JsonConvert.DeserializeObject<List<Dorm>>(jsonData);
                }
            }

            public async Task<IActionResult> OnPostSelectDormAsync(Guid dormId)
            {
                SelectedDormId = dormId;
                var response = await _httpClient.GetAsync($"http://localhost:5000/api/Dorm/{dormId}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var selectedDorm = JsonConvert.DeserializeObject<Dorm>(jsonData);
                    SelectedDormFloors = selectedDorm.Floors;
                }
                return Page();
            }
        }
    }

