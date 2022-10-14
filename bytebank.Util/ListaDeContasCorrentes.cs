using bytebank.Modelos.Conta;

namespace bytebank_Atendimento.bytebank.Util;

public class ListaDeContasCorrentes
{
  private ContaCorrente[] _itens = null;
  private int _proximaPosicao = 0;
  private string _contaMaiorSaldo = null;
  private double _maiorSaldo = 0;

  public ListaDeContasCorrentes(int tamanhoInicial = 5)
  {
    _itens = new ContaCorrente[tamanhoInicial];
  }

  public void Adicionar(ContaCorrente item)
  {
    Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
    VerificarCapacidade(_proximaPosicao + 1);
    _itens[_proximaPosicao] = item;
    _proximaPosicao++;
  }

  public void VerificarCapacidade(int tamanhoNecessario)
  {
    if (_itens.Length >= tamanhoNecessario)
    {
      return;
    }

    Console.WriteLine("Aumentando a capacidade da lista!");
    ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

    for (int i = 0; i < _itens.Length; i++)
    {
      novoArray[i] = _itens[i];
    }

    _itens = novoArray;
  }

  public void MaiorSaldo()
  {
    for (int i = 0; i < _itens.Length; i++)
    {
      if (_itens[i].Saldo > _maiorSaldo)
      {
        _contaMaiorSaldo = _itens[i].Titular.Nome;
        _maiorSaldo = _itens[i].Saldo;
      }
    }

    Console.WriteLine($"A conta com o maior saldo é a: {_contaMaiorSaldo} e o saldo é de R$ {_maiorSaldo}");
  }

  public void ExibirListaContas()
  {
    for (int i = 0; i < _itens.Length; i++)
    {
      if (_itens[i] != null)
      {
        Console.WriteLine($"Conta: {_itens[i].Conta}");
        Console.WriteLine($"Número Agência: {_itens[i].Numero_agencia}");
        Console.WriteLine($"Saldo: {_itens[i].Saldo}");
        Console.WriteLine("===============================");
      }
    }
  }

  public int _indiceItem = 0;

  public void Remover(ContaCorrente conta)
  {
    for (int i = 0; i < _proximaPosicao; i++)
    {
      ContaCorrente contaAtual = _itens[i];

      if (contaAtual == conta)
      {
        _indiceItem = i;
        break;
      }
    }

    for (int i = _indiceItem; i < _proximaPosicao - 1; i++)
    {
      _itens[i] = _itens[i + 1];
    }

    _proximaPosicao--;
    _itens[_proximaPosicao] = null;
  }

  public ContaCorrente RecuperarContaNoIndice(int indice)
  {
    if (indice < 0 || indice >= _proximaPosicao)
    {
      throw new ArgumentOutOfRangeException(nameof(indice));
    }

    return _itens[indice];
  }

  public int Tamanho
  {
    get
    {
      return _proximaPosicao;
    }
  }

  public ContaCorrente this[int indice]
  {
    get
    {
      return RecuperarContaNoIndice(indice);
    }
  }
}
