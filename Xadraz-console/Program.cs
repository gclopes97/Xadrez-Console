using System;
using tabuleiro;
using xadrez;

namespace Xadraz_console {
    class Program {
        static void Main(string[] args) {
            try {
                Board p = new Board();
                p.ColocarPeca(new Rook(p, Color.Preta), new Position(0, 0));
                p.ColocarPeca(new Rook(p, Color.Preta), new Position(1, 3));
                p.ColocarPeca(new King(p, Color.Preta), new Position(2, 4));

                p.ColocarPeca(new Rook(p, Color.Branca), new Position(7, 7));
                p.ColocarPeca(new Rook(p, Color.Branca), new Position(7, 5));
                p.ColocarPeca(new King(p, Color.Branca), new Position(6, 4));

                Screen.imprimirTabuleiro(p);
            }
            catch (BoardException e) {
                Console.WriteLine("Erro no tabuleiro: " + e.Message);
            }
        }
    }
}
