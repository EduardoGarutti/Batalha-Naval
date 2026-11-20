namespace Batalha_Naval.Classes;

public class Celula
{
    public int Linha { get; }
    public int Coluna { get; }
    public bool FoiAtacada { get; private set; }

    public Navio? Navio { get; private set; }

    public Celula(int linha, int coluna)
    {
        this.Linha = linha;
        this.Coluna = coluna;
    }

    public bool ReceberAtaque()
    {
        if(FoiAtacada)
        {
            return false;
        }

        FoiAtacada = true;
        return true;
    }

    public bool EstaOcupada()
    {
        return Navio != null;
    }


    public bool PosicionarNavio(Navio navio)
    {
        if (EstaOcupada() || FoiAtacada)
        {
            return false;
        }

        Navio = navio;
        return true;
    }

}