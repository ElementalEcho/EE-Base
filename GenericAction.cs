using System;

namespace EE.Core {
    [Serializable]
    public abstract class GenericAction<T> {

        public virtual void Init(T controller) { }

        public virtual void Enter() { }
        public virtual void Enter(IHasComponents target) { }

        public virtual void Act(float tickSpeed) { }

        public virtual void FixedAct(float tickSpeed) { }

        public virtual void Exit() { }

        public virtual bool ExitCondition() {
            return true;
        }

        protected virtual bool Decide() {
            return true;
        }
        public virtual bool IsTrue() => Decide();

        public virtual int MaxRequirement => 1;
        public virtual int Completed => IsTrue() ? 1 : 0;

    }
    [Serializable]
    public abstract class GenericAction : GenericAction<IHasComponents> {
        public IHasGenericAction _originSO;
        public string name;
        public string Name => name;

        public override bool IsTrue() => Decide() != (_originSO != null && _originSO.Reverse);

    }
    public interface IHasGenericAction {
        GenericAction GetAction(IHasComponents stateMachine);
        bool Reverse { get; }
    }
}
