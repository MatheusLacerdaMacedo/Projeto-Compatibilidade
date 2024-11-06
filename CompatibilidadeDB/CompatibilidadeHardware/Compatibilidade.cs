using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Compatibilidade
{
    public class CompatibilidadeVerificador
    {
        private static List<string> pecasSelecionadas = new List<string>();
        private static SQLiteConnection conexao;

        // Conectar ao banco 
        public static void Conectar()
        {
            if (conexao == null || conexao.State != System.Data.ConnectionState.Open)
            {
                string caminhoDb = "Data Source=Database/pecasCompatibilidade.db";
                conexao = new SQLiteConnection(caminhoDb);
                conexao.Open();
            }
        }

        // Desconectar do banco 
        public static void Desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }

       
        public static List<T> ObterPecas<T>(string sql, Func<SQLiteDataReader, T> mapReader)
        {
            
            if (conexao == null || conexao.State != System.Data.ConnectionState.Open)
            {
                Conectar(); 
            }

            var pecas = new List<T>();
            using (var comando = new SQLiteCommand(sql, conexao))
            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    pecas.Add(mapReader(reader));
                }
            }
            return pecas;
        }

        
        public static List<Processador> ObterProcessadores()
        {
            string sql = "SELECT Nome, Soquete, TDP, TDPTurbo FROM Processadores";
            return ObterPecas(sql, reader => new Processador
            {
                Nome = reader["Nome"].ToString(),
                Soquete = reader["Soquete"].ToString(),
                Tdp = reader["TDP"] != DBNull.Value ? Convert.ToInt32(reader["TDP"]) : 0,
                TdpTurbo = reader["TDPTurbo"] != DBNull.Value ? Convert.ToInt32(reader["TDPTurbo"]) : 0
            });
        }

       
        public static List<PlacaMae> ObterPlacasMaes()
        {
            string sql = "SELECT Nome, Soquete, Formato, TipoMemoria, PCIe FROM PlacasMae";
            return ObterPecas(sql, reader => new PlacaMae
            {
                Nome = reader["Nome"].ToString(),
                Soquete = reader["Soquete"].ToString(),
                Formato = reader["Formato"].ToString(),
                TipoMemoria = reader["TipoMemoria"].ToString(),
                PCIe = reader["PCIe"].ToString()
            });
        }

        
        public static List<Memorias> ObterMemorias()
        {
            string sql = "SELECT Nome, Tipo FROM Memorias";
            return ObterPecas(sql, reader => new Memorias
            {
                Nome = reader["Nome"].ToString(),
                Tipo = reader["Tipo"].ToString()
            });
        }

        
        public static List<Gabinetes> ObterGabinetes()
        {
            string sql = "SELECT Nome, Formato FROM Gabinetes";
            return ObterPecas(sql, reader => new Gabinetes
            {
                Nome = reader["Nome"].ToString(),
                Formato = reader["Formato"].ToString()
            });
        }

        
        public static List<Fontes> ObterFontes()
        {
            string sql = "SELECT Nome, Potencia, Certificacao, Modular, Formato, TDP FROM Fontes";
            return ObterPecas(sql, reader => new Fontes
            {
                Nome = reader["Nome"].ToString(),
                Potencia = reader["Potencia"].ToString(),
                Certificacao = reader["Certificacao"].ToString(),
                Modular = reader["Modular"].ToString(),
                Formato = reader["Formato"].ToString(),
                TDP = reader["TDP"] != DBNull.Value ? Convert.ToInt32(reader["TDP"]) : 0
            });
        }

        
        public static List<PlacadeVideo> ObterPlacasdeVideo()
        {
            string sql = "SELECT Nome, Interface, TDP FROM PlacasVideo";
            return ObterPecas(sql, reader => new PlacadeVideo
            {
                Nome = reader["Nome"].ToString(),
                Interface = reader["Interface"].ToString(),
                TDP = reader["TDP"] != DBNull.Value ? Convert.ToInt32(reader["TDP"]) : 0
            });
        }
    
    

        public static void VerificarCPUePlacaMae()
        {
            var processadores = ObterProcessadores();
            var placasMaes = ObterPlacasMaes();

            Console.Clear();
            Console.WriteLine("=== Verificação: CPU e Placa-mãe ===");

            Console.WriteLine("=== Selecionar um Processador ===");
            for (int i = 0; i < processadores.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {processadores[i].Nome}");
            }
            Console.Write("Escolha um processador (digite o número): ");
            int processadorEscolhidoIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\n=== Selecionar uma Placa-mãe ===");
            for (int i = 0; i < placasMaes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
            }
            Console.Write("Escolha uma placa-mãe (digite o número): ");
            int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

            var processadorEscolhido = processadores[processadorEscolhidoIndex];
            var placaMaeEscolhida = placasMaes[placaMaeEscolhidaIndex];

            Console.WriteLine($"\nVerificando compatibilidade entre {processadorEscolhido.Nome} e {placaMaeEscolhida.Nome}...");

            if (processadorEscolhido.Soquete == placaMaeEscolhida.Soquete)
            {
                Console.WriteLine("Compatível! O processador e a placa-mãe são compatíveis.");
            }
            else
            {
                Console.WriteLine("Incompatível! O processador e a placa-mãe não são compatíveis.");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        public static void VerificarPlacaMaeeMemoria()
        {
            var memorias = ObterMemorias();
            var placasMaes = ObterPlacasMaes();

            Console.Clear();
            Console.WriteLine("=== Verificação: Placa-mãe e Memória RAM ===");

            Console.WriteLine("=== Selecione uma Memória RAM ===");
            for (int i = 0; i < memorias.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {memorias[i].Nome}");
            }
            Console.Write("Escolha uma memória RAM (digite o número): ");
            int memoriaEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\n=== Selecionar uma Placa-mãe ===");
            for (int i = 0; i < placasMaes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
            }
            Console.Write("Escolha uma placa-mãe (digite o número): ");
            int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

            var memoriaEscolhida = memorias[memoriaEscolhidaIndex];
            var placaMaeEscolhida = placasMaes[placaMaeEscolhidaIndex];

            Console.WriteLine($"\nVerificando compatibilidade entre {memoriaEscolhida.Nome} e {placaMaeEscolhida.Nome}...");

            if (memoriaEscolhida.Tipo == placaMaeEscolhida.TipoMemoria)
            {
                Console.WriteLine($"A memória RAM {memoriaEscolhida.Nome} é compatível com a placa-mãe {placaMaeEscolhida.Nome}.");
            }
            else
            {
                Console.WriteLine($"Incompatível! As peças {memoriaEscolhida.Nome} e {placaMaeEscolhida.Nome} não são compatíveis.");
            }

            Console.WriteLine("Verificação concluída.");
            Console.ReadKey();
        }
        public static void VerificarPlacaMaeEGabinete()
        {
            var gabinetes = ObterGabinetes();
            var placasMaes = ObterPlacasMaes();

            Console.Clear();
            Console.WriteLine("=== Verificação: Placa-mãe e Gabinete ===");

            Console.WriteLine("=== Selecionar um Gabinete ===");
            for (int i = 0; i < gabinetes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {gabinetes[i].Nome}");
            }
            Console.Write("Escolha um gabinete (digite o número): ");
            int gabineteEscolhidoIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\n=== Selecionar uma Placa-mãe ===");
            for (int i = 0; i < placasMaes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
            }
            Console.Write("Escolha uma placa-mãe (digite o número): ");
            int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

            var gabineteEscolhido = gabinetes[gabineteEscolhidoIndex];
            var placaMaeEscolhida = placasMaes[placaMaeEscolhidaIndex];

            Console.WriteLine($"Verificando compatibilidade entre {gabineteEscolhido.Nome} e {placaMaeEscolhida.Nome}...");

            if (gabineteEscolhido.Formato == placaMaeEscolhida.Formato)
            {
                Console.WriteLine($"O Gabinete {gabineteEscolhido.Nome} e a placa-mãe {placaMaeEscolhida.Nome} são compatíveis.");
            }
            else
            {
                Console.WriteLine("O gabinete e a placa-mãe não são compatíveis!");
            }

            Console.WriteLine("Verificação concluída.");
            Console.ReadKey();
        }
        public static void VerificarFonte()
        {
            Console.Clear();
            Console.WriteLine("=== Verificação: Fonte e Configuração ===");

            // Obter as listas de fontes, processadores e placas de vídeo
            var fontes = ObterFontes();
            var processadores = ObterProcessadores();
            var placasVideo = ObterPlacasdeVideo();

            // Selecionar Fonte
            Console.WriteLine("=== Selecionar Fonte ===");
            for (int i = 0; i < fontes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {fontes[i].Nome} (Potência: {fontes[i].Potencia}W)");
            }
            Console.WriteLine("Escolha uma fonte (digite um número):");
            int fonteEscolhidaIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0

            // Selecionar Processador
            Console.WriteLine("=== Selecionar Processador ===");
            for (int i = 0; i < processadores.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {processadores[i].Nome} (TDP: {processadores[i].Tdp}W)");
            }
            Console.WriteLine("Escolha um processador (digite um número):");
            int processadorEscolhidoIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0

            // Selecionar Placa de Vídeo
            Console.WriteLine("=== Selecionar Placa de Vídeo ===");
            for (int i = 0; i < placasVideo.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {placasVideo[i].Nome} (TDP: {placasVideo[i].TDP}W)");
            }
            Console.WriteLine("Escolha uma placa de vídeo (digite um número):");
            int placaDeVideoEscolhidaIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0

            var fonteEscolhida = fontes[fonteEscolhidaIndex];
            var processadorEscolhido = processadores[processadorEscolhidoIndex];
            var placaDeVideoEscolhida = placasVideo[placaDeVideoEscolhidaIndex];

            Console.WriteLine($"\nVerificando compatibilidade entre:");
            Console.WriteLine($"Processador: {processadorEscolhido.Nome} (TDP: {processadorEscolhido.Tdp}W)");
            Console.WriteLine($"Fonte: {fonteEscolhida.Nome} (Potência: {fonteEscolhida.Potencia}W)");
            Console.WriteLine($"Placa de Vídeo: {placaDeVideoEscolhida.Nome} (TDP: {placaDeVideoEscolhida.TDP}W)");

            // Calcular o consumo total de energia
            int demandaTotal = processadorEscolhido.Tdp + placaDeVideoEscolhida.TDP;

            if (fonteEscolhida.TDP < demandaTotal)
            {
                Console.WriteLine("Compatibilidade: A fonte não tem potência suficiente para suportar o processador e a placa de vídeo.");
            }
            else
            {
                Console.WriteLine("Compatibilidade: A fonte é suficiente para suportar o processador e a placa de vídeo.");
            }

            Console.WriteLine("Verificação concluída.");
            Console.ReadKey();
        }
        public static void SugestaoDePecas()
        {
            Console.Clear();
            Console.WriteLine("=== Selecione o seu orçamento para o computador: ===");

            Console.WriteLine("1 - 1200 a 1800 Reais");
            Console.WriteLine("2 - 1900 a 2800 Reais");
            Console.WriteLine("3 - 2800 a 3500 Reais");
            Console.WriteLine("4 - Mais que 4000 Reais");

            string orcamento = Console.ReadLine();

            switch (orcamento)
            {
                case "1":
                    AdicionarPecas("=== Sugestão para orçamento entre 1200 a 1800 Reais ===\n" +
                                   "Processador: AMD Ryzen 3 3200G\n" +
                                   "Placa de Vídeo: Integrada (Vega 8)\n" +
                                   "Memória RAM: 8GB DDR4\n" +
                                   "Placa Mãe: ASRock A320M\n" +
                                   "Armazenamento: SSD 240GB\n" +
                                   "Gabinete: Bluecase BG-024\n" +
                                   "Fonte: Fonte genérica 400W");
                    break;

                case "2":
                    AdicionarPecas("=== Sugestão para orçamento entre 1900 a 2800 Reais ===\n" +
                                   "Processador: AMD Ryzen 5 3600\n" +
                                   "Placa de Vídeo: NVIDIA GTX 1650\n" +
                                   "Memória RAM: 16GB DDR4\n" +
                                   "Placa Mãe: Gigabyte B450M\n" +
                                   "Armazenamento: SSD 480GB\n" +
                                   "Gabinete: Aerocool Streak\n" +
                                   "Fonte: Corsair CV450");
                    break;

                case "3":
                    AdicionarPecas("=== Sugestão para orçamento entre 2800 a 3500 Reais ===\n" +
                                   "Processador: Intel Core i5-11400F\n" +
                                   "Placa de Vídeo: NVIDIA GTX 1660 Super\n" +
                                   "Memória RAM: 16GB DDR4\n" +
                                   "Placa Mãe: ASUS TUF B560M\n" +
                                   "Armazenamento: SSD 512GB NVMe\n" +
                                   "Gabinete: Cooler Master MasterBox Q300L\n" +
                                   "Fonte: EVGA 500W 80 Plus Bronze");
                    break;

                case "4":
                    AdicionarPecas("=== Sugestão para orçamento superior a 4000 Reais ===\n" +
                                   "Processador: Intel Core i7-12700K\n" +
                                   "Placa de Vídeo: NVIDIA RTX 3070\n" +
                                   "Memória RAM: 32GB DDR4\n" +
                                   "Placa Mãe: ASUS ROG STRIX Z690\n" +
                                   "Armazenamento: SSD 1TB NVMe\n" +
                                   "Gabinete: NZXT H510\n" +
                                   "Fonte: Corsair RM750 80 Plus Gold");
                    break;

                default:
                    Console.WriteLine("Opção de orçamento inválida. Tente novamente.");
                    return;
            }

            Console.WriteLine("\nDeseja imprimir as peças selecionadas? (s/n)");
            string resposta = Console.ReadLine();

            if (resposta.Trim().ToLower() == "s")
            {
                ImprimirPeças();
            }
            else
            {
                Console.WriteLine("As peças selecionadas não foram impressas.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static void AdicionarPecas(string sugestao)
        {
            pecasSelecionadas.Add(sugestao);
            Console.WriteLine(sugestao);
        }

        public static void ImprimirPeças()
        {
            // Define um caminho baseado na data e hora atual para criar um arquivo único
            string caminho = $"pecas_selecionadas_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(caminho))
                {
                    writer.WriteLine("=== Peças Selecionadas ===");
                    foreach (var peca in pecasSelecionadas)
                    {
                        writer.WriteLine(peca);
                    }
                }

                // Mostra o caminho onde o arquivo foi criado
                Console.WriteLine($"As peças selecionadas foram impressas em: {Path.GetFullPath(caminho)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao imprimir as peças: {ex.Message}");
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
        public static void SobreAplicativo()
        {
            Console.Clear();
            Console.WriteLine("=== Sobre o Aplicativo ===");
            Console.WriteLine("Aplicativo para verificação de compatibilidade de hardware.");
            Console.WriteLine("Desenvolvido por [Matheus Lacerda Macedo && Elias Ferreira Coelho].");
            Console.WriteLine("Versão 1.0");
            Console.ReadKey();
        }
    }

}

public class Processador
{
    public string Nome { get; set; }
    public string Soquete { get; set; }
    public int Tdp { get; set; }
    public int TdpTurbo { get; set; }
}

public class PlacaMae
{
    public string Nome { get; set; }
    public string Soquete { get; set; }
    public string Formato { get; set; }
    public string TipoMemoria { get; set; }
    public string PCIe { get; set; }
}

public class Memorias
{
    public string Nome { get; set; }
    public string Tipo { get; set; }
}
public class Gabinetes
{
    public string Nome { get; set; }
    public string Formato { get; set; }
}
public class Fontes
{
    public string Nome { get; set; }
    public string Potencia { get; set; }
    public string Certificacao { get; set; }
    public string Modular { get; set; }
    public string Formato { get; set; }
    public int TDP { get; set; }
}
public class PlacadeVideo
{
    public string Nome { get; set; }
    public string Interface { get; set; }
    public int TDP { get; set; }
}

