using System;
using tabuleiro;
using xadrez;

namespace Xadraz_console {
    class Program {
        static void Main(string[] args) {
            Board p = new Board();
            p.ColocarPeca(new Rook(p, Color.Preta), new Position(0, 0));
            p.ColocarPeca(new Rook(p, Color.Preta), new Position(1, 3));
            p.ColocarPeca(new King(p, Color.Preta), new Position(2, 4));

            Screen.imprimirTabuleiro(p);
        }
    }
}
