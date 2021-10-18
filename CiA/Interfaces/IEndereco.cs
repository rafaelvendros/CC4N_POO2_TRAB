using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA
{
    interface IEndereco
    {
        public string GetRua();
        public void SetRua(string value);
        public int GetNumero();
        public void SetNumero(int value);
        public string GetComplemento();
        public void SetComplemento(string value);
        public string GetBairro();
        public void SetBairro(string value);
        public string GetCidade();
        public void SetCidade(string value);
        public string GetEstado();
        public void SetEstado(string value);
    }
}
