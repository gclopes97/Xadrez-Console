using System;
using xadrez;
using tabuleiro;
using System.Collections.Generic;

namespace Xadraz_console {
    class Screen {
        public static void ImprimirPartida(ChessMatch partida) {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            if (partida.Xeque) {
                Console.WriteLine("XEQUE!");
            }
        }
        public static void ImprimirPecasCapturadas(ChessMatch partida) {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Color.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Color.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void ImprimirConjunto(HashSet<Piece> conjunto) {
            Console.Write("[");
            foreach (Piece x in conjunto) {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Board tab) {
            for (int i = 0; i < 8; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++) {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void imprimirTabuleiro(Board tab, bool[,] posicoesPossiveis) {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < 8; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }
        public static void ImprimirPeca(Piece peca) {

            if (peca == null) {
                Console.Write("- ");
            }
            else {
                if (peca.Cor == Color.Branca) {
                    Console.Write(peca);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static PositionChess LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PositionChess(coluna, linha);
        }
    }
}
