using tabuleiro;

namespace xadrez {
    class Rook : Piece {
        public Rook(Board tab, Color cor)
            : base(tab, cor) {
        }
        public override string ToString() {
            return "T";
        }
    }
}
