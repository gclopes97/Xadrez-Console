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
        public abstract bool[,] MovimentosPosiveis();
    }
}
