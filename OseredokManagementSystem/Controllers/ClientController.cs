using Microsoft.AspNetCore.Mvc;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.ClientDtos;

namespace OseredokManagementSystem.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClientReadDto>))]
        public async Task<IEnumerable<ClientReadDto>> GetClients()
        {
            return await _clientRepository.GetClientsAsync();
        }

        [HttpGet]
        [Route("gym/{gymId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ClientReadDto>))]
        public async Task<IEnumerable<ClientReadDto>> GetClientsByGymId(int gymId)
        {
            return await _clientRepository.GetClientsByGymIdAsync(gymId);
        }

        //[HttpGet]
        //[Route("api/clients/GetClientsByLastName/{clientLn}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<ClientReadDto>))]
        //public async Task<IEnumerable<ClientReadDto>> GetClientsByLastName(string clientLn)
        //{
        //    return await _clientRepository.GetClientsByLastNameAsync(clientLn);
        //}

        //[HttpGet]
        //[Route("api/clients/GetClientsByFirstName/{clientFn}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<ClientReadDto>))]
        //public async Task<IEnumerable<ClientReadDto>> GetClientsByFirstName(string clientFn)
        //{
        //    return await _clientRepository.GetClientsByFirstNameAsync(clientFn);
        //}

        [HttpGet]
        [Route("{clientId}")]
        [ProducesResponseType(200, Type = typeof(ClientReadDto))]
        public async Task<ClientReadDto> GetClientById(int clientId)
        {
            return await _clientRepository.GetClientByIdAsync(clientId);
        }

        //[HttpGet]
        //[Route("api/clients/GetClientByPhoneNumber/{clientPn}")]
        //[ProducesResponseType(200, Type = typeof(ClientReadDto))]
        //public async Task<ClientReadDto> GetClientByPhoneNumber(string clientPn)
        //{
        //    return await _clientRepository.GetClientByPhoneNumberAsync(clientPn);
        //}

        [HttpPut]
        public async Task<ClientReadDto> UpdateClient(ClientUpdateDto clientUpdateDto)
        {
            return await _clientRepository.UpdateClientAsync(clientUpdateDto);
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task<int> DeleteAsync(int clientId)
        {
            return await _clientRepository.DeleteAsync(clientId);
        }

        [HttpPost]
        public async Task<int> CreateAsync(ClientCreateDto clientCreateDto)
        {
            return await _clientRepository.CreateAsync(clientCreateDto);
        }
    }
}