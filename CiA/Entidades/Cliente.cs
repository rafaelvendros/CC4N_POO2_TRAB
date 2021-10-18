using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Cliente : ICliente
    {
        public Cliente()
        {
        }

        public Cliente(string nome, string cpf, string telefone, string email, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Telefone { get; set; }
        private string Email { get; set; }
        private Endereco Endereco { get; set; }

        public string GetCPF()
        {
            return Cpf;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetNome()
        {
            return Nome;
        }

        public string GetTelefone()
        {
            return Telefone;
        }
        public Endereco GetEndereco()
        {
            return Endereco;
        }

        public void SetCPF(string value)
        {
            Cpf = value;
        }

        public void SetEmail(string value)
        {
            Email = value; 
        }

        public void SetNome(string value)
        {
            Nome = value;
        }

        public void SetTelefone(string value)
        {
            Telefone = value;
        }
        public void SetEndereco(Endereco value)
        {
            Endereco = value;
        }

    }

}
