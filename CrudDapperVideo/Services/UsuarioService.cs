﻿using System.Data.SqlClient;
using AutoMapper;
using CrudDapperVideo.Dto;
using CrudDapperVideo.Models;
using Dapper;

namespace CrudDapperVideo.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        //Buscar usuários por ID
        public async Task<ResponseModel<UsuarioListarDto>> BuscarUsuarioPorId(int usuarioId)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuarioBanco = await connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE ID = @Id", new { Id = usuarioId });
                
                if (usuarioBanco == null)
                {
                    response.Mensagem = "Nenhum usuário localizado";
                    response.Status = false;
                    return response;
                }

                //Mapear UsuarioBanco -> UsuarioListarDto
                var usuarioMapeado = _mapper.Map<UsuarioListarDto>(usuarioBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuário localizado com sucesso!";
                response.Status = true;
            }

            return response;    
        }

        //Buscar todos usuários
        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                //Comando para buscar todos usuários
                var usuariosBanco = await connection.QueryAsync<Usuario>("SELECT * FROM Usuarios");

                if (usuariosBanco.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário localizado";
                    response.Status = false;
                    return response;
                }

                //Transformar usuarios do banco (usuarios normais) para usuarios dto (usuarios sem as informações de cpf e senha).
                var usuariosMapeados = _mapper.Map<List<UsuarioListarDto>>(usuariosBanco);

                Console.WriteLine("Usuarios Mapeados (após mapeamento do Mapper: ");
                Console.WriteLine(usuariosMapeados);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuários localizados com sucesso!";
                response.Status = true;

                return response;
            }
        }


        //Criar usuário
        public async Task<ResponseModel<List<UsuarioListarDto>>> CriarUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                //Comando SQL para Criar usuário no banco
                var usuarioCriado = await connection.ExecuteAsync("INSERT INTO USUARIOS (NomeCompleto, Email, Cargo, Salario, CPF, Situacao, Senha)" +
                    "                                                            VALUES (@NomeCompleto, @Email, @Cargo, @Salario, @CPF, @Situacao, @Senha)", usuarioCriarDto);
                
                if (usuarioCriado == 0)
                {
                    response.Mensagem = "Nenhum usuário foi criado";
                    response.Status = false;
                    return response;
                }

                var usuariosBanco = await ListarUsuarios(connection);

                var usuariosMapeados = _mapper.Map<List<UsuarioListarDto>>(usuariosBanco);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuário criado com sucesso!";
                response.Status = true;

                return response;

            }
        }
        
        private static async Task<IEnumerable<Usuario>> ListarUsuarios(SqlConnection connection)
        {
            var usuariosBanco = await connection.QueryAsync<Usuario>("SELECT * FROM USUARIOS");
            return usuariosBanco;
        }
    }
}