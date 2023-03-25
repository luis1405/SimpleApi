using Domain.Entities;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    internal class HumanoRepository : IHumanoRepository
    {
        private readonly AppDbContext _appDbContext;
        public HumanoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Agregar(HumanoDTO entidad)
        {
            Humano humano = new Humano()
            { 
                Nombre = entidad.Nombre,
                Sexo = entidad.Sexo,
                Edad = entidad.Edad,
                Altura = entidad.Altura,
                Peso = entidad.Peso,
            };
            _appDbContext.Add(humano);
            return await Guardar();
        }

        public async Task<int> Editar(HumanoDTO entidad)
        {
            Humano humano = await _appDbContext.Humanos.Where(r => r.Id == entidad.Id).FirstOrDefaultAsync();
            if (humano == null)
                return 0;
            humano.Nombre = entidad.Nombre;
            humano.Sexo = entidad.Sexo;
            humano.Edad = entidad.Edad;
            humano.Altura = entidad.Altura;
            humano.Peso = entidad.Peso;


            _appDbContext.Update(humano);
            return await Guardar();
        }

        public async Task<int> Eliminar(int entidadID)
        {
            Humano humano = await _appDbContext.Humanos.Where(r => r.Id == entidadID).FirstOrDefaultAsync();

            if (humano == null)
                return 0;

            _appDbContext.Remove(humano);
            return await Guardar();
        }

        public async Task<List<HumanoDTO>> Listar()
        {
            List<Humano> resultDb = await _appDbContext.Humanos.ToListAsync();

            List<HumanoDTO> humanos = resultDb.Select(r => new HumanoDTO()
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Sexo = r.Sexo,
                Edad = r.Edad,
                Altura = r.Altura,
                Peso = r.Peso,
            }).ToList();

            return humanos;
        }

        public async Task<HumanoDTO> SeleccionarPorID(int entidadID)
        {
            Humano humano = await _appDbContext.Humanos.Where(r => r.Id == entidadID).FirstOrDefaultAsync();

            if (humano == null)
                return null;

            return new HumanoDTO()
            {
                Id = humano.Id,
                Nombre = humano.Nombre,
                Sexo = humano.Sexo,
                Edad = humano.Edad,
                Altura = humano.Altura,
                Peso = humano.Peso,
            };
        }
        private async Task<int> Guardar()
        {
            try
            {
                return await _appDbContext.SaveChangesAsync();
            }
            catch
            {
                return 0;

            }
        }
    }
}
