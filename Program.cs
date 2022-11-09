using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Reserva reserva = new Reserva();
Suite suite = new Suite();

string opcao;
bool exibirMenu = true;
while (exibirMenu == true)
{
    Thread.Sleep(1000); // Esperar um pouco antes de limpar o menu
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Quantidade dias reserva");
    Console.WriteLine("2 - Cadastrar/Alterar suíte");
    Console.WriteLine("3 - Cadastrar hóspede");
    Console.WriteLine("4 - Remover hóspede");
    Console.WriteLine("5 - Obter quantidade hóspedes e nomes");
    Console.WriteLine("6 - Calcular valor reserva");
    Console.WriteLine("7 - Sair");
    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "1":
            Console.WriteLine("Informe a quantidade de dias:");
            int dias = Convert.ToInt32(Console.ReadLine());
            reserva.DiasReservados = dias;
            Console.WriteLine("Alterando...");
            break;
        case "2":
            Console.WriteLine("* * * CRIAÇÃO / ALTERAÇÃO DE SUÍTE * * *");
            Console.WriteLine("Informe o tipo da suite:");
            suite.TipoSuite = Console.ReadLine();
            Console.WriteLine("Informe a capacidade de hóspedes:");
            suite.Capacidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o valor da diária:");
            suite.ValorDiaria = Convert.ToDecimal(Console.ReadLine());
            reserva.CadastrarSuite(suite);
            Console.WriteLine("Salvando...");
            break;
        case "3":
            Console.WriteLine("* * * CADASTRO DE HÓSPEDES * * *");
            Console.WriteLine("Informe o nome:");
            string nomeNovoHospede = Console.ReadLine();
            hospedes.Add(new Pessoa(nomeNovoHospede));
            reserva.CadastrarHospedes(hospedes);
            Console.WriteLine("Cadastrando...");
            break;
        case "4":
            Console.WriteLine("* * * REMOÇÃO DE HÓSPEDES * * *");
            Console.WriteLine("Informe o nome:");
            string nomeParaRemover = Console.ReadLine();
            Pessoa hospedeParaRemover = hospedes.Find(h => h.Nome == nomeParaRemover);
            hospedes.Remove(hospedeParaRemover);
            Console.WriteLine("Removendo...");
            break;
        case "5":
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            foreach (Pessoa hospede in hospedes)
            {
                Console.WriteLine($"{hospede.Nome}");
            }
            break;
        case "6":
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            break;
        case "7":
            Console.WriteLine("Encerrando!");
            exibirMenu = false;
            break;
        default:
            break;
    }
}