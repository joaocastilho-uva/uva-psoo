﻿using App.Models;
using Microsoft.AspNetCore.Identity;

namespace App.Repositories.Interfaces
{
    public interface IReservaRepository
    {
        Task<Reserva> AddAsync(Reserva reserva);
        Task<Reserva> GetAsync(Guid id);
        //Task<IEnumerable<Reserva>> GetAllAsync(Stand stand);
        Task<IEnumerable<Reserva>> GetAllAsync(IdentityUser identityUser);
        Task<Reserva> UpdateAsync(Reserva reserva);
    }
}
