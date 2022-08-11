using System;
using UnityEngine;

namespace EE.Core {
    [Serializable]
    public class DecisionGroupSO {
        [SerializeField]
        public GenericActionSO[] decisions = new GenericActionSO[0];

        [SerializeField] 
        public DecideType decideType = DecideType.AllTrue;

        public DecisionGroup GetDecisionGroup(IHasComponents hasComponents) {
            return new DecisionGroup() {
                decisions = decisions.GetActions(hasComponents),
                decideType = decideType
            };
        }
    }
}