using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Compatibilidade
{
    internal class Program
    {
        enum MenuOption
        {
            Opção1 = 1,
            Opção2,
            Opção3,
            Opção4,
            Sair
        }

        private static SQLiteConnection conexao;

        public static void Conectar()
        {
            string caminhoDb = "Data Source=Database/pecasCompatibilidade.db";
            conexao = new SQLiteConnection(caminhoDb);
            conexao.Open();
        }

        public static void Desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }

        public static List<Processador> ObterProcessadores()
        {
            var processadores = new List<Processador>();
            string sql = "SELECT Nome, Soquete FROM Processadores";

            using (var comando = new SQLiteCommand(sql, conexao))
            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    processadores.Add(new Processador
                    {
                        Nome = reader["Nome"].ToString(),
                        Soquete = reader["Soquete"].ToString()
                    });
                }
            }
            return processadores;
        }

        public static List<PlacaMae> ObterPlacasMaes()
        {
            var placas = new List<PlacaMae>();
            string sql = "SELECT Nome, Soquete FROM PlacasMae";

            using (var comando = new SQLiteCommand(sql, conexao))
            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    placas.Add(new PlacaMae
                    {
                        Nome = reader["Nome"].ToString(),
                        Soquete = reader["Soquete"].ToString()
                    });
                }
            }
            return placas;
        }

        static void Main(string[] args)
        {
            Conectar();
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 1 - Iniciar Verificação de Compatibilidade |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 5 - Sair                                   |");
                Console.WriteLine("+--------------------------------------------+");

                if (int.TryParse(Console.ReadLine(), out int escolha) && Enum.IsDefined(typeof(MenuOption), escolha))
                {
                    MenuOption opcaoEscolhida = (MenuOption)escolha;

                    switch (opcaoEscolhida)
                    {
                        case MenuOption.Opção1:
                            TestarCompatibilidade();
                            break;
                        case MenuOption.Sair:
                            continuar = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida! Tente novamente");
                    Console.ReadKey();
                }
            }
            Desconectar();
        }

        static void TestarCompatibilidade()
        {
            Console.Clear();
            Console.WriteLine("=== Teste de Compatibilidade ===");
            Console.WriteLine("1 - Verificar CPU e Placa-mãe");
            Console.WriteLine("5 - Voltar ao Menu Principal");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    VerificarCPUePlacaMae();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    break;
            }
        }

        static void VerificarCPUePlacaMae()
        {
            // Obter dados de processadores e placas-mãe do banco de dados
            var processadores = ObterProcessadores();
            var placasMaes = ObterPlacasMaes();

            Console.Clear();
            Console.WriteLine("=== Verificação: CPU e Placa-mãe ===");

            // Listar processadores disponíveis
            Console.WriteLine("=== Selecionar um Processador ===");
            for (int i = 0; i < processadores.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {processadores[i].Nome}");
            }
            Console.Write("Escolha um processador (digite o número): ");
            int processadorEscolhidoIndex = int.Parse(Console.ReadLine()) - 1;

            // Listar placas-mãe disponíveis
            Console.WriteLine("\n=== Selecionar uma Placa-mãe ===");
            for (int i = 0; i < placasMaes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
            }
            Console.Write("Escolha uma placa-mãe (digite o número): ");
            int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

            // Obter os objetos escolhidos
            var processadorEscolhido = processadores[processadorEscolhidoIndex];
            var placaMaeEscolhida = placasMaes[placaMaeEscolhidaIndex];

            Console.WriteLine($"\nVerificando compatibilidade entre {processadorEscolhido.Nome} e {placaMaeEscolhida.Nome}...");

            // Verificar compatibilidade
            if (processadorEscolhido.Soquete == placaMaeEscolhida.Soquete)
            {
                Console.WriteLine("Compatível! O processador e a placa-mãe são compatíveis.");
            }
            else
            {
                Console.WriteLine("Incompatível! O processador e a placa-mãe não são compatíveis.");
            }

            // Aguardar a entrada do usuário para voltar ao menu
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }

    public class Processador
    {
        public string Nome { get; set; }
        public string Soquete { get; set; }
    }

    public class PlacaMae
    {
        public string Nome { get; set; }
        public string Soquete { get; set; }
    }
}
