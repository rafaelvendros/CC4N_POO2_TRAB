using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface ICliente
    {
        public string GetNome();
        public void SetNome(string value);
        public string GetCPF();
        public void SetCPF(string value);
        public string GetTelefone();
        public void SetTelefone(string value);
        public string GetEmail();
        public void SetEmail(string value);
        public Endereco GetEndereco();
        public void SetEndereco(Endereco value);
    }
}
