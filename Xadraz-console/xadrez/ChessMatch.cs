using System;
using tabuleiro;
using Xadraz_console.xadrez;

namespace xadrez {
    class ChessMatch {
        public Board tab { get; private set; }
        private int turno;
        private Color jogadorAtual;
        public bool Terminada { get; private set; }
        public ChessMatch() {
            tab = new Board();
            turno = 1;
            jogadorAtual = Color.Branca;
            Terminada = false;
            colocarPecas();
        }
        public void ExecutaMovimento(Position origem, Position destino) {
            Piece p = tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Piece pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }
        private void colocarPecas() {
            //Brancas
            tab.ColocarPeca(new Rook(tab, Color.Branca), new PositionChess('c', 1).ToPosition());
            tab.ColocarPeca(new Knight(tab, Color.Branca), new PositionChess('c', 2).ToPosition());
            tab.ColocarPeca(new Bishop(tab, Color.Branca), new PositionChess('d', 2).ToPosition());
            tab.ColocarPeca(new Pawn(tab, Color.Branca), new PositionChess('e', 2).ToPosition());
            tab.ColocarPeca(new Queen(tab, Color.Branca), new PositionChess('e', 1).ToPosition());
            tab.ColocarPeca(new King(tab, Color.Branca), new PositionChess('d', 1).ToPosition());

            //Pretas
            tab.ColocarPeca(new Rook(tab, Color.Preta), new PositionChess('c', 7).ToPosition());
            tab.ColocarPeca(new Knight(tab, Color.Preta), new PositionChess('c', 8).ToPosition());
            tab.ColocarPeca(new Bishop(tab, Color.Preta), new PositionChess('d', 7).ToPosition());
            tab.ColocarPeca(new Pawn(tab, Color.Preta), new PositionChess('e', 7).ToPosition());
            tab.ColocarPeca(new Queen(tab, Color.Preta), new PositionChess('e', 8).ToPosition());
            tab.ColocarPeca(new King(tab, Color.Preta), new PositionChess('d', 8).ToPosition());
        }
    }
}
