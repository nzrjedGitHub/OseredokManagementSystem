using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IClientPaymentRepository
    {
        Task<ClientPaymentReadDto> GetClientPaymentByIdAsync(int clientPaymentId);

        Task<ClientPaymentReadDto> UpdateClientPaymentAsync(ClientPaymentUpdateDto clientPaymentUpdateDto);

        Task<int> DeleteAsync(int id);
    }
}