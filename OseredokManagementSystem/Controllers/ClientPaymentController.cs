using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/clientPayments")]
    [ApiController]
    public class ClientPaymentController
    {
        private readonly IClientPaymentRepository _clentPaymentRepository;

        public ClientPaymentController(IClientPaymentRepository clientPaymentRepository)
        {
            _clentPaymentRepository = clientPaymentRepository;
        }

        [HttpGet]
        [Route("GetClientPaymentById/{clientPaymentId}")]
        [ProducesResponseType(200, Type = typeof(ClientPaymentReadDto))]
        public async Task<ClientPaymentReadDto> GetClientPaymentById(int clientPaymentId)
        {
            return await _clentPaymentRepository.GetClientPaymentByIdAsync(clientPaymentId);
        }

        [HttpPut]
        [Route("UpdateClientPayment")]
        public async Task<ClientPaymentReadDto> UpdateClientPayment(ClientPaymentUpdateDto paymentUpdateDto)
        {
            return await _clentPaymentRepository.UpdateClientPaymentAsync(paymentUpdateDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _clentPaymentRepository.DeleteAsync(id);
        }
    }
}