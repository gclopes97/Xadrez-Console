using tabuleiro;

namespace xadrez {
    class King : Piece{
        private ChessMatch partida;
        public King(Board tab, Color cor, ChessMatch partida) 
            :base(tab, cor) {
            this.partida = partida;
        }
        private bool PodeMover(Position pos) {
            Piece p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool TesteTorreParaRoque(Position pos) {
            Piece p = Tabuleiro.Peca(pos);
            return p != null && p is Rook && p.Cor == Cor && p.QteMovimentos == 0;
        }
        public override bool[,] MovimentosPosiveis() {
            bool[,] mat = new bool[8, 8];

            Position pos = new Position(0, 0);
            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }


            //#Jogada Especial Rook
            if (QteMovimentos == 0 && !partida.Xeque) {
                //#Jogada especial rook pequeno
                Position posT1 = new Position(Posicao.Linha, Posicao.Coluna + 3);
                if (TesteTorreParaRoque(posT1)) {
                    Position p1 = new Position(Posicao.Linha, Posicao.Coluna + 1);
                    Position p2 = new Position(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.Peca(p1)==null && Tabuleiro.Peca(p2) == null) {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                //#Jogada especial rook grande
                Position posT2 = new Position(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(posT2)) {
                    Position p1 = new Position(Posicao.Linha, Posicao.Coluna - 1);
                    Position p2 = new Position(Posicao.Linha, Posicao.Coluna - 2);
                    Position p3 = new Position(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null) {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
        public override string ToString() {
            return "R";
        }
    }
}
