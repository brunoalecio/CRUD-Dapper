using CrudDapperVideo.Dto;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Services
{
    public interface IUsuarioInterface
    {
        public Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
    }
}
