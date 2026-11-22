//Classe responsavel pela logica principal do jogo
public class Partida
{
    public Jogador Jogador1 = new Jogador();
    public Jogador Jogador2 = new Jogador();
    public Jogador JogadorAtual;
    public bool Finalizada = false;

    public Partida()
    {
        JogadorAtual = Jogador1;
    }

    //Incializa e controla o jogo. Controla a vez de quem vai jogar, Chama as funções de Realizar jogadas e verifica o vencedor.
    public void Iniciar()
    {
        while (!Finalizada)
        {
            ExibirTabuleiros();
            Console.WriteLine("\nVez de jogar: " + JogadorAtual.Nome);

            RealizarJogada();

            if (VerificarVencedor())
            {
                Console.WriteLine("\nJogador " + JogadorAtual.Nome + " venceu!");
                Finalizada = true;
            }
            else
            {
                AlternarJogador();
            }
        }

    }

    //Realiza a jogadada do jogador atual. Verifica e mostra o resultado do ataque realizado
    public void RealizarJogada()
    {
        ResultadoAtaque resultado;

        do
        {
            Console.WriteLine("Informe a linha que deseja atacar: ");
            int linha = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Informe a coluna que deseja atacar: ");
            int coluna = int.Parse(Console.ReadLine()!);

            Jogador adversario = ObterAdversario();

            resultado = adversario.Tabuleiro!.ReceberAtaque(linha, coluna);

            switch (resultado)
            {
                case ResultadoAtaque.Agua:
                    Console.WriteLine("Tiro na Água!");
                    break;
                case ResultadoAtaque.Acerto:
                    Console.WriteLine("Navio acertado!");
                    break;
                case ResultadoAtaque.NavioAfundado:
                    Console.WriteLine("NAVIO ADVERSARIO AFUNDADO!");
                    break;
                case ResultadoAtaque.PosicaoJaAtacada:
                    Console.WriteLine("Essa posição já foi atacada!");
                    break;
            }
        } while (resultado == ResultadoAtaque.PosicaoJaAtacada);
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

    //Função auxliar. Verifica e retorna quem é o jogador adversáro
    public Jogador ObterAdversario()
    {
        if (JogadorAtual == Jogador1)
            return Jogador2;

        return Jogador1;
    }

    //Imprime o tabuleiro do jogador atual de forma normal e do jogador adversario de forma ocultada.
    // Azul = jogador atual. Vermelho = jogador Adversario
    public void ExibirTabuleiros()
    {
        //Printa o nome do jogador atual em azul
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{"   JOGADOR ATUAL: " + JogadorAtual.Nome,-25}");

        //Printa o nome do jogador adversario em vermelho
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("      JOGADOR ADVERSARIO: " + ObterAdversario().Nome);

        //0-9 das colunas em azul
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("   ");
        for (int coluna = 0; coluna < 10; coluna++)
        {
            Console.Write(coluna + " ");
        }
            
        //0-9 das colunas em vermelho
        Console.Write("        ");
        Console.ForegroundColor = ConsoleColor.Red;
        for (int coluna = 0; coluna < 10; coluna++)
            Console.Write(coluna + " ");

        Console.WriteLine();

        for (int linha = 0; linha < 10; linha++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{linha,2} ");
            JogadorAtual.Tabuleiro!.ExibirLinha(linha);

            Console.Write("     ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{linha,2} ");
            ObterAdversario().Tabuleiro!.ExibirLinha(linha, true);

            Console.WriteLine();
        }
        Console.ResetColor();
    }


    //Verifica se existe algum vencedor. Retorna true caso algum jogador tenha perdido todos os navios
    //Essa função é chamada após a realização do ataque do jogador atual, ou seja, ela só retorna "true" referente ao proximo jogador
    //Exemplo: caso o jogador1 ataque, apenas o jogador2 pode perder.
    public bool VerificarVencedor()
    {
        return ObterAdversario().Perdeu();
    }
}



