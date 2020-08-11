using tabuleiro;

namespace xadrez {
    class Queen : Piece {
        public Queen(Board tab, Color cor)
            : base(tab, cor) {
        }
        public override string ToString() {
            return "Q";
        }
    }
}
