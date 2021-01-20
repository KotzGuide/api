using Api.Core;
using Api.Core.Models;
using Api.Models.Validations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class UsuarioModel : BaseModel
    {
        public UsuarioModel(string UserName, string Senha)
        {
            this.UserName = UserName;
            this.Senha = Senha;
        }
        public int Id { get; private set; }
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; private set; }
        [Column(TypeName = "varchar(50)")]
        [JsonIgnore]
        public string Senha { get; private set; }
        [NotMapped]
        public string Jwt { get; set; }
        [JsonIgnore]
        public int Role { get; set; }

        public bool Validate(ErrorContext errorContext)
        {
            return Validate(this, new UsuarioValidator(), errorContext);
        }

        public void UpdateSenha(string pass) => Senha = pass;
    }
}
