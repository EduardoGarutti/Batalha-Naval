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
}