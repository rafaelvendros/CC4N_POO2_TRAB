using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface ILoja
    {
        public string getDescricao();
        public void setDescricao(string value);
        public Endereco getEndereco();
        public void setEndereco(Endereco value);
    }
}
