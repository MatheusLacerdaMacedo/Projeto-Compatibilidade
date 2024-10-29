using System.Collections.Generic;
using System.IO;
using System;

public class CompatibilidadeVerificador
{
    static List<PlacaMae> placasMaes = new List<PlacaMae>();
    static List<Processador> processador = new List<Processador>();
    static List<Fonte> fonte = new List<Fonte>();
    static List<Gabinete> gabinete = new List<Gabinete>();
    static List<MemoriaRam> memoriaram = new List<MemoriaRam>();
    static List<PlacaDeVideo> placasVideo = new List<PlacaDeVideo>();
    static List<string> pecasSelecionadas = new List<string>();

    public static void VerificarCPUePlacaMae()
    {
        Console.Clear();
        Console.WriteLine("=== Verificação: CPU e Placa-mãe ===");

        // Listar processadores disponíveis
        Console.WriteLine("=== Selecionar um Processador ===");
        for (int i = 0; i < processador.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {processador[i].Nome}");
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

        // Verificar compatibilidade
        var processadorEscolhido = processador[processadorEscolhidoIndex];
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

        Console.ReadKey();
    }


    public static void VerificarPlacaMaeeMemoria()
    {
        Console.Clear();
        Console.WriteLine("=== Verificação: Placa-mãe e Memória RAM ===");

        Console.WriteLine("=== Selecione uma MemoriaRam ===");
        for (int i = 0; i < memoriaram.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {memoriaram[i].Nome}");
        }
        Console.WriteLine("Escolha uma memoria Ram (digite o numero):");
        int memoriaramEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("\n=== Selecionar uma Placa-mãe ===");
        for (int i = 0; i < placasMaes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
        }
        Console.Write("Escolha uma placa-mãe (digite o número): ");
        int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

        //verificar compatibilidade
        var memoriaEscolhida = memoriaram[memoriaramEscolhidaIndex];
        var placaMaeEscolhida = placasMaes[placaMaeEscolhidaIndex];

        Console.WriteLine($"\nVerificando compatibilidade entre {memoriaEscolhida.Nome} e {placaMaeEscolhida.Nome}...");

        if (memoriaEscolhida.TipoMemoria == placaMaeEscolhida.TipoMemoria)
        {
            Console.WriteLine($"A memoria ram {memoriaEscolhida.Nome} é compativel com a place mãe {placaMaeEscolhida.Nome}");
        }
        else
        {
            Console.WriteLine($"Incompativel! As peças {memoriaEscolhida.Nome} e {placaMaeEscolhida.Nome} não são compativeis!");
        }
        Console.WriteLine("Verificação concluída.");
        Console.ReadKey();
    }


    public static void VerificarPlacaMaeEGabinete()
    {
        Console.Clear();
        Console.WriteLine("=== Verificação: Placa-mãe e Gabinete ===");

        Console.WriteLine("=== Selecionar um Gabinete ===");
        for (int i = 0; i < gabinete.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {gabinete[i].Nome}");
        }
        Console.WriteLine("Escolha um gabinete (digite o numero): ");
        int gabineteEscolhidoIndex = int.Parse(Console.ReadLine()) - 1;

        Console.Write("=== Selecione uma placa mãe ===");
        for (int i = 0; i < placasMaes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {placasMaes[i].Nome}");
        }
        Console.WriteLine("Escolha uma placa mãe (digite o numero): ");
        int placaMaeEscolhidaIndex = int.Parse(Console.ReadLine()) - 1;

        var gabineteEscolhido = gabinete[gabineteEscolhidoIndex];
        var placaEscolhida = placasMaes[placaMaeEscolhidaIndex];

        Console.WriteLine($"Verificando compatibilidade entre {gabineteEscolhido.Nome} e {placaEscolhida.Nome}...");

        if (gabineteEscolhido.TamanhoSuportado == placaEscolhida.Tamanho)
        {
            Console.WriteLine($"O Gabinete {gabineteEscolhido.Nome} e placa mãe {placaEscolhida.Nome}");
        }
        else
        {
            Console.WriteLine("O gabinete e a placa mãe não são compativeis!");
        }
        Console.WriteLine("Verificação concluída.");
        Console.ReadKey();
    }

    public static void VerificarFonte()
    {
        Console.Clear();
        Console.WriteLine("=== Verificação: Fonte e Configuração ===");

        // Selecionar Fonte
        Console.WriteLine("=== Selecionar Fonte ===");
        for (int i = 0; i < fonte.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {fonte[i].Nome} (Potência: {fonte[i].Potencia}W)");
        }
        Console.WriteLine("Escolha uma fonte (digite um número):");
        int fonteEscolhidaIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0

        // Selecionar Processador
        Console.WriteLine("=== Selecionar Processador ===");
        for (int i = 0; i < processador.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {processador[i].Nome} (TDP: {processador[i].TDP}W)");
        }
        Console.WriteLine("Escolha um processador (digite um número):");
        int processadorEscolhidoIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0

        // Selecionar Placa de Vídeo
        Console.WriteLine("=== Selecionar Placa de Vídeo ===");
        for (int i = 0; i < placasVideo.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {placasVideo[i].Nome} (Memória: {placasVideo[i].Memoria}GB, TDP: {placasVideo[i].TDP}W)");
        }
        Console.WriteLine("Escolha uma placa de vídeo (digite um número):");
        int placaDeVideoEscolhidaIndex = int.Parse(Console.ReadLine()) - 1; // Ajusta o índice para 0


        var fonteEscolhida = fonte[fonteEscolhidaIndex];
        var processadorEscolhido = processador[processadorEscolhidoIndex];
        var placaDeVideoEscolhida = placasVideo[placaDeVideoEscolhidaIndex];


        Console.WriteLine($"\nVerificando compatibilidade entre:");
        Console.WriteLine($"Processador: {processadorEscolhido.Nome} (TDP: {processadorEscolhido.TDP}W)");
        Console.WriteLine($"Fonte: {fonteEscolhida.Nome} (Potência: {fonteEscolhida.Potencia}W)");
        Console.WriteLine($"Placa de Vídeo: {placaDeVideoEscolhida.Nome} (Memória: {placaDeVideoEscolhida.Memoria}GB, TDP: {placaDeVideoEscolhida.TDP}W)");


        int demandaTotal = processadorEscolhido.TDP + placaDeVideoEscolhida.TDP;

        if (fonteEscolhida.Potencia < demandaTotal)
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
    public static void InicializarComponentes()
    {
        // Adicionar placas-mãe 
        placasMaes.Add(new PlacaMae("Asus ROG Strix Z590-E", "LGA 1200", 128, "Z590", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("MSI B550-A PRO", "AM4", 128, "B550", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("Gigabyte AORUS X570 Master", "AM4", 128, "X570", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("ASRock B450M Steel Legend", "AM4", 64, "B450", "DDR4", "Micro ATX"));
        placasMaes.Add(new PlacaMae("Gigabyte Z490 AORUS Master", "LGA 1200", 128, "Z490", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("ASUS TUF Gaming B550-PLUS", "AM4", 128, "B550", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("MSI MAG B550M Mortar", "AM4", 128, "B550", "DDR4", "Micro ATX"));
        placasMaes.Add(new PlacaMae("ASRock X570 Phantom Gaming 4", "AM4", 128, "X570", "DDR4", "ATX"));
        placasMaes.Add(new PlacaMae("Gigabyte A520M S2H", "AM4", 64, "A520", "DDR4", "Micro ATX"));
        placasMaes.Add(new PlacaMae("ASUS Prime Z490-A", "LGA 1200", 128, "Z490", "DDR4", "ATX"));


        // Adicionar processadores
        processador.Add(new Processador("Intel Core i9-11900K", "LGA 1200", 8, 16, 3.5, 125));
        processador.Add(new Processador("AMD Ryzen 9 5900X", "AM4", 12, 24, 3.7, 105));
        processador.Add(new Processador("Intel Core i5-11600K", "LGA 1200", 6, 12, 3.9, 125));
        processador.Add(new Processador("AMD Ryzen 5 5600X", "AM4", 6, 12, 3.7, 65));
        processador.Add(new Processador("Intel Core i7-11700K", "LGA 1200", 8, 16, 3.6, 125));
        processador.Add(new Processador("AMD Ryzen 7 5800X", "AM4", 8, 16, 3.8, 105));
        processador.Add(new Processador("Intel Core i3-10100", "LGA 1200", 4, 8, 3.6, 65));
        processador.Add(new Processador("AMD Ryzen 3 3300X", "AM4", 4, 8, 3.8, 65));
        processador.Add(new Processador("Intel Core i9-10900K", "LGA 1200", 10, 20, 3.7, 125));
        processador.Add(new Processador("AMD Ryzen 5 3500X", "AM4", 6, 6, 3.6, 65));

        // Adicionar fontes
        fonte.Add(new Fonte("Corsair RM750", 750, "80 PLUS Gold"));
        fonte.Add(new Fonte("EVGA 600 W1", 600, "80 PLUS White"));
        fonte.Add(new Fonte("Seasonic Focus GX-750", 750, "80 PLUS Gold"));
        fonte.Add(new Fonte("Thermaltake Toughpower GF1 850W", 850, "80 PLUS Gold"));
        fonte.Add(new Fonte("Cooler Master MWE Gold 750W", 750, "80 PLUS Gold"));
        fonte.Add(new Fonte("be quiet! Pure Power 11 600W", 600, "80 PLUS Gold"));
        fonte.Add(new Fonte("EVGA SuperNOVA 750 GT", 750, "80 PLUS Gold"));
        fonte.Add(new Fonte("Corsair CV550", 550, "80 PLUS Bronze"));
        fonte.Add(new Fonte("Antec Earthwatts Gold Pro 650W", 650, "80 PLUS Gold"));
        fonte.Add(new Fonte("Silverstone Strider 600W", 600, "80 PLUS Gold"));

        // Adicionar gabinetes
        gabinete.Add(new Gabinete("NZXT H510", "ATX", 165, 350, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Corsair 275R", "ATX", 160, 370, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Thermaltake Versa H21", "ATX", 155, 320, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Cooler Master MasterBox Q300L", "Micro ATX", 157, 360, "Micro ATX"));
        gabinete.Add(new Gabinete("Fractal Design Meshify C", "ATX", 172, 360, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Lian Li PC-O11 Dynamic", "ATX", 155, 420, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Phanteks Eclipse P300A", "ATX", 160, 360, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("Deepcool Matrexx 30", "Micro ATX", 155, 320, "Micro ATX"));
        gabinete.Add(new Gabinete("BitFenix Nova", "ATX", 160, 350, "ATX, Micro ATX"));
        gabinete.Add(new Gabinete("GAMDIAS SIRYAS M1", "Micro ATX", 160, 340, "Micro ATX"));

        // Adicionar memórias RAM

        memoriaram.Add(new MemoriaRam("Corsair Vengeance LPX 16GB", 16, 3200, "DDR4"));
        memoriaram.Add(new MemoriaRam("G.Skill Ripjaws V 32GB", 32, 3600, "DDR4"));
        memoriaram.Add(new MemoriaRam("Crucial Ballistix 16GB", 16, 3200, "DDR4"));
        memoriaram.Add(new MemoriaRam("HyperX Fury 16GB", 16, 3200, "DDR4"));
        memoriaram.Add(new MemoriaRam("Kingston HyperX Impact 32GB", 32, 2400, "DDR4"));
        memoriaram.Add(new MemoriaRam("G.Skill Trident Z RGB 32GB", 32, 3600, "DDR4"));
        memoriaram.Add(new MemoriaRam("Corsair Vengeance LPX 32GB", 32, 3200, "DDR4"));
        memoriaram.Add(new MemoriaRam("Crucial Ballistix Tactical 16GB", 16, 3000, "DDR4"));
        memoriaram.Add(new MemoriaRam("Patriot Viper Steel 16GB", 16, 3600, "DDR4"));
        memoriaram.Add(new MemoriaRam("Team T-FORCE Vulcan Z 32GB", 32, 3200, "DDR4"));

        //Adicionar Placas de Video

        placasVideo.Add(new PlacaDeVideo("NVIDIA GeForce RTX 3090", "NVIDIA", 24, "GDDR6X", 350));
        placasVideo.Add(new PlacaDeVideo("AMD Radeon RX 6900 XT", "AMD", 16, "GDDR6", 300));
        placasVideo.Add(new PlacaDeVideo("NVIDIA GeForce RTX 3080", "NVIDIA", 10, "GDDR6X", 320));
        placasVideo.Add(new PlacaDeVideo("AMD Radeon RX 6800 XT", "AMD", 16, "GDDR6", 300));
        placasVideo.Add(new PlacaDeVideo("NVIDIA GeForce RTX 3070", "NVIDIA", 8, "GDDR6", 220));
        placasVideo.Add(new PlacaDeVideo("AMD Radeon RX 6700 XT", "AMD", 12, "GDDR6", 230));
        placasVideo.Add(new PlacaDeVideo("NVIDIA GeForce GTX 1660 Super", "NVIDIA", 6, "GDDR6", 125));
        placasVideo.Add(new PlacaDeVideo("AMD Radeon RX 580", "AMD", 8, "GDDR5", 185));
        placasVideo.Add(new PlacaDeVideo("NVIDIA GeForce RTX 2060", "NVIDIA", 6, "GDDR6", 160));
        placasVideo.Add(new PlacaDeVideo("AMD Radeon RX 5700 XT", "AMD", 8, "GDDR6", 225));


    }
    public class PlacaMae
    {
        public string Nome { get; set; }
        public string Soquete { get; set; }
        public int MaxMemoria { get; set; }
        public string Chipset { get; set; }
        public string TipoMemoria { get; set; }
        public string Tamanho { get; set; }

        public PlacaMae(string nome, string soquete, int maxMemoria, string chipset, string tipoMemoria, string tamanho)
        {
            Nome = nome;
            Soquete = soquete;
            MaxMemoria = maxMemoria;
            Chipset = chipset;
            TipoMemoria = tipoMemoria;
            Tamanho = tamanho;
        }



        public override string ToString()
        {
            return $"{Nome} - Soquete: {Soquete}, Memória Máxima: {MaxMemoria}GB, Chipset: {Chipset}, Tipo de Memória: {TipoMemoria}, Tamanho: {Tamanho}";
        }
    }


    // Classe Processador
    public class Processador
    {
        public string Nome { get; set; }
        public string Soquete { get; set; }
        public int Nucleos { get; set; }
        public int Threads { get; set; }
        public double Frequencia { get; set; }
        public int TDP { get; set; }

        public Processador(string nome, string soquete, int nucleos, int threads, double frequencia, int tdp)
        {
            Nome = nome;
            Soquete = soquete;
            Nucleos = nucleos;
            Threads = threads;
            Frequencia = frequencia;
            TDP = tdp;
        }

        public override string ToString()
        {
            return $"{Nome} - Soquete: {Soquete}, Núcleos: {Nucleos}, Threads: {Threads}, Frequência: {Frequencia}GHz, TDP: {TDP}W";
        }
    }

    // Classe Fonte
    public class Fonte
    {
        public string Nome { get; set; }
        public int Potencia { get; set; }
        public string Certificacao { get; set; }

        public Fonte(string nome, int potencia, string certificacao)
        {
            Nome = nome;
            Potencia = potencia;
            Certificacao = certificacao;
        }

        public override string ToString()
        {
            return $"{Nome} - Potência: {Potencia}W, Certificação: {Certificacao}";
        }
    }

    // Classe Gabinete
    public class Gabinete
    {
        public string Nome { get; set; }
        public string Formato { get; set; } // Formato do gabinete, como ATX, Micro ATX, etc.
        public int MaxAltura { get; set; } // Máxima altura do cooler em mm
        public int MaxComprimento { get; set; } // Máximo comprimento da placa de vídeo em mm
        public string TamanhoSuportado { get; set; } // Novo atributo para o tamanho da placa-mãe suportada

        public Gabinete(string nome, string formato, int maxAltura, int maxComprimento, string tamanhoSuportado)
        {
            Nome = nome;
            Formato = formato;
            MaxAltura = maxAltura;
            MaxComprimento = maxComprimento;
            TamanhoSuportado = tamanhoSuportado; // Inicializando o novo atributo
        }
    }


    // Classe MemoriaRam
    public class MemoriaRam
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; } // em GB
        public int Velocidade { get; set; } // em MHz
        public string TipoMemoria { get; set; } // Novo campo para o tipo de memória

        public MemoriaRam(string nome, int capacidade, int velocidade, string tipoMemoria)
        {
            Nome = nome;
            Capacidade = capacidade;
            Velocidade = velocidade;
            TipoMemoria = tipoMemoria; // Atribuição do novo campo
        }
        public override string ToString()
        {
            return $"{Nome} - Capacidade: {Capacidade}GB, Frequência: {Velocidade}MHz";
        }
    }

    // Classe Placa de Video
    public class PlacaDeVideo
    {
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Memoria { get; set; } // em MB
        public string Tipo { get; set; } // Ex: GDDR6, GDDR5
        public int TDP { get; set; } // em Watts


        public PlacaDeVideo(string nome, string modelo, int memoria, string tipo, int tdp)
        {
            Nome = nome;
            Modelo = modelo;
            Memoria = memoria;
            Tipo = tipo;
            TDP = tdp;

        }

        public override string ToString()
        {
            return $"{Nome} ({Modelo}) - {Memoria}MB {Tipo}, TDP: {TDP}W, ";
        }
    }
}