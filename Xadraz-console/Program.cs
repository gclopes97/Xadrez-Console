using System;
using tabuleiro;
using xadrez;

namespace Xadraz_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessMatch partida = new ChessMatch();
                while (!partida.Terminada) {
                    Console.Clear();
                    Screen.imprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origem = Screen.LerPosicaoXadrez().ToPosition();
                    Console.Write("Destino: ");
                    Position destino = Screen.LerPosicaoXadrez().ToPosition();

                    partida.ExecutaMovimento(origem, destino);
                }

            }
            catch (BoardException e) {
                Console.WriteLine("Erro no tabuleiro: " + e.Message);
            }
        }
    }
}
