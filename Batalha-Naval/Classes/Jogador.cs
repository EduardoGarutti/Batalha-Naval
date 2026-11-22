using Batalha_Naval.Classes;

public class Jogador
{
    public string? Nome { get; set; }
    public Tabuleiro? Tabuleiro { get; set; }
    public List<Navio>? Navios { get; set; } = new List<Navio>();

    public void AdicionarNavio(Navio navio)
    {
        Navios?.Add(navio);
    }

    public void PrepararNavios()
    {
        Destroyer destroyer = new Destroyer();
        AdicionarNavio(destroyer);
        
        Submarino submarino = new Submarino();
        AdicionarNavio(submarino);
        
        Encouracado encouracado = new Encouracado();
        AdicionarNavio(encouracado);
        
        PortaAvioes portaAvioes = new PortaAvioes();
        AdicionarNavio(portaAvioes);
        
    }

    public bool Perdeu()
    {
        foreach (var navio in Navios)
        {
            if (!navio.EstaAfundado() == true)
            {
                return false;
            }

        }
        return true;

    }
}
