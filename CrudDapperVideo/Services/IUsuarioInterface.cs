using CrudDapperVideo.Dto;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Services
{
    public interface IUsuarioInterface
    {
        public Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
        public Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId);
        public Task<ResponseModel<List<UsuarioListarDto>>> CriarUsuario(UsuarioCriarDto usuarioCriarDto);
        public Task<ResponseModel<List<UsuarioListarDto>>> EditarUsuario(UsuarioEditarDto usuarioEditarDto);
    }
}
