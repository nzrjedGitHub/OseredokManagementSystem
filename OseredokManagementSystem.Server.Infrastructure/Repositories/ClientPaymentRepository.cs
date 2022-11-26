using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OseredokManagementSystem.Server.Core;
using OseredokManagementSystem.Server.Infrastructure.Interfaces;
using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Repositories
{
    public class ClientPaymentRepository : IClientPaymentRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public ClientPaymentRepository(AppDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<ClientPaymentReadDto> GetClientPaymentByIdAsync(int clientPaymentId)
        {
            return _mapper.Map<ClientPaymentReadDto>(await _ctx.ClientPayments
                .FirstOrDefaultAsync(clientPayment => clientPayment.Id == clientPaymentId));
        }

        public async Task<ClientPaymentReadDto> UpdateClientPaymentAsync(ClientPaymentUpdateDto clientPaymentUpdateDto)
        {
            var clientPayment = await _ctx.ClientPayments.FindAsync(clientPaymentUpdateDto.Id);

            clientPayment.PaymentPerSession = clientPaymentUpdateDto.PaymentPerSession;

            clientPayment.Balance = clientPaymentUpdateDto.Balance;

            clientPayment.LastPaymentSum = clientPaymentUpdateDto.LastPaymentSum;

            clientPayment.LastPaymentDate = clientPaymentUpdateDto.LastPaymentDate;

            await _ctx.SaveChangesAsync();

            return _mapper.Map<ClientPaymentReadDto>(clientPayment);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var temp = _ctx.ClientPayments.Find(id);

            if (temp != null)
            {
                _ctx.Remove(temp);
            }
            await _ctx.SaveChangesAsync();

            return 200;
        }
    }
}