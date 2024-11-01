﻿using APIVisionary.Data;
using APIVisionary.Dto.Conteudo;
using APIVisionary.Dto.PlaylistVideos;
using APIVisionary.Models;
using Microsoft.EntityFrameworkCore;

namespace APIVisionary.Services.Playlist
{
    public class PlaylistService : PlaylistInterface
    {
        private readonly ApplicationDbContext _context;
        public PlaylistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<PlaylistVideos>> BuscarPlaylistID(int IDPlaylist)
        {
            ResponseModel<PlaylistVideos> resposta = new ResponseModel<PlaylistVideos>();

            try
            {
                var Playlist = await _context.PlaylisTableContent.Include(a => a.Creator).FirstOrDefaultAsync(PlaylistBanco => PlaylistBanco.Id == IDPlaylist);
                if (Playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizado";
                    return resposta;
                }
                resposta.Dados = Playlist;
                resposta.Mensagem = "Playlist encontrada";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PlaylistVideos>> BuscarPlaylistNome(string NomePlaylist)
        {
            ResponseModel<PlaylistVideos> resposta = new ResponseModel<PlaylistVideos>();
            try
            {
                var Playlist = await _context.PlaylisTableContent.Include(a => a.Creator)
                    .FirstOrDefaultAsync(PlaylistBanco => PlaylistBanco.PlaylistTittle == NomePlaylist);
                if (Playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizada";
                    return resposta;
                }
                resposta.Dados = Playlist;
                resposta.Mensagem = "Playlist encontrada";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistVideos>>> BuscarPlaylistPorIDUsuario(int IDUsuario)
        {
            ResponseModel<List<PlaylistVideos>> resposta = new ResponseModel<List<PlaylistVideos>>();

            try
            {
                var Playlist = await _context.PlaylisTableContent
                    .Include(a => a.Creator).Where(PlaylistBanco => PlaylistBanco.Creator.Id == IDUsuario)
                    .ToListAsync();
                if

                    (Playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizada";
                    return resposta;
                }
                resposta.Dados = Playlist;
                resposta.Mensagem = "Playlist Localizadas";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistVideos>>> CriarPlaylist(CriarPlaylistDto criarPlaylistDto)
        {
            ResponseModel<List<PlaylistVideos>> resposta = new ResponseModel<List<PlaylistVideos>>();

            try
            {
                var Usuario = await _context.UsuariosTableContent.FirstOrDefaultAsync(UsuarioBanco => UsuarioBanco.Id == criarPlaylistDto.Creator);
                if (Usuario == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }


                var playlist = new PlaylistVideos()
                {
                    PlaylistTittle = criarPlaylistDto.PlaylistTittle,
                    Creator = Usuario

                };

                _context.Add(playlist);
                await _context.SaveChangesAsync();



                resposta.Dados = await _context.PlaylisTableContent.Include(a => a.Creator).ToListAsync();
                resposta.Mensagem = $"Playlist {playlist.PlaylistTittle} Criada com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistVideos>>> EditarPlaylist(EditarPlaylistDto editarPlaylistDto)
        {
            ResponseModel<List<PlaylistVideos>> resposta = new ResponseModel<List<PlaylistVideos>>();

            try
            {

                var Playlist = await _context.PlaylisTableContent.Include(a => a.Creator)
                    .FirstOrDefaultAsync(ConteudoBanco => ConteudoBanco.Id == editarPlaylistDto.Id);

                var Autor = await _context.UsuariosTableContent
                    .FirstOrDefaultAsync(AutorBanco => AutorBanco.Id == editarPlaylistDto.Creator);

                if (Playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizada";
                    return resposta;
                }

                if (Autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado";
                    return resposta;
                }


                Playlist.PlaylistTittle = editarPlaylistDto.PlaylistTittle;
                

                _context.Update(Playlist);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.PlaylisTableContent.ToListAsync();
                resposta.Mensagem = "Playlist Editada com sucesso";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistVideos>>> ExcluirPlaylist(int IDPlaylist)
        {
            ResponseModel<List<PlaylistVideos>> resposta = new ResponseModel<List<PlaylistVideos>>();
            try
            {
                var Playlist = await _context.PlaylisTableContent
                    .FirstOrDefaultAsync(PlaylistBanco => PlaylistBanco.Id == IDPlaylist);

                if (Playlist == null)
                {
                    resposta.Mensagem = "Nenhuma playlist localizado";
                    return resposta;
                }

                _context.Remove(Playlist);

                resposta.Mensagem = $"Conteúdo {Playlist.PlaylistTittle} Excluida Permanentemente";
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.PlaylisTableContent.ToListAsync();
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PlaylistVideos>>> ListarPlaylist()
        {
            ResponseModel<List<PlaylistVideos>> resposta = new ResponseModel<List<PlaylistVideos>>();

            try
            {

                var Playlist = await _context.PlaylisTableContent.Include(a => a.Creator).ToListAsync();

                resposta.Dados = Playlist;
                resposta.Mensagem = "Todos os Conteudos encontrados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
