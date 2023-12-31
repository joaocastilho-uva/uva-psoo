﻿using App.Data;
using App.Models;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly ArteConexaoDbContext arteConexaoDbContext;

        public CarrinhoRepository(ArteConexaoDbContext arteConexaoDbContext)
        {
            this.arteConexaoDbContext = arteConexaoDbContext;
        }

        public async Task<Carrinho> AddAsync(Carrinho carrinho)
        {
            await arteConexaoDbContext.Carrinhos.AddAsync(carrinho);
            await arteConexaoDbContext.SaveChangesAsync();
            return carrinho;
        }

        public async Task<Carrinho> GetAsync(Guid userId)
        {
            return await arteConexaoDbContext.Carrinhos.Include(nameof(Carrinho.ItensCarrinho)).FirstOrDefaultAsync(x => x.UsuarioId == userId);
        }

        public async Task<Carrinho> UpdateAsync(Carrinho carrinho)
        {
            var carrinhoDb = await arteConexaoDbContext.Carrinhos.FirstOrDefaultAsync(x => x.Id == carrinho.Id);

            if (carrinhoDb == null) 
            {
                if (carrinho.ItensCarrinho.Any())
                {
                    arteConexaoDbContext.ItensCarrinho.RemoveRange(carrinhoDb.ItensCarrinho);

                    carrinho.ItensCarrinho.ToList().ForEach(x => x.CarrinhoId = carrinho.Id);
                    await arteConexaoDbContext.ItensCarrinho.AddRangeAsync(carrinho.ItensCarrinho);
                }
            }

            await arteConexaoDbContext.SaveChangesAsync();
            return carrinho;
        }
    }
}
