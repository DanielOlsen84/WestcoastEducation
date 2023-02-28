using WestcoastEducationAdministration.Models;

namespace WestcoastEducationAdministration.Services
{
    public class StudentsService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;

        public StudentsService(IConfiguration config)
        {
            _config = config;
            _baseUrl = $"{_config.GetValue<string>("baseUrl")}/Students";
        }

        public async Task<List<Student>> GetAll()
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<List<Student>>() ?? new List<Student>();
        }

        public async Task<Student> Get(int id)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Oops, something went wrong.");
            }

            return await response.Content.ReadFromJsonAsync<Student>() ?? new Student();
        }

        public async Task<bool> Add(Student student)
        {
            var url = $"{_baseUrl}";

            using var http = new HttpClient();
            var response = await http.PostAsJsonAsync(url, student);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Edit(int id, Student student)
        {
            var url = $"{_baseUrl}/{id}";

            using var http = new HttpClient();
            var response = await http.PutAsJsonAsync(url, student);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}
