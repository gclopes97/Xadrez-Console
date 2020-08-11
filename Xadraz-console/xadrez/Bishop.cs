using tabuleiro;

namespace xadrez {
    class Bishop : Piece {
        public Bishop(Board tab, Color cor)
            : base(tab, cor) {
        }
        public override string ToString() {
            return "B";
        }
    }
}
