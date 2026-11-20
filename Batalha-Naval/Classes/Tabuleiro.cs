using Batalha_Naval.Enums;

namespace Batalha_Naval.Classes;

public class Tabuleiro
{

    public List<Celula> Celulas { get; private set; }
    public int Tamanho { get; }

    public Tabuleiro()
    {
        Tamanho = 10;
        Celulas = new List<Celula>();
    }

    public void Inicializar()
    {
        Celulas.Clear();

        for (int linha = 0; linha < Tamanho; linha++)
        {
            for (int coluna = 0; coluna < Tamanho; coluna++)
            {
                Celulas.Add(new Celula(linha, coluna));
            }
        }
    }

    private Celula? BuscarCelula(int linha, int coluna)
    {
        foreach (Celula celula in Celulas)
        {
            if (celula.Linha == linha && celula.Coluna == coluna)
            {
                return celula;
            }
        }

        return null;
    }



    public ResultadoAtaque ReceberAtaque(int linha, int coluna)
    {
        Celula? celula = BuscarCelula(linha, coluna);

        if (celula == null)
        {
            throw new ArgumentOutOfRangeException(
                "Posição fora do tabuleiro.");
        }

        if (!celula.ReceberAtaque())
        {
            return ResultadoAtaque.PosicaoJaAtacada;
        }

        if (!celula.EstaOcupada())
        {
            return ResultadoAtaque.Agua;
        }

        // Pendente: registrar o acerto no navio.
        throw new NotImplementedException();
    }



    public bool PosicionarNavio(
    Navio navio,
    int linha,
    int coluna,
    Orientacao orientacao)
    {
        // A implementação dependerá do tamanho do navio.
        throw new NotImplementedException();
    }



    public void Exibir()
    {
        foreach (Celula celula in Celulas)
        {
            if (celula.FoiAtacada)
            {
                if (celula.EstaOcupada())
                {
                    Console.Write("X ");
                }
                else
                {
                    Console.Write("O ");
                }
            }
            else if (celula.EstaOcupada())
            {
                Console.Write("N ");
            }
            else
            {
                Console.Write("~ ");
            }

            if (celula.Coluna == Tamanho - 1)
            {
                Console.WriteLine();
            }
        }
    }


}