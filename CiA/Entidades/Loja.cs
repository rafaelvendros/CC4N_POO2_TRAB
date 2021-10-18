using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Loja : ILoja
    {
        public Loja(string descricao, Endereco endereco, int estoque)
        {
            Descricao = descricao;
            Endereco = endereco;
            Estoque = estoque;
        }

        private string Descricao { get; set; }
        private Endereco Endereco { get; set; }

        private int Estoque { get; set; }

        public string getDescricao()
        {
            return Descricao;
        }

        public Endereco getEndereco()
        {
            return Endereco;
        }

        public int getEstoque()
        {
            return Estoque;
        }

        public void setEstoque(int estoque)
        {
            Estoque = estoque;
        }

        public void setDescricao(string value)
        {
            Descricao = value;
        }

        public void setEndereco(Endereco value)
        {
            Endereco = value;
        }

    }
}