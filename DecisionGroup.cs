namespace EE.Core {
    public class DecisionGroup {
        public GenericAction[] decisions = new GenericAction[0];
        public DecideType decideType = DecideType.AllTrue;

        public bool Decide() {
            int decisionCount = decisions.Length;
            if (decisionCount == 0) {
                return true;
            }

            for (int i = 0; i < decisions.Length; i++) {
                if (decisions[i].IsTrue()) {
                    decisionCount--;

                    if (decideType == DecideType.AnyTrue || decisionCount == 0) {
                        return true;
                    }
                }
                else if (decideType == DecideType.AllTrue) {
                    break;
                }
            }
            return false;
        }
    }
}