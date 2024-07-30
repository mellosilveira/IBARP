using IBARP.DataContracts.Modelos;
using System;

namespace IBARP.DataContracts.AdicionarMembro
{
    public class AdicionarMembroRequest
    {
        public string Nome { get; set; }

        public Genero Genero { get; set; }

        public Ministério Ministério { get; set; }

        public string Cargo { get; set; }

        public string Endereço { get; set; }

        public string CEP { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public EstadoCivil EstadoCivil { get; set; }

        public bool Batizado { get; set; }

        public string Celular { get; set; }

        public string Telefone { get; set; }
    }
}
