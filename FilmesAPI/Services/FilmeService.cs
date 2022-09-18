using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.DTOs.Filme;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeService : IFilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseFilmeDTO AdicionaFilme(RequestFilmeDTO filmeDto)
        {
            /*
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
                Diretor = filmeDto.Diretor
                
            };
            */
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            ResponseFilmeDTO responseFilmDto = _mapper.Map<ResponseFilmeDTO>(filme);
            return responseFilmDto;
        }

        public List<ResponseFilmeDTO> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ResponseFilmeDTO> responseFIlmes = _mapper.Map<List<ResponseFilmeDTO>>(filmes);
                return responseFIlmes;
            }
            return null;
        }

        public ResponseFilmeDTO RecuperaFilmePorId(int id)
        {
            // -- Pelo meio manual --------------------------------------------------------
            /*
            foreach (Filme filme in filmes)
            {
                if (filme.Id == id)
                {
                    return filme;
                }
            }
            return null;
            */

            // -- Pelo meio automatico (usando funções do C#) -----------------------------
            /*
            return filmes.FirstOrDefault(filme => filme.Id == id);
            */

            // -- Agora retornando com IActionResult ivés de Filme diretamente ------------
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                // Mapeando o DTO manualmente ----------------------
                /*
                ResponseFIlmeDTO filmeDto = new ResponseFIlmeDTO
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Duracao = filme.Duracao,
                    Genero = filme.Genero,
                    HoraDaConsulta = DateTime.Now
                };
                */
                // Mapeando o DTO com AutoMapper ----------------------
                ResponseFilmeDTO filmeDto = _mapper.Map<ResponseFilmeDTO>(filme);
                return filmeDto;
            }
            return null;
        }

        public int AtualizaFilme(int id, RequestFilmeDTO filmeUpdate)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _mapper.Map(filmeUpdate, filme);
                /*
                filme.Titulo = filmeUpdate.Titulo;
                filme.Diretor = filmeUpdate.Diretor;
                filme.Genero = filmeUpdate.Genero;
                filme.Duracao = filmeUpdate.Duracao;
                */
                _context.SaveChanges();
                return StatusCodes.Status200OK;
            }
            return StatusCodes.Status404NotFound;
        }

        public int DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return StatusCodes.Status200OK;
            }
            return StatusCodes.Status404NotFound;
        }
    }
}
