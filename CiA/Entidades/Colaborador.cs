using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Colaborador : IColaborador
    {
        public Colaborador(string nome, string codigo, string telefone, string cargo, Endereco endereco, int loja)
        {
            Nome = nome;
            Codigo = codigo;
            Telefone = telefone;
            Cargo = cargo;
            Endereco = endereco;
            Loja = loja;
        }

        private string Nome { get; set; }
        private string Codigo { get; set; }
        private string Telefone { get; set; }
        private string Cargo { get; set; }
        private Endereco Endereco { get; set; }
        private int Loja { get; set; }

        public string GetCargo()
        {
            return Cargo;
        }

        public string GetCodigo()
        {
            return Codigo;
        }

        public Endereco GetEndereco()
        {
            return Endereco;
        }

        public string GetNome()
        {
            return Nome;
        }

        public string GetTelefone()
        {
            return Telefone;
        }

        public int GetLoja()
        {
            return Loja;
        }

        public void SetCargo(string value)
        {
            Cargo = value;
        }

        public void SetCodigo(string value)
        {
            Codigo = value;
        }

        public void SetEndereco(Endereco value)
        {
            Endereco = value;
        }

        public void SetNome(string value)
        {
            Nome = value;
        }

        public void SetTelefone(string value)
        {
            Telefone = value;
        }

        public void setLoja(int value)
        {
            Loja = value;
        }
    }
}
