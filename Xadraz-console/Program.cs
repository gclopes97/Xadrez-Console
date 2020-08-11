using System;
using tabuleiro;

namespace Xadraz_console {
    class Program {
        static void Main(string[] args) {
            Board p = new Board();
            Screen.imprimirTabuleiro(p);
        }
    }
}
