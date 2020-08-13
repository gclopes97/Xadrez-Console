using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using tabuleiro;

namespace xadrez {
    class ChessMatch {
        public Board Tab { get; private set; }
        public int Turno { get; private set; }
        public Color jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Piece> pecas;
        private HashSet<Piece> capturadas;
        public ChessMatch() {
            Tab = new Board();
            Turno = 1;
            jogadorAtual = Color.Branca;
            Terminada = false;
            pecas = new HashSet<Piece>();
            capturadas = new HashSet<Piece>();
            colocarPecas();
        }
        public void ExecutaMovimento(Position origem, Position destino) {
            Piece p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Piece pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
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
        public HashSet<Piece> PecasCapturadas(Color cor) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturadas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> PecasEmJogo(Color cor) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in capturadas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Piece peca) {
            Tab.ColocarPeca(peca, new PositionChess(coluna, linha).ToPosition());
            pecas.Add(peca);
        }
        private void colocarPecas() {
            //Brancas
            ColocarNovaPeca('a', 1, new Rook(Tab, Color.Branca));
            ColocarNovaPeca('b', 1, new Knight(Tab, Color.Branca));
            ColocarNovaPeca('c', 1, new Bishop(Tab, Color.Branca));
            ColocarNovaPeca('d', 1, new Queen(Tab, Color.Branca));
            ColocarNovaPeca('e', 1, new King(Tab, Color.Branca));
            ColocarNovaPeca('f', 1, new Bishop(Tab, Color.Branca));
            ColocarNovaPeca('g', 1, new Knight(Tab, Color.Branca));
            ColocarNovaPeca('h', 1, new Rook(Tab, Color.Branca));
            ColocarNovaPeca('a', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('b', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('c', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('d', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('e', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('f', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('g', 2, new Pawn(Tab, Color.Branca));
            ColocarNovaPeca('h', 2, new Pawn(Tab, Color.Branca));

            //Pretas
            ColocarNovaPeca('a', 8, new Rook(Tab, Color.Preta));
            ColocarNovaPeca('b', 8, new Knight(Tab, Color.Preta));
            ColocarNovaPeca('c', 8, new Bishop(Tab, Color.Preta));
            ColocarNovaPeca('d', 8, new Queen(Tab, Color.Preta));
            ColocarNovaPeca('e', 8, new King(Tab, Color.Preta));
            ColocarNovaPeca('f', 8, new Bishop(Tab, Color.Preta));
            ColocarNovaPeca('g', 8, new Knight(Tab, Color.Preta));
            ColocarNovaPeca('h', 8, new Rook(Tab, Color.Preta));
            ColocarNovaPeca('a', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('b', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('c', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('d', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('e', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('f', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('g', 7, new Pawn(Tab, Color.Preta));
            ColocarNovaPeca('h', 7, new Pawn(Tab, Color.Preta));
        }
    }
}
