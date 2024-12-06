using Microsoft.AspNetCore.Mvc;

namespace Laundry_O_Melch_Api.DTOs
{
    [BindProperties]
    public class ClienteFiltro
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Celular { get; set; }

        public string? Cpf { get; set; }

        public string? Cnpj { get; set; }

        public DateTime? Data {  get; set; }

        public bool? Todos {  get; set; }
    }
}
