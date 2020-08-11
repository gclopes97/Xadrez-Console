using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadraz_console {
    class Screen {
        public static void imprimirTabuleiro(Board tab) {
            for (int i = 0; i < 8; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++) {
                    if (tab.Peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
            Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Piece peca) {
            if (peca.Cor == Color.Branca) {
                Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
