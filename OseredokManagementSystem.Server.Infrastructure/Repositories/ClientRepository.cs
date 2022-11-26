using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.ClientDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public ClientRepository(AppDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<ClientReadDto> GetClientByIdAsync(int clientId)
        {
            return _mapper.Map<ClientReadDto>(await _ctx.Clients
                .Include(client => client.User)
                .Include(client => client.ClientPayment)
                .FirstOrDefaultAsync(client => client.Id == clientId));
        }

        public async Task<ClientReadDto> GetClientByPhoneNumberAsync(string clientPn)
        {
            return _mapper.Map<ClientReadDto>(await _ctx.Clients
                .Include(client => client.User)
                .Include(client => client.ClientPayment)
                .FirstOrDefaultAsync(client => client.User.PhoneNumber == clientPn));
        }

        public async Task<IEnumerable<ClientReadDto>> GetClientsAsync()
        {
            return _mapper.Map<IEnumerable<ClientReadDto>>(await _ctx.Clients
                .Include(admin => admin.User)
                .Include(client => client.ClientPayment)
                .ToListAsync());
        }

        public async Task<IEnumerable<ClientReadDto>> GetClientsByFirstNameAsync(string clientFn)
        {
            return _mapper.Map<IEnumerable<ClientReadDto>>(await _ctx.Clients
                .Include(admin => admin.User)
                .Include(client => client.ClientPayment)
                .Where(client => client.User.FirstName == clientFn)
                .ToListAsync());
        }

        public async Task<IEnumerable<ClientReadDto>> GetClientsByLastNameAsync(string clientLn)
        {
            return _mapper.Map<IEnumerable<ClientReadDto>>(await _ctx.Clients
                .Include(admin => admin.User)
                .Include(client => client.ClientPayment)
                .Where(client => client.User.FirstName == clientLn)
                .ToListAsync());
        }

        public async Task<IEnumerable<ClientReadDto>> GetClientsByGymIdAsync(int gymId)
        {
            return _mapper.Map<IEnumerable<ClientReadDto>>(await _ctx.Clients
                .Include(admin => admin.User)
                .Include(client => client.ClientPayment)
                .Where(client => client.Gym.Id == gymId)
                .ToListAsync());
        }

        public async Task<ClientReadDto> UpdateClientAsync(ClientUpdateDto clientUpdateDto)
        {
            var client = await _ctx.Clients.FindAsync(clientUpdateDto.Id);

            client.CoachId = clientUpdateDto.CoachId;

            client.GymId = clientUpdateDto.GymId;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<ClientReadDto>(client);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.Clients.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }

        public async Task<int> CreateAsync(ClientCreateDto clientCreateDto)
        {
            var client = _mapper.Map<Client>(clientCreateDto);
            var clientPayment = _mapper.Map<ClientPayment>(clientCreateDto);
            clientPayment.Balance = 0;
            clientPayment.LastPaymentDate = DateTime.Now;
            clientPayment.LastPaymentSum = 0;
            await _ctx.AddAsync(clientPayment);
            await _ctx.SaveChangesAsync();

            client.ClientPaymentId = clientPayment.Id;
            await _ctx.Clients.AddAsync(client);
            await _ctx.SaveChangesAsync();

            return client.Id;
        }
    }
}