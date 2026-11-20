//Classe responsavel pela logica principal do jogo
public class Partida
{
    public Jogador Jogador1;
    public Jogador Jogador2;
    public Jogador JogadorAtual;
    public bool Finalizada = false;

    //Incializa e controla o jogo. Controla a vez de quem vai jogar, Chama as funções de Realizar jogadas e verifica o vencedor.
    public void Iniciar()
    {
        JogadorAtual = Jogador1;
        while (!Finalizada)
        {
            Console.WriteLine("Jogador: " + JogadorAtual.Nome);
            RealizarJogada();
            if (VerificarVencedor())
            {
                Console.WriteLine("Jogador " + JogadorAtual.Nome + "Foi o vencedor!");
                Finalizada = true;
                AlternarJogador();
                Console.WriteLine("Jogador "+JogadorAtual.Nome+" Perdeu!");
                break;
            }
            AlternarJogador();
        }
    }

    //Realiza a jogadada do jogador atual. Verifica e mostra o resultado do ataque realizado
    public void RealizarJogada()
    {
        Console.WriteLine("Informe a linha que deseja atacar: ");
        int linha = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Informe a coluna que deseja atacar: ");
        int coluna = int.Parse(Console.ReadLine()!);

        ResultadoAtaque resultado = ReceberAtaque(linha, coluna);

        switch (resultado)
        {
            case ResultadoAtaque.Agua:
                Console.WriteLine("Tiro na Água!");
                break;
            case ResultadoAtaque.Acerto:
                Console.WriteLine("Navio acertado!");
                break;
            case ResultadoAtaque.NavioAfundado;
                Console.WriteLine("NAVIO ADVERSARIO AFUNDADO!");
                break;
            case ResultadoAtaque.PosicaoJaAtacada:
                Console.WriteLine("Essa posição já foi atacada!");
                break;
        }
    }

    //Alterna a vez de jogar entre jogador1 e jogador2
    public void AlternarJogador()
    {
        if (JogadorAtual.Equals(Jogador1))
        {
            JogadorAtual = Jogador2;
        }
        else
        {
            JogadorAtual = Jogador1;
        }
    }

    //Verifica se existe algum vencedor. Retorna true caso algum jogador tenha perdido todos os navios
    //Essa função é chamada após a realização do ataque do jogador atual, ou seja, ela só retorna "true" referente ao proximo jogador
    //Exemplo: caso o jogador1 ataque, apenas o jogador2 pode perder.
    public bool VerificarVencedor()
    {
        if (Jogador1.Perdeu())
        {
            return true;
        }

        if (Jogador2.Perdeu())
        {
            return true;
        }
        return false;
    }
}



