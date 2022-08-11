using System;
using UnityEngine;

namespace EE.Core {
    [Serializable]
    public abstract class GenericActionSO : ScriptableObject, IHasGenericAction {
        [SerializeField]
        private bool reverse = false;
        public bool Reverse => reverse;
        public GenericAction GetAction(IHasComponents stateMachine) {
            var action = CreateAction();
            action._originSO = this;
            action.name = name;
            if (stateMachine != null) {
                action.Init(stateMachine);
            }
            return action;
        }
        protected abstract GenericAction CreateAction();
    }
    [Serializable]
    public abstract class GenericActionSO<T> : GenericActionSO where T : GenericAction, new() {
        protected override GenericAction CreateAction() => new T();

    }

    public static class GenericActionUtils {
        public static GenericAction[] GetActions(this IHasGenericAction[] scriptableActions, IHasComponents stateMachine) {
            int count = scriptableActions.Length;
            var actions = new GenericAction[count];
            for (int i = 0; i < count; i++)
                actions[i] = scriptableActions[i].GetAction(stateMachine);

            return actions;
        }

        public static GenericAction[] GetActions(this GenericActionSO[] scriptableActions, IHasComponents stateMachine) {
            int count = scriptableActions.Length;
            var actions = new GenericAction[count];
            for (int i = 0; i < count; i++) {
                actions[i] = scriptableActions[i].GetAction(stateMachine);
            }

            return actions;
        }
    }
}
