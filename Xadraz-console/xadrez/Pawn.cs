using tabuleiro;

namespace xadrez {
    class Pawn : Piece {
        public Pawn(Board tab, Color cor)
            : base(tab, cor) {
        }
        public override string ToString() {
            return "P";
        }
    }
}
