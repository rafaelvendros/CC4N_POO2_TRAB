using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface IProduto
    {
        public string GetDescricao();
        public void SetDescricao(string value);
        public double GetValor();
        public void SetValor(double value);
        public string GetCategoria();
        public void SetCategoria(string value);
       
    }
}
