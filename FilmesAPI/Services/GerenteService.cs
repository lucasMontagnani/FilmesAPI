using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.DTOs.Gerente;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteService : IGerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
                return gerenteDto;
            }
            return null;
        }
        public int DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return StatusCodes.Status200OK;
            }
            return StatusCodes.Status404NotFound;

        }
    }
}
