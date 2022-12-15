using AutoMapper;
using OseredokManagementSystem.Server.Core.Models;
using OseredokManagementSystem.Shared.DTOs.AdminDtos;
using OseredokManagementSystem.Shared.DTOs.ClientDtos;
using OseredokManagementSystem.Shared.DTOs.ClientPaymentDtos;
using OseredokManagementSystem.Shared.DTOs.CoachDtos;
using OseredokManagementSystem.Shared.DTOs.GymDtos;
using OseredokManagementSystem.Shared.DTOs.RoleDtos;
using OseredokManagementSystem.Shared.DTOs.SessionDtos;
using OseredokManagementSystem.Shared.DTOs.SessionStatusDtos;
using OseredokManagementSystem.Shared.DTOs.UserDtos;

namespace OseredokManagementSystem.Server.Infrastructure.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Role, RoleReadDto>();

            CreateMap<User, UserFullReadDto>();
            CreateMap<User, UserReadDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreateDto, User>();

            CreateMap<Admin, AdminReadDto>();
            CreateMap<Admin, AdminReadDto>();
            CreateMap<AdminUpdateDto, Admin>();
            CreateMap<AdminCreateDto, Admin>();

            CreateMap<Coach, CoachReadDto>();
            CreateMap<CoachUpdateDto, Coach>();
            CreateMap<CoachCreateDto, Coach>();

            CreateMap<Client, ClientReadDto>();
            CreateMap<Client, ClientShortReadDto>();
            CreateMap<ClientUpdateDto, Client>();
            CreateMap<ClientCreateDto, Client>();

            CreateMap<ClientPayment, ClientPaymentReadDto>();
            CreateMap<ClientPaymentUpdateDto, ClientPayment>();
            CreateMap<ClientCreateDto, ClientPayment>();

            CreateMap<Session, SessionReadDto>();
            CreateMap<SessionUpdateDto, Session>();
            CreateMap<SessionCreateDto, Session>();

            CreateMap<SessionStatus, SessionStatusReadDto>();

            CreateMap<Gym, GymReadDto>();
            CreateMap<GymUpdateDto, Gym>();
            CreateMap<GymCreateDto, Gym>();
        }
    }
}