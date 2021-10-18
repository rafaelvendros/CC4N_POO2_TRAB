using CiA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CiA
{
    class Menu
    {
        public static void Main(string[] args)
        {

            ConexaoDataBase databaseObject = new ConexaoDataBase();


            var choice = -1;

            while (choice != 0)
            {

                Console.WriteLine("------------------------ MENU -----------------------");
                Console.WriteLine("1 - Gerenciar Clientes");
                Console.WriteLine("2 - Gerenciar Colaboradores");
                Console.WriteLine("3 - Gerenciar Estoques");
                Console.WriteLine("4 - Gerenciar Lojas");
                Console.WriteLine("5 - Gerenciar Produtos");
                Console.WriteLine("6 - Gerenciar Vendas");
                Console.WriteLine("0 - Sair do Programa");

                Console.Write("\nEscolha:");
                choice = int.Parse(Console.ReadLine());


                if (choice == 1)
                {
                    Console.WriteLine("------------------------ MENU CLIENTES -----------------------");
                    Console.WriteLine("1 - Adicionar Cliente");
                    Console.WriteLine("2 - Remover  Cliente");
                    Console.WriteLine("3 - Buscar Cliente");

                    var clientChoice = Console.ReadLine();

                    switch (clientChoice)
                    {
                        case "1":

                            Console.WriteLine("Insira os Dados do Cliente:");

                            Console.Write("Nome:");
                            var nome = Console.ReadLine();

                            Console.Write("CPF:");
                            var cpf = Console.ReadLine();

                            Console.Write("Telefone:");
                            var telefone = Console.ReadLine();

                            Console.Write("E-mail:");
                            var email = Console.ReadLine();

                            Console.WriteLine("Insira os Dados do Endereço do Cliente:");

                            Console.Write("Rua:");
                            var Rua = Console.ReadLine();

                            Console.Write("Numero:");
                            var Numero = int.Parse(Console.ReadLine());

                            Console.Write("Complemento:");
                            var Complemento = Console.ReadLine();

                            Console.Write("Bairro:");
                            var Bairro = Console.ReadLine();

                            Console.Write("Cidade:");
                            var Cidade = Console.ReadLine();

                            Console.Write("Estado:");
                            var Estado = Console.ReadLine();

                            Endereco e = new Endereco(Rua, Numero, Complemento, Bairro, Cidade, Estado);

                            Cliente c = new Cliente(nome, cpf, telefone, email, e);

                            string queryEndereco = "INSERT INTO Endereco (`Rua`,`Numero`,`Complemento`,`Bairro`,`Cidade`,`Estado`) VALUES (@Rua,@Numero,@Complemento,@Bairro,@Cidade,@Estado)";
                            SQLiteCommand myCommandEndereco = new SQLiteCommand(queryEndereco, databaseObject.myConnection);
                            databaseObject.OpenConnection();
                            myCommandEndereco.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandEndereco.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandEndereco.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            myCommandEndereco.Parameters.AddWithValue("@Bairro", e.GetBairro());
                            myCommandEndereco.Parameters.AddWithValue("@Cidade", e.GetCidade());
                            myCommandEndereco.Parameters.AddWithValue("@Estado", e.GetEstado());
                            var resultMyCommandEndereco = myCommandEndereco.ExecuteNonQuery();
                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string getEnderecoId = "SELECT idEndereco FROM Endereco WHERE Rua = @Rua AND Numero = @Numero AND Complemento = @Complemento";
                            SQLiteCommand myCommandgetEnderecoId = new SQLiteCommand(getEnderecoId, databaseObject.myConnection);
                            int idEndereco = 0;

                            myCommandgetEnderecoId.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            SQLiteDataReader resultMyCommandgetEnderecoId = myCommandgetEnderecoId.ExecuteReader();
                            while (resultMyCommandgetEnderecoId.Read())
                            {
                                idEndereco = resultMyCommandgetEnderecoId.GetInt32(0);

                            }

                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string queryCliente = "INSERT INTO Cliente (`Nome`,`Cpf`,`Telefone`,`Email`,`enderecoId`) VALUES (@Nome,@Cpf,@Telefone,@Email,@enderecoId)";
                            SQLiteCommand myCommandCliente = new SQLiteCommand(queryCliente, databaseObject.myConnection);

                            myCommandCliente.Parameters.AddWithValue("@Nome", c.GetNome());
                            myCommandCliente.Parameters.AddWithValue("@Cpf", c.GetCPF());
                            myCommandCliente.Parameters.AddWithValue("@Telefone", c.GetTelefone());
                            myCommandCliente.Parameters.AddWithValue("@Email", c.GetEmail());
                            myCommandCliente.Parameters.AddWithValue("@enderecoId", idEndereco);
                            var resultMyCommandCliente = myCommandCliente.ExecuteNonQuery();

                            databaseObject.CloseConnection();

                            Console.WriteLine("Cliente Adicionado com Sucesso");

                            break;



                        case "2":

                            databaseObject.OpenConnection();

                            Console.Write("Insira o CPF do cliente que deseja remover:");
                            var cpf_remover = Console.ReadLine();

                            string getClienteRemover = "SELECT enderecoId FROM Cliente WHERE `Cpf` = @cpf_remover";
                            SQLiteCommand myCommandGetClienteRemover = new SQLiteCommand(getClienteRemover, databaseObject.myConnection);

                            myCommandGetClienteRemover.Parameters.AddWithValue("@cpf_remover", cpf_remover);
                            var resultMyCommandRemoverCliente = myCommandGetClienteRemover.ExecuteReader();
                            int enderecoId = 0;
                            while (resultMyCommandRemoverCliente.Read())
                            {
                                enderecoId = resultMyCommandRemoverCliente.GetInt32(0);

                            }

                            string removerCliente = "DELETE FROM Cliente WHERE `Cpf` = @cpf_remover";
                            SQLiteCommand myCommandClienteRemover = new SQLiteCommand(removerCliente, databaseObject.myConnection);
                            myCommandClienteRemover.Parameters.AddWithValue("@cpf_remover", cpf_remover);

                            var resultMyCommandClienteRemover = myCommandClienteRemover.ExecuteNonQuery();

                            string removerClienteEndereco = "DELETE FROM Endereco WHERE `idEndereco` = @enderecoId";
                            SQLiteCommand myCommandRemoverClienteEndereco = new SQLiteCommand(removerClienteEndereco, databaseObject.myConnection);
                            myCommandRemoverClienteEndereco.Parameters.AddWithValue("@enderecoId", enderecoId);

                            var resultMyCommandRemoverClienteEndereco = myCommandRemoverClienteEndereco.ExecuteNonQuery();

                            databaseObject.CloseConnection();

                            break;


                        case "3":
                            Console.Write("Insira o CPF do cliente que deseja buscar:");
                            var cpf_buscar = Console.ReadLine();

                            databaseObject.OpenConnection();
                            string getCliente = "SELECT * FROM Cliente WHERE `Cpf` = @cpf_buscar";
                            SQLiteCommand myCommandGetCliente = new SQLiteCommand(getCliente, databaseObject.myConnection);

                            myCommandGetCliente.Parameters.AddWithValue("@cpf_buscar", cpf_buscar);

                            SQLiteDataReader resultMyCommandGetCliente = myCommandGetCliente.ExecuteReader();
                            while (resultMyCommandGetCliente.Read())
                            {
                                Console.WriteLine("\nCliente ID: {0}\nNome: {1}\nCPF: {2}\nTelefone: {3}\nE-mail: {4}\nEndereco ID: {5}", resultMyCommandGetCliente["idCliente"], resultMyCommandGetCliente["Nome"], resultMyCommandGetCliente["Cpf"], resultMyCommandGetCliente["Telefone"], resultMyCommandGetCliente["Email"], resultMyCommandGetCliente["enderecoId"]);
                            }

                            databaseObject.CloseConnection();

                            break;

                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("------------------------ MENU COLABORADORES -----------------------");
                    Console.WriteLine("1 - Adicionar Colaborador");
                    Console.WriteLine("2 - Remover  Colaborador");
                    Console.WriteLine("3 - Buscar Colaborador");

                    Console.Write("\nEscolha:");
                    var collaboratorsChoice = Console.ReadLine();

                    switch (collaboratorsChoice)
                    {
                        case "1":

                            Console.WriteLine("Insira os Dados do Colaborador:");

                            Console.Write("Nome:");
                            var nome = Console.ReadLine();

                            Console.Write("Código:");
                            var codigo = Console.ReadLine();

                            Console.Write("Telefone:");
                            var telefone = Console.ReadLine();

                            Console.Write("Cargo:");
                            var cargo = Console.ReadLine();

                            Console.Write("Descrição da Loja Atual:");
                            var loja = Console.ReadLine();

                            Console.WriteLine("Insira os Dados do Endereço do Colaborador:");

                            Console.Write("Rua:");
                            var Rua = Console.ReadLine();

                            Console.Write("Numero:");
                            var Numero = int.Parse(Console.ReadLine());

                            Console.Write("Complemento:");
                            var Complemento = Console.ReadLine();

                            Console.Write("Bairro:");
                            var Bairro = Console.ReadLine();

                            Console.Write("Cidade:");
                            var Cidade = Console.ReadLine();

                            Console.Write("Estado:");
                            var Estado = Console.ReadLine();

                            Endereco e = new Endereco(Rua, Numero, Complemento, Bairro, Cidade, Estado);


                            databaseObject.OpenConnection();

                            string getLojaId = "SELECT idLoja FROM Loja WHERE Descricao = @Descricao ";
                            SQLiteCommand myCommandGetLojaId = new SQLiteCommand(getLojaId, databaseObject.myConnection);

                            myCommandGetLojaId.Parameters.AddWithValue("@Descricao", loja);

                            SQLiteDataReader resultmyCommandGetLojaId = myCommandGetLojaId.ExecuteReader();

                            int idLoja = 0;

                            while (resultmyCommandGetLojaId.Read())
                            {
                                idLoja = resultmyCommandGetLojaId.GetInt32(0);
                            }

                            databaseObject.CloseConnection();


                            Colaborador c = new Colaborador(nome, codigo, telefone, cargo, e, idLoja);

                            string queryEndereco = "INSERT INTO Endereco (`Rua`,`Numero`,`Complemento`,`Bairro`,`Cidade`,`Estado`) VALUES (@Rua,@Numero,@Complemento,@Bairro,@Cidade,@Estado)";
                            SQLiteCommand myCommandEndereco = new SQLiteCommand(queryEndereco, databaseObject.myConnection);
                            databaseObject.OpenConnection();
                            myCommandEndereco.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandEndereco.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandEndereco.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            myCommandEndereco.Parameters.AddWithValue("@Bairro", e.GetBairro());
                            myCommandEndereco.Parameters.AddWithValue("@Cidade", e.GetCidade());
                            myCommandEndereco.Parameters.AddWithValue("@Estado", e.GetEstado());
                            var resultMyCommandEndereco = myCommandEndereco.ExecuteNonQuery();
                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string getEnderecoId = "SELECT idEndereco FROM Endereco WHERE Rua = @Rua AND Numero = @Numero AND Complemento = @Complemento";
                            SQLiteCommand myCommandgetEnderecoId = new SQLiteCommand(getEnderecoId, databaseObject.myConnection);
                            int idEndereco = 0;

                            myCommandgetEnderecoId.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            SQLiteDataReader resultMyCommandgetEnderecoId = myCommandgetEnderecoId.ExecuteReader();
                            while (resultMyCommandgetEnderecoId.Read())
                            {
                                idEndereco = resultMyCommandgetEnderecoId.GetInt32(0);

                            }

                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string queryColaborador = "INSERT INTO Colaborador (`Nome`,`Codigo`,`Telefone`,`Cargo`,`enderecoId`, `lojaId`) VALUES (@Nome,@Codigo,@Telefone,@Cargo,@enderecoId, @lojaId)";
                            SQLiteCommand myCommandColaborador = new SQLiteCommand(queryColaborador, databaseObject.myConnection);

                            myCommandColaborador.Parameters.AddWithValue("@Nome", c.GetNome());
                            myCommandColaborador.Parameters.AddWithValue("@Codigo", c.GetCodigo());
                            myCommandColaborador.Parameters.AddWithValue("@Telefone", c.GetTelefone());
                            myCommandColaborador.Parameters.AddWithValue("@Cargo", c.GetCargo());
                            myCommandColaborador.Parameters.AddWithValue("@enderecoId", idEndereco);
                            myCommandColaborador.Parameters.AddWithValue("@lojaId", idLoja);
                            var resultMyCommandColaborador = myCommandColaborador.ExecuteNonQuery();
                            databaseObject.CloseConnection();

                            Console.WriteLine("Colaborador Adicionado com Sucesso");

                            break;

                        case "2":

                            databaseObject.OpenConnection();

                            Console.Write("Insira o Código do colaborador que deseja remover:");
                            var codigo_remover = Console.ReadLine();

                            string getColaboradorRemover = "SELECT enderecoId FROM Colaborador WHERE `Codigo` = @codigo_remover";
                            SQLiteCommand myCommandGetColaboradorRemover = new SQLiteCommand(getColaboradorRemover, databaseObject.myConnection);

                            myCommandGetColaboradorRemover.Parameters.AddWithValue("@codigo_remover", codigo_remover);
                            var resultMyCommandGetColaboradorRemover = myCommandGetColaboradorRemover.ExecuteReader();
                            int enderecoId = 0;
                            while (resultMyCommandGetColaboradorRemover.Read())
                            {
                                enderecoId = resultMyCommandGetColaboradorRemover.GetInt32(0);

                            }

                            string removerColaborador = "DELETE FROM Colaborador WHERE `Codigo` = @codigo_remover";
                            SQLiteCommand myCommandColaboradorRemover = new SQLiteCommand(removerColaborador, databaseObject.myConnection);
                            myCommandColaboradorRemover.Parameters.AddWithValue("@codigo_remover", codigo_remover);

                            var resultMyCommandColaboradorRemover = myCommandColaboradorRemover.ExecuteNonQuery();

                            string removerColaboradorEndereco = "DELETE FROM Endereco WHERE `idEndereco` = @enderecoId";
                            SQLiteCommand myCommandRemoverColaboradorEndereco = new SQLiteCommand(removerColaboradorEndereco, databaseObject.myConnection);
                            myCommandRemoverColaboradorEndereco.Parameters.AddWithValue("@enderecoId", enderecoId);

                            var resultMyCommandRemoverColaboradorEndereco = myCommandRemoverColaboradorEndereco.ExecuteNonQuery();

                            databaseObject.CloseConnection();

                            break;

                        case "3":

                            Console.Write("Insira o Código do colaborador que deseja buscar:");
                            var codigo_buscar = Console.ReadLine();

                            databaseObject.OpenConnection();
                            string getColaborador = "SELECT * FROM Colaborador WHERE `Codigo` = @codigo_buscar";
                            SQLiteCommand myCommandGetColaborador = new SQLiteCommand(getColaborador, databaseObject.myConnection);

                            myCommandGetColaborador.Parameters.AddWithValue("@codigo_buscar", codigo_buscar);

                            SQLiteDataReader resultMyCommandGetColaborador = myCommandGetColaborador.ExecuteReader();
                            while (resultMyCommandGetColaborador.Read())
                            {
                                Console.WriteLine("\nColaborador ID: {0}\nNome: {1}\nCódigo: {2}\nTelefone: {3}\nCargo: {4}\nEndereco ID: {5}\nLoja ID: {6}", resultMyCommandGetColaborador["idColaborador"], resultMyCommandGetColaborador["Nome"], resultMyCommandGetColaborador["Codigo"], resultMyCommandGetColaborador["Telefone"], resultMyCommandGetColaborador["Cargo"], resultMyCommandGetColaborador["enderecoId"], resultMyCommandGetColaborador["lojaId"]);
                            }

                            databaseObject.CloseConnection();

                            break;
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("------------------------ MENU ESTOQUES -----------------------");
                    Console.WriteLine("1 - Adicionar Estoque");
                    Console.WriteLine("2 - Remover  Estoque");
                    Console.WriteLine("3 - Buscar Estoque");

                    Console.Write("\nEscolha:");
                    var stockChoice = Console.ReadLine();

                    switch (stockChoice)
                    {
                        case "1":

                            Console.WriteLine("Insira os Dados do Estoque:");

                            Console.Write("Código:");
                            var codigo = Console.ReadLine();

                            Console.WriteLine("Insira os Dados do Endereço do Estoque:");

                            Console.Write("Rua:");
                            var Rua = Console.ReadLine();

                            Console.Write("Numero:");
                            var Numero = int.Parse(Console.ReadLine());

                            Console.Write("Complemento:");
                            var Complemento = Console.ReadLine();

                            Console.Write("Bairro:");
                            var Bairro = Console.ReadLine();

                            Console.Write("Cidade:");
                            var Cidade = Console.ReadLine();

                            Console.Write("Estado:");
                            var Estado = Console.ReadLine();

                            Endereco e = new Endereco(Rua, Numero, Complemento, Bairro, Cidade, Estado);

                            Estoque c = new Estoque(codigo, e);

                            string queryEndereco = "INSERT INTO Endereco (`Rua`,`Numero`,`Complemento`,`Bairro`,`Cidade`,`Estado`) VALUES (@Rua,@Numero,@Complemento,@Bairro,@Cidade,@Estado)";
                            SQLiteCommand myCommandEndereco = new SQLiteCommand(queryEndereco, databaseObject.myConnection);
                            databaseObject.OpenConnection();
                            myCommandEndereco.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandEndereco.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandEndereco.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            myCommandEndereco.Parameters.AddWithValue("@Bairro", e.GetBairro());
                            myCommandEndereco.Parameters.AddWithValue("@Cidade", e.GetCidade());
                            myCommandEndereco.Parameters.AddWithValue("@Estado", e.GetEstado());
                            var resultMyCommandEndereco = myCommandEndereco.ExecuteNonQuery();
                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string getEnderecoId = "SELECT idEndereco FROM Endereco WHERE Rua = @Rua AND Numero = @Numero AND Complemento = @Complemento";
                            SQLiteCommand myCommandgetEnderecoId = new SQLiteCommand(getEnderecoId, databaseObject.myConnection);
                            int idEndereco = 0;

                            myCommandgetEnderecoId.Parameters.AddWithValue("@Rua", e.GetRua());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Numero", e.GetNumero());
                            myCommandgetEnderecoId.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                            SQLiteDataReader resultMyCommandgetEnderecoId = myCommandgetEnderecoId.ExecuteReader();
                            while (resultMyCommandgetEnderecoId.Read())
                            {
                                idEndereco = resultMyCommandgetEnderecoId.GetInt32(0);

                            }

                            databaseObject.CloseConnection();

                            databaseObject.OpenConnection();
                            string queryEstoque = "INSERT INTO Estoque (`Codigo`,`enderecoId`) VALUES (@Codigo,@enderecoId)";
                            SQLiteCommand myCommandEstoque = new SQLiteCommand(queryEstoque, databaseObject.myConnection);

                            myCommandEstoque.Parameters.AddWithValue("@Codigo", c.getCodigo());
                            myCommandEstoque.Parameters.AddWithValue("@enderecoId", idEndereco);

                            var resultMyCommandEstoque = myCommandEstoque.ExecuteNonQuery();

                            databaseObject.CloseConnection();

                            Console.WriteLine("Estoque Adicionado com Sucesso");

                            break;

                        case "2":

                            databaseObject.OpenConnection();

                            Console.Write("Insira o Código do Estoque que deseja remover:");
                            var codigo_remover = Console.ReadLine();

                            string getCodigoRemover = "SELECT enderecoId FROM Estoque WHERE `Codigo` = @codigo_remover";
                            SQLiteCommand myCommandGetCodigoRemover = new SQLiteCommand(getCodigoRemover, databaseObject.myConnection);

                            myCommandGetCodigoRemover.Parameters.AddWithValue("@codigo_remover", codigo_remover);
                            var resultMyCommandGetCodigoRemover = myCommandGetCodigoRemover.ExecuteReader();
                            int enderecoId = 0;
                            while (resultMyCommandGetCodigoRemover.Read())
                            {
                                enderecoId = resultMyCommandGetCodigoRemover.GetInt32(0);

                            }

                            string removerEstoque = "DELETE FROM Estoque WHERE `Codigo` = @codigo_remover";
                            SQLiteCommand myCommandEstoqueRemover = new SQLiteCommand(removerEstoque, databaseObject.myConnection);
                            myCommandEstoqueRemover.Parameters.AddWithValue("@codigo_remover", codigo_remover);

                            var resultMyCommandEstoqueRemover = myCommandEstoqueRemover.ExecuteNonQuery();

                            string removerEstoqueEndereco = "DELETE FROM Endereco WHERE `idEndereco` = @enderecoId";
                            SQLiteCommand myCommandRemoverEstoqueEndereco = new SQLiteCommand(removerEstoqueEndereco, databaseObject.myConnection);
                            myCommandRemoverEstoqueEndereco.Parameters.AddWithValue("@enderecoId", enderecoId);

                            var resultMyCommandRemoverClienteEndereco = myCommandRemoverEstoqueEndereco.ExecuteNonQuery();

                            databaseObject.CloseConnection();

                            break;

                        case "3":

                            Console.Write("Insira o Codigo do Estoque que deseja buscar:");
                            var codigo_buscar = Console.ReadLine();

                            databaseObject.OpenConnection();
                            string getEstoque = "SELECT * FROM Estoque WHERE `Codigo` = @codigo_buscar";
                            SQLiteCommand myCommandGetEstoque = new SQLiteCommand(getEstoque, databaseObject.myConnection);

                            myCommandGetEstoque.Parameters.AddWithValue("@codigo_buscar", codigo_buscar);

                            SQLiteDataReader resultMyCommandGetEstoque = myCommandGetEstoque.ExecuteReader();
                            while (resultMyCommandGetEstoque.Read())
                            {
                                Console.WriteLine("\nEstoque ID: {0}\nCodigo: {1}\nEndereco ID: {2}", resultMyCommandGetEstoque["idEstoque"], resultMyCommandGetEstoque["Codigo"], resultMyCommandGetEstoque["enderecoId"]);
                            }

                            databaseObject.CloseConnection();

                            break;
                    }


                }
                else if (choice == 4)
                {
                    Console.WriteLine("------------------------ MENU LOJAS -----------------------");
                    Console.WriteLine("1 - Adicionar Loja");
                    Console.WriteLine("2 - Remover  Loja");
                    Console.WriteLine("3 - Buscar Loja");

                    Console.Write("\nEscolha:");
                    var storeChoice = Console.ReadLine();

                    if (storeChoice == "1")
                    {

                        Console.WriteLine("Insira os Dados da Loja:");

                        Console.Write("Descrição:");
                        var Descrição = Console.ReadLine();

                        Console.WriteLine("Insira os Dados do Endereço da Loja:");

                        Console.Write("Rua:");
                        var Rua = Console.ReadLine();

                        Console.Write("Numero:");
                        var Numero = int.Parse(Console.ReadLine());

                        Console.Write("Complemento:");
                        var Complemento = Console.ReadLine();

                        Console.Write("Bairro:");
                        var Bairro = Console.ReadLine();

                        Console.Write("Cidade:");
                        var Cidade = Console.ReadLine();

                        Console.Write("Estado:");
                        var Estado = Console.ReadLine();

                        Endereco e = new Endereco(Rua, Numero, Complemento, Bairro, Cidade, Estado);

                        Console.Write("Insira o Código do Estoque da Loja:");
                        var codigo_estoque = Console.Read();

                        string queryEndereco = "INSERT INTO Endereco (`Rua`,`Numero`,`Complemento`,`Bairro`,`Cidade`,`Estado`) VALUES (@Rua,@Numero,@Complemento,@Bairro,@Cidade,@Estado)";
                        SQLiteCommand myCommandEndereco = new SQLiteCommand(queryEndereco, databaseObject.myConnection);
                        databaseObject.OpenConnection();
                        myCommandEndereco.Parameters.AddWithValue("@Rua", e.GetRua());
                        myCommandEndereco.Parameters.AddWithValue("@Numero", e.GetNumero());
                        myCommandEndereco.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                        myCommandEndereco.Parameters.AddWithValue("@Bairro", e.GetBairro());
                        myCommandEndereco.Parameters.AddWithValue("@Cidade", e.GetCidade());
                        myCommandEndereco.Parameters.AddWithValue("@Estado", e.GetEstado());
                        var resultMyCommandEndereco = myCommandEndereco.ExecuteNonQuery();
                        databaseObject.CloseConnection();

                        databaseObject.OpenConnection();
                        string getEnderecoId = "SELECT idEndereco FROM Endereco WHERE Rua = @Rua AND Numero = @Numero AND Complemento = @Complemento";
                        SQLiteCommand myCommandgetEnderecoId = new SQLiteCommand(getEnderecoId, databaseObject.myConnection);
                        int idEndereco = 0;

                        myCommandgetEnderecoId.Parameters.AddWithValue("@Rua", e.GetRua());
                        myCommandgetEnderecoId.Parameters.AddWithValue("@Numero", e.GetNumero());
                        myCommandgetEnderecoId.Parameters.AddWithValue("@Complemento", e.GetComplemento());
                        SQLiteDataReader resultMyCommandgetEnderecoId = myCommandgetEnderecoId.ExecuteReader();
                        while (resultMyCommandgetEnderecoId.Read())
                        {
                            idEndereco = resultMyCommandgetEnderecoId.GetInt32(0);

                        }

                        databaseObject.CloseConnection();

                        databaseObject.OpenConnection();
                        string getLojaId = "SELECT idEstoque FROM Estoque WHERE Codigo = @Codigo";
                        SQLiteCommand myCommandgetLojaId = new SQLiteCommand(getLojaId, databaseObject.myConnection);
                        int idEstoque = 0;

                        myCommandgetLojaId.Parameters.AddWithValue("@Codigo", codigo_estoque);

                        SQLiteDataReader resultMyCommandgetLojaId = myCommandgetLojaId.ExecuteReader();
                        while (resultMyCommandgetLojaId.Read())
                        {
                            idEstoque = resultMyCommandgetLojaId.GetInt32(0);

                        }

                        databaseObject.CloseConnection();

                        Loja l = new Loja(Descrição, e, idEstoque);

                        databaseObject.OpenConnection();
                        string queryLoja = "INSERT INTO Loja (`Descricao`,`enderecoId`,`estoqueId`) VALUES (@Descricao,@enderecoId,@estoqueId)";
                        SQLiteCommand myCommandLoja = new SQLiteCommand(queryLoja, databaseObject.myConnection);

                        myCommandLoja.Parameters.AddWithValue("@Descricao", l.getDescricao());
                        myCommandLoja.Parameters.AddWithValue("@enderecoId", idEndereco);
                        myCommandLoja.Parameters.AddWithValue("@estoqueId", l.getEstoque());
                        var resultMyCommandLoja = myCommandLoja.ExecuteNonQuery();

                        databaseObject.CloseConnection();

                        Console.WriteLine("Loja Adicionada com Sucesso");

                        break;
                    }
                    else if (storeChoice == "2")
                    {

                        databaseObject.OpenConnection();

                        Console.Write("Insira a Descrição da loja que deseja remover:");
                        var descricao_remover = Console.ReadLine();

                        string getEnderecoRemover = "SELECT enderecoId FROM Loja WHERE `Descricao` = @descricao_remover";
                        SQLiteCommand myCommandGetEnderecoRemover = new SQLiteCommand(getEnderecoRemover, databaseObject.myConnection);

                        myCommandGetEnderecoRemover.Parameters.AddWithValue("@descricao_remover", descricao_remover);
                        var resultMyCommandRemoverEndereco = myCommandGetEnderecoRemover.ExecuteReader();
                        int enderecoId = 0;
                        while (resultMyCommandRemoverEndereco.Read())
                        {
                            enderecoId = resultMyCommandRemoverEndereco.GetInt32(0);

                        }

                        string removerLoja = "DELETE FROM Loja WHERE `Descricao` = @descricao_remover";
                        SQLiteCommand myCommandLojaRemover = new SQLiteCommand(removerLoja, databaseObject.myConnection);
                        myCommandLojaRemover.Parameters.AddWithValue("@descricao_remover", descricao_remover);

                        var resultMyCommandLojaRemover = myCommandLojaRemover.ExecuteNonQuery();

                        string removerLojaEndereco = "DELETE FROM Endereco WHERE `idEndereco` = @enderecoId";
                        SQLiteCommand myCommandRemoverLojaEndereco = new SQLiteCommand(removerLojaEndereco, databaseObject.myConnection);
                        myCommandRemoverLojaEndereco.Parameters.AddWithValue("@enderecoId", enderecoId);

                        var resultMyCommandRemoverLojaEndereco = myCommandRemoverLojaEndereco.ExecuteNonQuery();

                        databaseObject.CloseConnection();

                        break;
                    }
                    else if (storeChoice == "3")
                    {



                        Console.Write("Insira a Descrição da Loja que deseja buscar:");
                        var descricao_buscar = Console.ReadLine();

                        databaseObject.OpenConnection();
                        string getLoja = "SELECT * FROM Loja WHERE `Descricao` = @descricao_buscar";
                        SQLiteCommand myCommandGetLoja = new SQLiteCommand(getLoja, databaseObject.myConnection);

                        myCommandGetLoja.Parameters.AddWithValue("@descricao_buscar", descricao_buscar);

                        SQLiteDataReader resultMyCommandGetLoja = myCommandGetLoja.ExecuteReader();
                        while (resultMyCommandGetLoja.Read())
                        {
                            Console.WriteLine("\nLoja ID: {0}\nDescricao: {1}\nEndereco ID: {2}\nEstoque ID: {3}", resultMyCommandGetLoja["idLoja"], resultMyCommandGetLoja["Descricao"], resultMyCommandGetLoja["enderecoId"], resultMyCommandGetLoja["estoqueId"]);
                        }

                        databaseObject.CloseConnection();
                    }

                }
                else if (choice == 5)
                {
                    Console.WriteLine("------------------------ MENU PRODUTOS -----------------------");
                    Console.WriteLine("1 - Adicionar Produto");
                    Console.WriteLine("2 - Remover  Produto");
                    Console.WriteLine("3 - Buscar Produto");

                    Console.Write("\nEscolha:");
                    var productChoice = Console.ReadLine();

                    if (productChoice == "1")
                    {

                        Console.WriteLine("Insira os Dados do Produto:");

                        Console.Write("Descrição:");
                        var descricao = Console.ReadLine();

                        Console.Write("Valor:");
                        double valor = double.Parse(Console.ReadLine());

                        Console.Write("Categoria:");
                        var categoria = Console.ReadLine();

                        Console.Write("Quantidade:");
                        var quantidade = int.Parse(Console.ReadLine());

                        Console.Write("Insira o Código do Estoque em que Esse Produto se Encontra:");
                        string codigo_estoque = Console.ReadLine();

                        Produto p = new Produto(descricao, valor, categoria);

                        Estoque e = new Estoque();

                        e.entradaProduto(p, quantidade, codigo_estoque);

                    }
                    else if (productChoice == "2")
                    {
                        databaseObject.OpenConnection();

                        Console.Write("Insira a Categoria do Produto que deseja remover:");
                        var categoria_remover = Console.ReadLine();

                        Console.Write("Insira a Descrição do Produto que deseja remover:");
                        var descrição_remover = Console.ReadLine();

                        Console.Write("Insira o Código do Estoque do Produto que deseja remover:");
                        var estoque_remover = Console.ReadLine();

                        Estoque e = new Estoque();

                        e.removerProduto(categoria_remover, descrição_remover, estoque_remover);

                    }
                    else if (productChoice == "3")
                    {
                        Console.Write("Insira a Categoria do Produto que deseja buscar:");
                        var categoria_buscar = Console.ReadLine();

                        Console.Write("Insira a Descrição do Produto que deseja buscar:");
                        var descrição_buscar = Console.ReadLine();

                        Console.Write("Insira o Código do Estoque do Produto que deseja buscar:");
                        var estoque_buscar = Console.ReadLine();

                        Estoque e = new Estoque();

                        e.buscarProduto(categoria_buscar, descrição_buscar, estoque_buscar);
                    }
                    else if (choice == 6)
                    {
                        Console.WriteLine("------------------------ MENU VENDAS -----------------------");
                        Console.WriteLine("1 - Adicionar Venda");
                        Console.WriteLine("2 - Cancelar  Venda");

                        Console.Write("\nEscolha:");
                        var sellChoice = Console.ReadLine();

                        switch (sellChoice)
                        {
                            case "1":

                                Console.WriteLine("Insira os Dados da Venda:");

                                Console.Write("Codigo:");
                                var codigoVenda = Console.ReadLine();

                                Console.Write("CPF do Cliente:");
                                var cpfCliente = Console.ReadLine();

                                Console.Write("Código do Colaborador:");
                                var codigoColaborador = Console.ReadLine();

                                Console.Write("Descrição da Loja:");
                                var descricaoLoja = Console.ReadLine();

                                Console.Write("Quantidade de Produtos que Estão Sendo Adquiridos:");
                                var quantidadeProdutos = int.Parse(Console.ReadLine());

                                databaseObject.OpenConnection();
                                string getCliente = "SELECT * FROM Cliente WHERE `Cpf` = @cpf_buscar";
                                SQLiteCommand myCommandGetCliente = new SQLiteCommand(getCliente, databaseObject.myConnection);

                                myCommandGetCliente.Parameters.AddWithValue("@cpf_buscar", cpfCliente);

                                int clienteId = 0;

                                SQLiteDataReader resultMyCommandGetCliente = myCommandGetCliente.ExecuteReader();
                                while (resultMyCommandGetCliente.Read())
                                {
                                    clienteId = resultMyCommandGetCliente.GetInt32(0);
                                }

                                databaseObject.CloseConnection();

                                databaseObject.OpenConnection();
                                string getColaborador = "SELECT * FROM Colaborador WHERE `Codigo` = @codigo_buscar";
                                SQLiteCommand myCommandGetColaborador = new SQLiteCommand(getColaborador, databaseObject.myConnection);

                                myCommandGetColaborador.Parameters.AddWithValue("@codigo_buscar", codigoColaborador);

                                SQLiteDataReader resultMyCommandGetColaborador = myCommandGetColaborador.ExecuteReader();
                                int colaboradorId = 0;

                                while (resultMyCommandGetColaborador.Read())
                                {
                                    colaboradorId = resultMyCommandGetColaborador.GetInt32(0);
                                }

                                databaseObject.CloseConnection();

                                databaseObject.OpenConnection();
                                string getLoja = "SELECT * FROM Loja WHERE `Descricao` = @descricao_buscar";
                                SQLiteCommand myCommandGetLoja = new SQLiteCommand(getLoja, databaseObject.myConnection);

                                myCommandGetLoja.Parameters.AddWithValue("@descricao_buscar", descricaoLoja);

                                int lojaId = 0;

                                SQLiteDataReader resultMyCommandGetLoja = myCommandGetLoja.ExecuteReader();
                                while (resultMyCommandGetLoja.Read())
                                {
                                    lojaId = resultMyCommandGetLoja.GetInt32(0);
                                }

                                databaseObject.CloseConnection();

                                Venda v = new Venda(codigoVenda, clienteId, 0.0, colaboradorId, lojaId, "Efetuada");

                                string queryVenda = "INSERT INTO Venda (`Codigo`,`ClienteId`,`ColaboradorId`, `Valor`, `LojaId`, `Situacao`) VALUES (@Codigo,@ClienteId,@ColaboradorId,@Valor,@LojaId,@Situacao)";
                                SQLiteCommand myCommandVenda = new SQLiteCommand(queryVenda, databaseObject.myConnection);

                                databaseObject.OpenConnection();

                                myCommandVenda.Parameters.AddWithValue("@Codigo", v.getCodigo());
                                myCommandVenda.Parameters.AddWithValue("@ClienteId", v.getCliente());
                                myCommandVenda.Parameters.AddWithValue("@ColaboradorId", v.getColaborador());
                                myCommandVenda.Parameters.AddWithValue("@Valor", v.getValor());
                                myCommandVenda.Parameters.AddWithValue("@LojaId", v.getLoja());
                                myCommandVenda.Parameters.AddWithValue("@Situacao", v.getSituacao());

                                var resultMyCommandProduto = myCommandVenda.ExecuteNonQuery();
                                databaseObject.CloseConnection();

                                int contador = 0;
                                double valorTotal = 0.0;

                                while (contador < quantidadeProdutos)
                                {
                                    Console.WriteLine("-------------- INSERÇÃO DE PRODUTOS -----------------");
                                    Console.Write("Descrição do Produto:");
                                    var descricaoProduto = Console.ReadLine();

                                    Console.Write("Categoria do Produto:");
                                    var categoriaProduto = Console.ReadLine();

                                    Console.Write("Quantidade do Produto:");
                                    var quantidadeProduto = int.Parse(Console.ReadLine());

                                    databaseObject.OpenConnection();

                                    string getProdutoId = "SELECT * FROM Produto WHERE Descricao = @Descricao AND Categoria = @Categoria";
                                    SQLiteCommand myCommandgetProdutoId = new SQLiteCommand(getProdutoId, databaseObject.myConnection);
                                    int idProduto = 0;

                                    myCommandgetProdutoId.Parameters.AddWithValue("@Descricao", descricaoProduto);
                                    myCommandgetProdutoId.Parameters.AddWithValue("@Categoria", categoriaProduto);

                                    SQLiteDataReader resultMyCommandgetProdutoId = myCommandgetProdutoId.ExecuteReader();
                                    while (resultMyCommandgetProdutoId.Read())
                                    {
                                        idProduto = resultMyCommandgetProdutoId.GetInt32(0);
                                        valorTotal = valorTotal + (resultMyCommandgetProdutoId.GetDouble(2) * (float)quantidadeProduto);
                                    }

                                    databaseObject.CloseConnection();

                                    databaseObject.OpenConnection();
                                    string getVendaId = "SELECT idVenda FROM Venda WHERE Codigo = @Codigo";
                                    SQLiteCommand myCommandgetVendaId = new SQLiteCommand(getVendaId, databaseObject.myConnection);
                                    int idVenda = 0;

                                    myCommandgetVendaId.Parameters.AddWithValue("@Codigo", codigoVenda);


                                    SQLiteDataReader resultMyCommandgetVendaId = myCommandgetVendaId.ExecuteReader();
                                    while (resultMyCommandgetVendaId.Read())
                                    {
                                        idVenda = resultMyCommandgetVendaId.GetInt32(0);

                                    }

                                    string insertItemPedido = "INSERT INTO ItemPedido (`produtoId`, `Quantidade`, `vendaId`) VALUES (@idProduto, @quantidadeProduto, @vendaId)";
                                    SQLiteCommand myCommandInsertItemPedido = new SQLiteCommand(insertItemPedido, databaseObject.myConnection);

                                    myCommandInsertItemPedido.Parameters.AddWithValue("@idProduto", idProduto);
                                    myCommandInsertItemPedido.Parameters.AddWithValue("@quantidadeProduto", quantidadeProduto);
                                    myCommandInsertItemPedido.Parameters.AddWithValue("@vendaId", idVenda);


                                    var resultMyCommandInsertItemPedido = myCommandInsertItemPedido.ExecuteNonQuery();
                                    databaseObject.CloseConnection();
                                    contador++;

                                }

                                databaseObject.OpenConnection();
                                string alterarValorVenda = "UPDATE Venda SET Valor = @valorTotal WHERE Codigo = @Codigo";
                                SQLiteCommand myCommandAlterarValorVenda = new SQLiteCommand(alterarValorVenda, databaseObject.myConnection);

                                myCommandAlterarValorVenda.Parameters.AddWithValue("@valorTotal", valorTotal);
                                myCommandAlterarValorVenda.Parameters.AddWithValue("@Codigo", codigoVenda);


                                var resultMyCommandAlterarValorVenda = myCommandAlterarValorVenda.ExecuteNonQuery();
                                databaseObject.CloseConnection();

                                Console.WriteLine("Venda Adicionada com Sucesso");

                                break;

                            case "2":

                                Console.Write("Insira o Codigo da Venda:");
                                var codigoVendaCancelar = Console.ReadLine();

                                databaseObject.OpenConnection();
                                string getVendaCancelarId = "SELECT idVenda FROM Venda WHERE Codigo = @Codigo";
                                SQLiteCommand myCommandgetVendaCancelarId = new SQLiteCommand(getVendaCancelarId, databaseObject.myConnection);
                                int idVendaCancelar = 0;

                                myCommandgetVendaCancelarId.Parameters.AddWithValue("@Codigo", codigoVendaCancelar);


                                SQLiteDataReader resultMyCommandgetVendaCancelarId = myCommandgetVendaCancelarId.ExecuteReader();
                                while (resultMyCommandgetVendaCancelarId.Read())
                                {
                                    idVendaCancelar = resultMyCommandgetVendaCancelarId.GetInt32(0);

                                }

                                string updateSituacaoVenda = "UPDATE Venda SET Situacao = @situacao WHERE Codigo = @Codigo";
                                SQLiteCommand myCommandUpdateSituacaoVenda = new SQLiteCommand(updateSituacaoVenda, databaseObject.myConnection);

                                myCommandUpdateSituacaoVenda.Parameters.AddWithValue("@situacao", "Cancelada");
                                myCommandUpdateSituacaoVenda.Parameters.AddWithValue("@Codigo", codigoVendaCancelar);

                                var resultmyCommandUpdateSituacaoVenda = myCommandUpdateSituacaoVenda.ExecuteNonQuery();
                                databaseObject.CloseConnection();

                                Console.WriteLine("Venda Cancelada com Sucesso");

                                break;

                        }
                    }



                }
            }
        }
    }
}


