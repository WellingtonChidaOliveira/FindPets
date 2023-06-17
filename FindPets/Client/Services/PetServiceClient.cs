using FindPets.Shared.Pets;
using System.Net.Http.Json;

namespace FindPets.Client.Services
{
    public class PetServiceClient : IPetService
    {
        private readonly HttpClient _httpClient;

        public PetServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Pet>> GetAllPets(SearchPet searchPet)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Pet>>($"api/pets?type={searchPet.Type}&status={searchPet.Status}&search={searchPet.Search}&page={searchPet.Page}&take={searchPet.Take}");
        }

        public async Task<Pet> GetPetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Pet>($"api/pets/{id}");
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            var response = await _httpClient.PostAsJsonAsync("api/pets", pet);
            return await response.Content.ReadFromJsonAsync<Pet>();
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/pets/{pet.Id}", pet);
            return await response.Content.ReadFromJsonAsync<Pet>();
        }

        public async Task<bool> DeletePet(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/pets/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
