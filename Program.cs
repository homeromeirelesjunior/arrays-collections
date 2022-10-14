using System.Collections;
using bytebank.Modelos.Conta;
using bytebank_Atendimento.bytebank.Util;

// ContaCorrente[] listaDeContas = new ContaCorrente[]
// {
//   new ContaCorrente(874, "5678794-A"),
//   new ContaCorrente(874, "49861854-C"),
//   new ContaCorrente(874, "456798165-D")
// };

// for (int i = 0; i < listaDeContas.Length; i++)
// {
//   ContaCorrente contaAtual = listaDeContas[i];
//   Console.WriteLine($"Índice {i} - Conta: {contaAtual.Conta}");
// }

ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();

listaDeContas.Adicionar(new ContaCorrente(874, "5678794-A", 500));
listaDeContas.Adicionar(new ContaCorrente(874, "4986154-C", 300));
listaDeContas.Adicionar(new ContaCorrente(874, "4567981-D", 400));
listaDeContas.Adicionar(new ContaCorrente(874, "5879846-D", 6000));
listaDeContas.Adicionar(new ContaCorrente(874, "7897653-D", 50));
listaDeContas.Adicionar(new ContaCorrente(874, "4561345-D", 200));
listaDeContas.Adicionar(new ContaCorrente(874, "4787981-D", 20));

// listaDeContas.MaiorSaldo();

// var contaHomero = new ContaCorrente(978, "156497-B", 100000);

// listaDeContas.Adicionar(contaHomero);

// listaDeContas.ExibirListaContas();

// Console.WriteLine("####################################");

// listaDeContas.Remover(contaHomero);

// listaDeContas.ExibirListaContas();

// for (int i = 0; i < listaDeContas.Tamanho; i++)
// {
//   ContaCorrente conta = listaDeContas.RecuperarContaNoIndice(i);
//   Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
// }

Console.WriteLine(listaDeContas.RecuperarContaNoIndice(0));

// 1 - Cadastrar Contas
// 2 - Listar Contas
// 3 - Remover Contas
// 4 - Ordenar Contas
// 5 - Pesquisar Contas
// 6 - Sair do Sistema

ArrayList _listaDeContas = new ArrayList();

void AtendimentoCliente()
{
  char opcao = '0';
  while (opcao != '6')
  {
    Console.Clear();
    Console.WriteLine("===================================");
    Console.WriteLine("====        Atendimento        ====");
    Console.WriteLine("====   1 - Cadastrar Conta     ====");
    Console.WriteLine("====   2 - Listar Contas       ====");
    Console.WriteLine("====   3 - Remover Conta       ====");
    Console.WriteLine("====   4 - Ordenar Contas      ====");
    Console.WriteLine("====   5 - Pesquisar Conta     ====");
    Console.WriteLine("====   6 - Sair do Sistema     ====");
    Console.WriteLine("===================================");
    Console.WriteLine("\n\n");
    Console.Write("Digite a opção desejada: ");

    opcao = Console.ReadLine()[0];

    switch (opcao)
    {
      case '1':
        CadastrarConta();
        break;
      case '2':
        ListarContas();
        break;
      default:
        Console.WriteLine("Opção não implementada");
        break;
    }
  }
}

void ListarContas()
{
  Console.Clear();
  Console.WriteLine("===================================");
  Console.WriteLine("====      Lista de Contas      ====");
  Console.WriteLine("===================================");
  Console.WriteLine("\n");

  if (_listaDeContas.Count <= 0)
  {
    Console.WriteLine("... Não há contas cadastradas! ...");
    Console.ReadKey();
    return;
  }

  foreach (ContaCorrente conta in _listaDeContas)
  {
    Console.WriteLine("====      Dados da Conta      ====");
    Console.WriteLine($"Número da Conta: {conta.Conta}");
    Console.WriteLine("Dados do Titular");
    Console.WriteLine($"Nome: {conta.Titular.Nome}");
    Console.WriteLine($"CPF: {conta.Titular.Cpf}");
    Console.WriteLine($"Profissão: {conta.Titular.Profissao}");
    Console.WriteLine("==================================");
    Console.ReadKey();
  }
}

void CadastrarConta()
{
  Console.Clear();
  Console.WriteLine("===================================");
  Console.WriteLine("====     Cadastro de Contas    ====");
  Console.WriteLine("===================================");
  Console.WriteLine("\n");
  Console.WriteLine("====  Informe dados da conta   ====");

  Console.Write("Número da conta: ");
  string numeroConta = Console.ReadLine();

  Console.Write("Número da Agência: ");
  int numeroAgencia = int.Parse(Console.ReadLine());

  ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

  Console.Write("Informe o saldo inicial: ");
  conta.Saldo = double.Parse(Console.ReadLine());

  Console.Write("Informe nome do Titular: ");
  conta.Titular.Nome = Console.ReadLine();

  Console.Write("Informe CPF do Titular: ");
  conta.Titular.Cpf = Console.ReadLine();

  Console.Write("Informe Profissão do Titular: ");
  conta.Titular.Profissao = Console.ReadLine();

  _listaDeContas.Add(conta);
  Console.WriteLine("... Conta cadastrada com sucesso! ...");
  Console.ReadKey();
}

AtendimentoCliente();