using tabuleiro;

namespace tabuleiro {
    abstract class Piece {

        public Position Posicao { get; set; }
        public Color Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Board Tabuleiro { get; protected set; }

        public Piece(Board tabuleiro, Color cor) {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            this.QteMovimentos = 0;
        }
        public void IncrementarQteMovimentos() {
            QteMovimentos++;
        }
        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPosiveis();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PodeMoverPara(Position pos) {
            return MovimentosPosiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPosiveis();
    }
}
