using System;
using System.Collections.Generic;
using System.IO;

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




        static void Main(string[] args)
        {
            CompatibilidadeVerificador.InicializarComponentes();

            Console.WriteLine("\r\n██████╗ ███████╗███╗   ███╗    ██╗   ██╗██╗███╗   ██╗██████╗  ██████╗ \r\n██╔══██╗██╔════╝████╗ ████║    ██║   ██║██║████╗  ██║██╔══██╗██╔═══██╗\r\n██████╔╝█████╗  ██╔████╔██║    ██║   ██║██║██╔██╗ ██║██║  ██║██║   ██║\r\n██╔══██╗██╔══╝  ██║╚██╔╝██║    ╚██╗ ██╔╝██║██║╚██╗██║██║  ██║██║   ██║\r\n██████╔╝███████╗██║ ╚═╝ ██║     ╚████╔╝ ██║██║ ╚████║██████╔╝╚██████╔╝\r\n╚═════╝ ╚══════╝╚═╝     ╚═╝      ╚═══╝  ╚═╝╚═╝  ╚═══╝╚═════╝  ╚═════╝ \r\n                                                                      \r\n");
            Console.WriteLine("\r\n                            _                                  _                             \r\n  /\\  ._   _  ._ _|_  _    |_ ._ _|_  _  ._   ._   _. ._ _.   /   _  ._ _|_ o ._       _. ._ \r\n /--\\ |_) (/_ |   |_ (/_   |_ | | |_ (/_ |    |_) (_| | (_|   \\_ (_) | | |_ | | | |_| (_| |  \r\n      |                                       |                                              \r\n");
            Console.ReadKey();

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("\r\n████████╗███████╗███████╗████████╗███████╗     ██████╗ ██████╗ ███╗   ███╗██████╗  █████╗ ████████╗██╗██████╗ ██╗██╗     ██╗██████╗  █████╗ ██████╗ ███████╗\r\n╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝██╔════╝    ██╔════╝██╔═══██╗████╗ ████║██╔══██╗██╔══██╗╚══██╔══╝██║██╔══██╗██║██║     ██║██╔══██╗██╔══██╗██╔══██╗██╔════╝\r\n   ██║   █████╗  ███████╗   ██║   █████╗      ██║     ██║   ██║██╔████╔██║██████╔╝███████║   ██║   ██║██████╔╝██║██║     ██║██║  ██║███████║██║  ██║█████╗  \r\n   ██║   ██╔══╝  ╚════██║   ██║   ██╔══╝      ██║     ██║   ██║██║╚██╔╝██║██╔═══╝ ██╔══██║   ██║   ██║██╔══██╗██║██║     ██║██║  ██║██╔══██║██║  ██║██╔══╝  \r\n   ██║   ███████╗███████║   ██║   ███████╗    ╚██████╗╚██████╔╝██║ ╚═╝ ██║██║     ██║  ██║   ██║   ██║██████╔╝██║███████╗██║██████╔╝██║  ██║██████╔╝███████╗\r\n   ╚═╝   ╚══════╝╚══════╝   ╚═╝   ╚══════╝     ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚═╝     ╚═╝  ╚═╝   ╚═╝   ╚═╝╚═════╝ ╚═╝╚══════╝╚═╝╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚══════╝\r\n                                                                                                                                                            \r\n██████╗ ███████╗                                                                                                                                            \r\n██╔══██╗██╔════╝                                                                                                                                            \r\n██║  ██║█████╗                                                                                                                                              \r\n██║  ██║██╔══╝                                                                                                                                              \r\n██████╔╝███████╗                                                                                                                                            \r\n╚═════╝ ╚══════╝                                                                                                                                            \r\n                                                                                                                                                            \r\n██╗  ██╗ █████╗ ██████╗ ██████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗                                                                                          \r\n██║  ██║██╔══██╗██╔══██╗██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝                                                                                          \r\n███████║███████║██████╔╝██║  ██║██║ █╗ ██║███████║██████╔╝█████╗                                                                                            \r\n██╔══██║██╔══██║██╔══██╗██║  ██║██║███╗██║██╔══██║██╔══██╗██╔══╝                                                                                            \r\n██║  ██║██║  ██║██║  ██║██████╔╝╚███╔███╔╝██║  ██║██║  ██║███████╗                                                                                          \r\n╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝  ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝                                                                                          \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n                                                                                                                                                            \r\n");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 1 - Iniciar Verificação de Compatibilidade |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 2 - Imprimir peças selecionadas            |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 3 - Sugestão de Peças                      |");
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("| 4 - Sobre o Aplicativo                     |");
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
                        case MenuOption.Opção2:

                            break;
                        case MenuOption.Opção3:
                            CompatibilidadeVerificador.SugestaoDePecas();
                            break;
                        case MenuOption.Opção4:
                            CompatibilidadeVerificador.SobreAplicativo();
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
        }


        static void TestarCompatibilidade()
        {
            Console.Clear();
            Console.WriteLine("=== Teste de Compatibilidade ===");
            Console.WriteLine("1 - Verificar CPU e Placa-mãe");
            Console.WriteLine("2 - Verificar Placa-mãe e Memória RAM");
            Console.WriteLine("3 - Verificar Placa-mãe e Gabinete");
            Console.WriteLine("4 - Verificar Fonte e Configuração");
            Console.WriteLine("5 - Voltar ao Menu Principal");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    CompatibilidadeVerificador.VerificarCPUePlacaMae();
                    break;
                case "2":
                    CompatibilidadeVerificador.VerificarPlacaMaeeMemoria();
                    break;
                case "3":
                    CompatibilidadeVerificador.VerificarPlacaMaeEGabinete();
                    break;
                case "4":
                    CompatibilidadeVerificador.VerificarFonte();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
