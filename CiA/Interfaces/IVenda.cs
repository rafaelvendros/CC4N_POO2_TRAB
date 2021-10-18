using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface IVenda
    {
        public string getCodigo();
        public void setCodigo(string value);
        public int getCliente();
        public void setCliente(int value);
        public int getColaborador();
        public void setColaborador(int value);
        public double getValor();
        public void setValor(double value);

        public void setSituacao(string value);

        public string getSituacao();
    }
}
