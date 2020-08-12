using tabuleiro;
using Xadraz_console.xadrez;

namespace xadrez {
    class ChessMatch {
        public Board Tab { get; private set; }
        public int Turno { get; private set; }
        public Color jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public ChessMatch() {
            Tab = new Board();
            Turno = 1;
            jogadorAtual = Color.Branca;
            Terminada = false;
            colocarPecas();
        }
        public void ExecutaMovimento(Position origem, Position destino) {
            Piece p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Piece pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }
        public void RealizaJogada(Position origem, Position destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        public void ValidarPosicaoDeOrigem(Position pos) {
            if (Tab.Peca(pos) == null) {
                throw new BoardException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != Tab.Peca(pos).Cor) {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis()) {
                throw new BoardException("Não há movimentos possíveis para a peça escolhida!");
            }
        }
        public void ValidarPosicaoDeDestino(Position origem, Position destino) {
            if (!Tab.Peca(origem).PodeMoverPara(destino)) {
                throw new BoardException("Posição de destino inválida!");
            }
        }
        private void MudaJogador() {
            if (jogadorAtual == Color.Branca) {
                jogadorAtual = Color.Preta;
            }
            else {
                jogadorAtual = Color.Branca;
            }
        }
        private void colocarPecas() {
            //Brancas
            Tab.ColocarPeca(new Rook(Tab, Color.Branca), new PositionChess('a', 1).ToPosition());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PositionChess('b', 1).ToPosition());
            Tab.ColocarPeca(new Bishop(Tab, Color.Branca), new PositionChess('c', 1).ToPosition());
            Tab.ColocarPeca(new Queen(Tab, Color.Branca), new PositionChess('d', 1).ToPosition());
            Tab.ColocarPeca(new King(Tab, Color.Branca), new PositionChess('e', 1).ToPosition());
            Tab.ColocarPeca(new Bishop(Tab, Color.Branca), new PositionChess('f', 1).ToPosition());
            Tab.ColocarPeca(new Knight(Tab, Color.Branca), new PositionChess('g', 1).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Branca), new PositionChess('h', 1).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('a', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('b', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('c', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('d', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('e', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('f', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('g', 2).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Branca), new PositionChess('h', 2).ToPosition());

            //Pretas
            Tab.ColocarPeca(new Rook(Tab, Color.Preta), new PositionChess('a', 8).ToPosition());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PositionChess('b', 8).ToPosition());
            Tab.ColocarPeca(new Bishop(Tab, Color.Preta), new PositionChess('c', 8).ToPosition());
            Tab.ColocarPeca(new Queen(Tab, Color.Preta), new PositionChess('d', 8).ToPosition());
            Tab.ColocarPeca(new King(Tab, Color.Preta), new PositionChess('e', 8).ToPosition());
            Tab.ColocarPeca(new Bishop(Tab, Color.Preta), new PositionChess('f', 8).ToPosition());
            Tab.ColocarPeca(new Knight(Tab, Color.Preta), new PositionChess('g', 8).ToPosition());
            Tab.ColocarPeca(new Rook(Tab, Color.Preta), new PositionChess('h', 8).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('a', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('b', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('c', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('d', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('e', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('f', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('g', 7).ToPosition());
            Tab.ColocarPeca(new Pawn(Tab, Color.Preta), new PositionChess('h', 7).ToPosition());
        }
    }
}
