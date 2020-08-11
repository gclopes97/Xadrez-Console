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

        public Piece Peca(int linha, int coluna){
            return pecas[linha, coluna];
        }
    }
}
