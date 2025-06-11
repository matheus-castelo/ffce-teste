// INFRA/DTOs/Cliente/ClienteDto.cs

namespace APPLICATION.DTO.Cliente
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public static ClienteDto ToDto(INFRA.Models.Cliente entity)
        {
            if (entity == null) return null;
            return new ClienteDto
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Endereco = entity.Endereco,
                Email = entity.Email,
                Telefone = entity.Telefone
            };
        }

        public static INFRA.Models.Cliente ToEntity(ClienteDto dto)
        {
            if (dto == null) return null;
            return new INFRA.Models.Cliente
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Endereco = dto.Endereco,
                Email = dto.Email,
                Telefone = dto.Telefone
            };
        }
    }
}