using System.Text.Json;
using WestcoastEducationAdministration.Models;

namespace WestcoastEducationAdministration.Services
{
    public class CoursesService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;

        public CoursesService(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/courses";
        }

        public async Task<List<Course>> GetAll()
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<List<Course>>() ?? new List<Course>();
        }

        public async Task<Course> Get(int id)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<Course>() ?? new Course();
        }

        public async Task<bool> Add(Course course)
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync(url, course);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Edit(int id, Course course)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.PutAsJsonAsync(url, course);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}
