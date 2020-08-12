using System;
using tabuleiro;
using xadrez;

namespace Xadraz_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch partida = new ChessMatch();
                while (!partida.Terminada) {
                    try {
                        Console.Clear();
                        Screen.imprimirTabuleiro(partida.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origem = Screen.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPosiveis();

                        Console.Clear();
                        Screen.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destino = Screen.LerPosicaoXadrez().ToPosition();
                        partida.ValidarPosicaoDeDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (BoardException e) {
                        Console.WriteLine("Erro: " + e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (BoardException e) {
                Console.WriteLine("Erro no tabuleiro: " + e.Message);
            }
        }
    }
}
