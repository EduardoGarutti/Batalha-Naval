public abstract class Navio
{
    public string Nome { get; protected set; }
    public int Tamanho { get; protected set; }
    public int Acertos { get; protected set; }

    public void ReceberAcerto()
    {
        if (Acertos < Tamanho)
        {
            Acertos++;
        }
    }

    public bool EstaAfundado()
    {
        if (Acertos == Tamanho)
        {
            return true;
        }
        return false;
    }

}