
namespace RoyalGameOfUr.Model {
    class SplitField : NormalField {

        // Update
        private NormalField nextBlack;


        public void SetNextBlack(NormalField nextBlack) {
            this.nextBlack = nextBlack;
        }

        public NormalField GetNextBlack() {
            return nextBlack;
        }
    }
}
