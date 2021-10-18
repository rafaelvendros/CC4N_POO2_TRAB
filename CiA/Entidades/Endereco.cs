using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Endereco : IEndereco
    {
        public Endereco()
        {
        }

        public Endereco(string rua, int numero, string complemento, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        private string Rua { get; set; }
        private int Numero { get; set; }
        private string Complemento { get; set; }
        private string Bairro { get; set; }
        private string Cidade { get; set; }
        private string Estado { get; set; }

        public string GetBairro()
        {
            return Bairro;
        }

        public string GetCidade()
        {
            return Cidade;
        }

        public string GetComplemento()
        {
            return Complemento;
        }

        public string GetEstado()
        {
            return Estado;
        }

        public int GetNumero()
        {
            return Numero;
        }

        public string GetRua()
        {
            return Rua;
        }
        public void SetBairro(string value)
        {
            Bairro = value;
        }

        public void SetCidade(string value)
        {
            Cidade = value;
        }

        public void SetComplemento(string value)
        {
            Complemento = value;
        }

        public void SetEstado(string value)
        {
            Estado = value;
        }

        public void SetNumero(int value)
        {
            Numero = value;
        }

        public void SetRua(string value)
        {
            Rua = value;
        }

    }
}
