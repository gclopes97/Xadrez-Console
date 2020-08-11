using tabuleiro;

namespace tabuleiro {
    class Board {
        private static int linhas = 8;
        private static int colunas = 8;
        private Piece[,] pecas = new Piece[linhas, colunas];
        public Board() {
        }
        public override string ToString() {
            return linhas
                + ", "
                + colunas
                + pecas.Length;
        }
        public Piece Peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }
        public Piece Peca(Position pos) {
            return pecas[pos.Linha, pos.Coluna];
        }
        public bool ExistePeca(Position pos) {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }
        public void ColocarPeca(Piece p, Position pos) {
            if (ExistePeca(pos)) {
                throw new BoardException("Já existe uma peça nessa posição!");
            }
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        public bool PosicaoValida(Position pos) {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas) {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Position pos) {
            if (!PosicaoValida(pos)) {
                throw new BoardException("Posição inválida!");
            } 
        }
    }
}
