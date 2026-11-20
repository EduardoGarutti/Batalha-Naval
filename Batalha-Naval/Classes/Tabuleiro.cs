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

        celula.Navio!.ReceberAcerto();

        if (celula.Navio.EstaAfundado())
        {
            return ResultadoAtaque.NavioAfundado;
        }

        return ResultadoAtaque.Acerto;
    }





    public bool PosicionarNavio(
        Navio navio,
        int linha,
        int coluna,
        Orientacao orientacao)
    {

        if (navio == null || navio.Tamanho <= 0)
        {
            return false;
        }

        List<Celula> posicoes = new List<Celula>();

        for (int i = 0; i < navio.Tamanho; i++)
        {
            int linhaAtual = linha;
            int colunaAtual = coluna;

            if (orientacao == Orientacao.Horizontal)
            {
                colunaAtual += i;
            }
            else
            {
                linhaAtual += i;
            }

            Celula? celula = BuscarCelula(linhaAtual, colunaAtual);

            if (celula == null || celula.EstaOcupada() || celula.FoiAtacada)
            {
                return false;
            }

            posicoes.Add(celula);
        }

        foreach (Celula celula in posicoes)
        {
            celula.PosicionarNavio(navio);
        }

        return true;
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