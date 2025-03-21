using CrudDapperVideo.Dto;
using CrudDapperVideo.Models;

namespace CrudDapperVideo.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        public UsuarioService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Buscar todos usuários
        public Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
