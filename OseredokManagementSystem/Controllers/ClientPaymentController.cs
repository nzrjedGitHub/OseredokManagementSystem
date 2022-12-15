using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/client-payments")]
    [ApiController]
    public class ClientPaymentController
    {
        private readonly IClientPaymentRepository _clentPaymentRepository;

        public ClientPaymentController(IClientPaymentRepository clientPaymentRepository)
        {
            _clentPaymentRepository = clientPaymentRepository;
        }

        [HttpGet]
        [Route("{clientPaymentId}")]
        [ProducesResponseType(200, Type = typeof(ClientPaymentReadDto))]
        public async Task<ClientPaymentReadDto> GetClientPaymentById(int clientPaymentId)
        {
            return await _clentPaymentRepository.GetClientPaymentByIdAsync(clientPaymentId);
        }

        [HttpPut]
        public async Task<ClientPaymentReadDto> UpdateClientPayment(ClientPaymentUpdateDto paymentUpdateDto)
        {
            return await _clentPaymentRepository.UpdateClientPaymentAsync(paymentUpdateDto);
        }

        [HttpDelete]
        [Route("{clientPaymentId}")]
        public async Task<int> DeleteAsync(int clientPaymentId)
        {
            return await _clentPaymentRepository.DeleteAsync(clientPaymentId);
        }
    }
}