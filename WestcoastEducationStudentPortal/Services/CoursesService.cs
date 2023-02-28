using System.Text.Json;
using WestcoastEducationStudentPortal.Models;

namespace WestcoastEducationStudentPortal.Services
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
    }
}
