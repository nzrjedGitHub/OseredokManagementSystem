using OseredokManagementSystem.Shared.DTOs.GymDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OseredokManagementSystem.Server.Infrastructure.Interfaces
{
    public interface IGymRepository
    {
        Task<IEnumerable<GymReadDto>> GetGymsAsync();

        Task<GymReadDto> GetGymByIdAsync(int gymId);

        Task<GymReadDto> UpdateGymAsync(GymUpdateDto gymUpdateDto);

        Task<int> DeleteAsync(int id);

        Task<int> CreateAsync(GymCreateDto gymCreateDto);
    }
}
