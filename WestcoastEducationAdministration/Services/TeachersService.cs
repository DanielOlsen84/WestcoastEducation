using WestcoastEducationAdministration.Models;

namespace WestcoastEducationAdministration.Services
{
    public class TeachersService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;

        public TeachersService(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/teachers";
        }

        public async Task<List<Teacher>> GetAll()
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<List<Teacher>>() ?? new List<Teacher>();
        }

        public async Task<Teacher> Get(int id)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<Teacher>() ?? new Teacher();
        }

        public async Task<bool> Add(Teacher teacher)
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync(url, teacher);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Edit(int id, Teacher teacher)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.PutAsJsonAsync(url, teacher);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}
