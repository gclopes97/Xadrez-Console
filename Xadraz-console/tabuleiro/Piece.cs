using tabuleiro;

namespace tabuleiro {
    class Piece {
        public Position Posicao { get; set; }
        public Color Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Board Tabuleiro { get; protected set; }

        public Piece(Position posicao, Color cor, Board tabuleiro) {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            this.QteMovimentos = 0;
        }
    }
}
