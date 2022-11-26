using OseredokManagementSystem.Shared.DTOs.ClientDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientReadDto>> GetClientsAsync();

        Task<IEnumerable<ClientReadDto>> GetClientsByGymIdAsync(int gymId);

        Task<IEnumerable<ClientReadDto>> GetClientsByLastNameAsync(string clientLn);

        Task<IEnumerable<ClientReadDto>> GetClientsByFirstNameAsync(string clientFn);

        Task<ClientReadDto> GetClientByIdAsync(int clientId);

        Task<ClientReadDto> GetClientByPhoneNumberAsync(string clientPn);

        Task<ClientReadDto> UpdateClientAsync(ClientUpdateDto client);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(ClientCreateDto userCreateDto);
    }
}