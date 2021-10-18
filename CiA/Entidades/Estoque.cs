using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiA.Interfaces;

namespace CiA.Entidades
{
    class Estoque : IEstoque
    {
        private string Codigo { get; set; }
        private Endereco Endereco;

        public Estoque(string codigo, Endereco endereco)
        {
            Codigo = codigo;
            Endereco = endereco;
        }

        public Estoque()
        {
            
        }

        public void entradaProduto( Produto p, int quantidade , string codigo_estoque)
        {
            ConexaoDataBase databaseObject = new ConexaoDataBase();

            string queryProduto = "INSERT INTO Produto (`Descricao`,`Valor`,`Categoria`) VALUES (@Descricao,@Valor,@Categoria)";
            SQLiteCommand myCommandProduto = new SQLiteCommand(queryProduto, databaseObject.myConnection);
            databaseObject.OpenConnection();
            myCommandProduto.Parameters.AddWithValue("@Descricao", p.GetDescricao());
            myCommandProduto.Parameters.AddWithValue("@Valor", p.GetValor());
            myCommandProduto.Parameters.AddWithValue("@Categoria", p.GetCategoria());

            var resultMyCommandProduto = myCommandProduto.ExecuteNonQuery();
            databaseObject.CloseConnection();

            databaseObject.OpenConnection();
            string getEstoqueId = "SELECT idEstoque FROM Estoque WHERE Codigo = @Codigo";
            SQLiteCommand myCommandgetEstoqueId = new SQLiteCommand(getEstoqueId, databaseObject.myConnection);
            int idEstoque = 0;

            myCommandgetEstoqueId.Parameters.AddWithValue("@Codigo", codigo_estoque);

            SQLiteDataReader resultMyCommandgetEstoqueId = myCommandgetEstoqueId.ExecuteReader();
            while (resultMyCommandgetEstoqueId.Read())
            {
                idEstoque = resultMyCommandgetEstoqueId.GetInt32(0);

            }

            databaseObject.CloseConnection();

            databaseObject.OpenConnection();
            string getProdutoId = "SELECT idProduto FROM Produto WHERE Descricao = @Descricao AND Valor = @Valor AND Categoria = @Categoria";
            SQLiteCommand myCommandgetProdutoId = new SQLiteCommand(getProdutoId, databaseObject.myConnection);
            int idProduto = 0;

            myCommandgetProdutoId.Parameters.AddWithValue("@Descricao", p.GetDescricao());
            myCommandgetProdutoId.Parameters.AddWithValue("@Valor", p.GetValor());
            myCommandgetProdutoId.Parameters.AddWithValue("@Categoria", p.GetCategoria());

            SQLiteDataReader resultMyCommandgetProdutoId = myCommandgetProdutoId.ExecuteReader();
            while (resultMyCommandgetProdutoId.Read())
            {
                idProduto = resultMyCommandgetProdutoId.GetInt32(0);

            }

            databaseObject.CloseConnection();

            databaseObject.OpenConnection();
            string queryProdutoEstoque = "INSERT INTO ProdutoEstoque (`produtoId`,`estoqueId`, `quantidade`) VALUES (@produtoId,@estoqueId, @quantidade)";
            SQLiteCommand myCommandProdutoEstoque = new SQLiteCommand(queryProdutoEstoque, databaseObject.myConnection);

            myCommandProdutoEstoque.Parameters.AddWithValue("@produtoId", idProduto);
            myCommandProdutoEstoque.Parameters.AddWithValue("@estoqueId", idEstoque);
            myCommandProdutoEstoque.Parameters.AddWithValue("@quantidade", quantidade);

            var resultMyCommandProdutoEstoque = myCommandProdutoEstoque.ExecuteNonQuery();

            databaseObject.CloseConnection();

            Console.WriteLine("Produto Adicionado com Sucesso");

        }

        public void removerProduto(string categoria_remover,string descrição_remover, string estoque_remover)
        {
            ConexaoDataBase databaseObject = new ConexaoDataBase();

            databaseObject.OpenConnection();

            string getProdutoRemover = "SELECT idProduto FROM Produto WHERE `Descricao` = @descrição_remover AND `Categoria` = @categoria_remover";
            SQLiteCommand myCommandGetProdutoRemover = new SQLiteCommand(getProdutoRemover, databaseObject.myConnection);

            myCommandGetProdutoRemover.Parameters.AddWithValue("@categoria_remover", categoria_remover);
            myCommandGetProdutoRemover.Parameters.AddWithValue("@descrição_remover", descrição_remover);

            var resultMyCommandGetProdutoRemover = myCommandGetProdutoRemover.ExecuteReader();
            int produtoId = 0;
            while (resultMyCommandGetProdutoRemover.Read())
            {
                produtoId = resultMyCommandGetProdutoRemover.GetInt32(0);

            }

            string getEstoqueProdutoRemover = "SELECT idEstoque FROM Estoque WHERE `Codigo` = @estoque_remover";
            SQLiteCommand myCommandGetEstoqueProdutoRemover = new SQLiteCommand(getEstoqueProdutoRemover, databaseObject.myConnection);

            myCommandGetEstoqueProdutoRemover.Parameters.AddWithValue("@estoque_remover", estoque_remover);

            var resultMyCommandGetEstoqueProdutoRemover = myCommandGetEstoqueProdutoRemover.ExecuteReader();
            int estoqueId = 0;
            while (resultMyCommandGetEstoqueProdutoRemover.Read())
            {
                estoqueId = resultMyCommandGetEstoqueProdutoRemover.GetInt32(0);

            }

            string removerProdutoEstoque = "DELETE FROM ProdutoEstoque WHERE `produtoId` = @produtoId AND `estoqueId` = @estoqueId";
            SQLiteCommand myCommandRemoverProdutoEstoque = new SQLiteCommand(removerProdutoEstoque, databaseObject.myConnection);

            myCommandRemoverProdutoEstoque.Parameters.AddWithValue("@produtoId", produtoId);
            myCommandRemoverProdutoEstoque.Parameters.AddWithValue("@estoqueId", estoqueId);

            var resultMyCommandRemoverProdutoEstoque = myCommandRemoverProdutoEstoque.ExecuteNonQuery();

            string removerProduto = "DELETE FROM Produto WHERE `IdProduto` = @produtoId";
            SQLiteCommand myCommandRemoverProduto = new SQLiteCommand(removerProduto, databaseObject.myConnection);

            myCommandRemoverProduto.Parameters.AddWithValue("@produtoId", produtoId);

            var resultMyCommandRemoverProduto = myCommandRemoverProduto.ExecuteNonQuery();

            databaseObject.CloseConnection();
        }

        public void buscarProduto(string categoria_buscar, string descrição_buscar, string estoque_buscar)
        {
            ConexaoDataBase databaseObject = new ConexaoDataBase();

            databaseObject.OpenConnection();

            string getProdutoBuscar = "SELECT idProduto FROM Produto WHERE `Descricao` = @descrição_buscar AND `Categoria` = @categoria_buscar";
            SQLiteCommand myCommandGetProdutoBuscar = new SQLiteCommand(getProdutoBuscar, databaseObject.myConnection);

            myCommandGetProdutoBuscar.Parameters.AddWithValue("@categoria_buscar", categoria_buscar);
            myCommandGetProdutoBuscar.Parameters.AddWithValue("@descrição_buscar", descrição_buscar);

            var resultMyCommandGetProdutoBuscar = myCommandGetProdutoBuscar.ExecuteReader();
            int produtoBuscaId = 0;

            while (resultMyCommandGetProdutoBuscar.Read())
            {
                produtoBuscaId = resultMyCommandGetProdutoBuscar.GetInt32(0);

            }

            string getEstoqueProdutoBuscar = "SELECT idEstoque FROM Estoque WHERE `Codigo` = @estoque_buscar";
            SQLiteCommand myCommandGetEstoqueProdutoBuscar = new SQLiteCommand(getEstoqueProdutoBuscar, databaseObject.myConnection);

            myCommandGetEstoqueProdutoBuscar.Parameters.AddWithValue("@estoque_buscar", estoque_buscar);

            var resultMyCommandGetEstoqueProdutoBuscar = myCommandGetEstoqueProdutoBuscar.ExecuteReader();
            int estoqueProdutoBuscarId = 0;
            while (resultMyCommandGetEstoqueProdutoBuscar.Read())
            {
                estoqueProdutoBuscarId = resultMyCommandGetEstoqueProdutoBuscar.GetInt32(0);

            }

            string getProdutoEstoque = "SELECT * FROM ProdutoEstoque WHERE `produtoId` = @produtoBuscaId AND `estoqueId` = @estoqueProdutoBuscarId ";
            SQLiteCommand myCommandGetProdutoEstoque = new SQLiteCommand(getProdutoEstoque, databaseObject.myConnection);

            myCommandGetProdutoEstoque.Parameters.AddWithValue("@produtoBuscaId", produtoBuscaId);
            myCommandGetProdutoEstoque.Parameters.AddWithValue("@estoqueProdutoBuscarId", estoqueProdutoBuscarId);

            SQLiteDataReader resultMyCommandGetProdutoEstoque = myCommandGetProdutoEstoque.ExecuteReader();
            while (resultMyCommandGetProdutoEstoque.Read())
            {
                Console.WriteLine("\nProduto ID: {0}\nDescrição: {1}\nCategoria: {2}\nQuantidade: {3}\nEstoque ID: {4}", produtoBuscaId, descrição_buscar, categoria_buscar, resultMyCommandGetProdutoEstoque["Quantidade"], resultMyCommandGetProdutoEstoque["estoqueId"]);
            }

            databaseObject.CloseConnection();
        }
            public string getCodigo()
        {
            return Codigo;
        }

        public void setCodigo(string value)
        {
            Codigo = value;
        }

    }
}