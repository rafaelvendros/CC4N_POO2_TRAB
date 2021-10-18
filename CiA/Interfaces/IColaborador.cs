using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface IColaborador
    {
        public string GetNome();
        public void SetNome(string value);
        public string GetCodigo();
        public void SetCodigo(string value);
        public string GetTelefone();
        public void SetTelefone(string value);
        public string GetCargo();
        public void SetCargo(string value);
        public Endereco GetEndereco();
        public void SetEndereco(Endereco value);

    }
}
