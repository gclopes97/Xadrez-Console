using tabuleiro;

namespace xadrez {
    class Knight : Piece {
        public Knight(Board tab, Color cor)
            : base(tab, cor) {
        }
        public override string ToString() {
            return "C";
        }
    }
}
