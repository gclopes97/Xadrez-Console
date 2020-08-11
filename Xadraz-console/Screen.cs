using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace Xadraz_console {
    class Screen {
        public static void imprimirTabuleiro(Board tab) {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (tab.Peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                    Console.Write(tab.Peca(i,j) + " ");
                    }
                }
            Console.WriteLine();
            }
        }
    }
}
