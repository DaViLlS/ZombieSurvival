using UnityEngine;

namespace _Project.Development.Core.StateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected IState _currentState;

        public abstract void Initialize();

        public void ChangeState(IState nextState)
        {
            _currentState?.OnExitState();
            _currentState = nextState;
            _currentState.OnEnterState();
        }

        private void Update()
        {
            ExecuteState();
        }

        private void FixedUpdate()
        {
            FixedExecuteState();
        }

        public void FixedExecuteState()
        {
            _currentState.FixedExecute();
        }

        public void ExecuteState()
        {
            _currentState.Execute();
        }
    }
}
