IniciarJogo();

//Função principal que inicializa o jogo.
//Instancia um objeto partida p. Iniciializa os tabuleiros e prepara os navios dos dois jogadores
void IniciarJogo()
{
    Partida p = new();

    p.Jogador1.Tabuleiro.Inicializar();
    p.Jogador2.Tabuleiro.Inicializar();

    p.Jogador1.PrepararNavios();
    p.Jogador2.PrepararNavios();

    for (int i = 0; i < 2; i++)
    {
        Jogador jogador;

        if (i == 0)
        {
            jogador = p.Jogador1;
        }
        else
        {
            jogador = p.Jogador2;
        }


        Console.WriteLine($"Informe o nome do jogador {i + 1}:");
        jogador.Nome = Console.ReadLine();

        int escolha = 0;

        while (escolha != 1 && escolha != 2)
        {
            Console.WriteLine(
                "========== POSICIONAMENTO DOS NAVIOS ==========\r\n\r\n" +
                "1 - Posicionamento manual\r\n" +
                "2 - Posicionamento automático\r\n\r\n" +
                "Escolha uma opção:");

            escolha = int.Parse(Console.ReadLine()!);

            switch (escolha)
            {
                case 1:
                    InformarNaviosManual(jogador);
                    break;

                case 2:
                    InformarNaviosAutomatico(jogador);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    p.Iniciar();
}

//Função para informar linha, coluna e posição dos navios
void InformarNaviosManual(Jogador jogador)
{
    foreach (Navio navio in jogador.Navios)
    {
        bool posicionado = false;

        while (!posicionado)
        {
            jogador.Tabuleiro.Exibir();
            Console.WriteLine();
            Console.WriteLine($"\nNavio: {navio.Nome}");
            Console.WriteLine($"Tamanho: {navio.Tamanho}");

            Console.Write("Informe a linha: ");
            int linha = int.Parse(Console.ReadLine()!);

            Console.Write("Informe a coluna: ");
            int coluna = int.Parse(Console.ReadLine()!);

            Console.WriteLine("1 - Horizontal");
            Console.WriteLine("2 - Vertical");

            Console.Write("Orientação: ");
            int escolhaOrientacao = int.Parse(Console.ReadLine()!);

            Orientacao orientacao;

            switch (escolhaOrientacao)
            {
                case 1:
                    orientacao = Orientacao.Horizontal;
                    break;
                case 2:
                    orientacao = Orientacao.Vertical;
                    break;
                default:
                    Console.WriteLine("Orientação inválida!");
                    continue;
            }

            posicionado = jogador.Tabuleiro.PosicionarNavio(
                navio, linha, coluna, orientacao);

            if (!posicionado)
                Console.WriteLine("Posição inválida! Tente novamente.");
            else
                Console.WriteLine("Navio posicionado com sucesso!");
        }
        Console.WriteLine();
    }
}

//Gera a posição dos navios de forma randomica
void InformarNaviosAutomatico(Jogador jogador)
{
    Random random = new Random();

    foreach (Navio navio in jogador.Navios!)
    {
        bool posicionado = false;

        while (!posicionado)
        {
            int linha = random.Next(0, 10);
            int coluna = random.Next(0, 10);

            //converte 0 em Horizontal e 1 em vertical
            Orientacao orientacao = (Orientacao)random.Next(0, 2);

            posicionado = jogador.Tabuleiro.PosicionarNavio(
                navio, linha, coluna, orientacao);
        }

        Console.WriteLine($"{navio.Nome} posicionado!");
    }

    Console.WriteLine("Todos os navios foram posicionados!");
}
