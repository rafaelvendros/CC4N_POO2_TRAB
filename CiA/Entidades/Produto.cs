using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Produto : IProduto
    {
        public Produto(string descricao, double valor, string categoria)
        {
            Descricao = descricao;
            Valor = valor;
            Categoria = categoria;
        }

        private string Descricao { get; set; }
        private double Valor { get; set; }
        private string Categoria { get; set; }

        public string GetCategoria()
        {
            return Categoria;
        }

        public string GetDescricao()
        {
            return Descricao;
        }

        public double GetValor()
        {
            return Valor;
        }

        public void SetCategoria(string value)
        {
            Categoria = value;
        }

        public void SetDescricao(string value)
        {
            Descricao = value;
        }

        public void SetValor(double value)
        {
            Valor = value;
        }
    }
}
