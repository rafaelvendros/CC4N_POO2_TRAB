using CiA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Entidades
{
    class Venda : IVenda
    {

        private string Codigo { get; set; }
        private int Cliente { get; set; }
        private double Valor { get; set; }
        private int Colaborador { get; set; }

        private int Loja { get; set; }

        private string Situacao { get; set; }

        public Venda()
        {

        }

        public Venda(string codigo, int cliente, double valor, int colaborador, int loja, string situacao)
        {
            Codigo = codigo;
            Cliente = cliente;
            Valor = valor;
            Colaborador = colaborador;
            Loja = loja;
            Situacao = situacao;
        }

        public string getCodigo()
        {
            return Codigo;
        }

        public int getCliente()
        {
            return Cliente;
        }

        public int getColaborador()
        {
            return Colaborador;
        }

        public double getValor()
        {
            return Valor;
        }

        public int getLoja()
        {
            return Loja;
        }

        public string getSituacao()
        {
            return Situacao;
        }

        public void setCodigo(string value)
        {
            Codigo = value;
        }

        public void setCliente(int value)
        {
            Cliente = value;
        }

        public void setColaborador(int value)
        {
            Colaborador = value;
        }

        public void setValor(double value)
        {
            Valor = value;
        }

        public void setLoja(int value)
        {
            Loja = value;
        }

        public void setSituacao(string value)
        {
            Situacao = value;
        }
    }
}