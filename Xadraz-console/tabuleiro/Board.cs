using Xadraz_console.tabuleiro;

namespace tabuleiro {
    class Board {
        private int linhas;
        private int colunas;
        private Piece[,] pecas;
        public Board() {
            this.linhas = 8;
            this.colunas = 8;
            pecas = new Piece[linhas, colunas];
        }        
        public override string ToString() {
            return linhas
                + ", "
                + colunas
                + pecas.Length;
        }
    }
}
