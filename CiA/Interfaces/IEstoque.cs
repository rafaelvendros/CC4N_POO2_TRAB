using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiA.Interfaces
{
    interface IEstoque
    {
        public void entradaProduto( Produto Produto, int Quantidade, string codigo_estoque);
        public void removerProduto(string categoria_remover, string descrição_remover, string estoque_remover);
        public string getCodigo();
        public void setCodigo(string value);
    }
}
