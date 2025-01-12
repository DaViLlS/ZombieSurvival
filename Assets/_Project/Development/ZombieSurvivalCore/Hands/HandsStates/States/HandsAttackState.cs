using System.Collections;
using UnityEngine;
using IState = _Project.Development.Core.StateMachine.IState;

namespace _Project.Development.ZombieSurvivalCore.Hands.HandsStates.States
{
    public class HandsAttackState : IState
    {
        private const float FixedTime = 0.5f;
        
        private readonly HandsStateMachine _stateMachine;

        private Coroutine _waitCoroutine;
        private bool _isAttackCancelled;
        private float _heavyAttackTime;
        
        public HandsAttackState(HandsStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            Debug.Log("Attack state entered");
            
            _stateMachine.InputHandler.OnAttackCancelled += OnAttackCancelled;
            _heavyAttackTime = 0f;

            _waitCoroutine = _stateMachine.StartCoroutine(WaitAttackRoutine());
        }

        public void OnExitState() { }
        
        private void OnAttackCancelled()
        {
            _stateMachine.InputHandler.OnAttackCancelled -= OnAttackCancelled;
            
            _stateMachine.StopCoroutine(_waitCoroutine);

            Debug.Log(_heavyAttackTime >= FixedTime ? "Heavy attack" : "Simple attack");

            _stateMachine.ChangeStateByType(HandsStateType.Idle);
        }

        private IEnumerator WaitAttackRoutine()
        {
            while(true)
            {
                yield return new WaitForEndOfFrame();

                _heavyAttackTime += Time.deltaTime;
            }
        }

        private IEnumerator AttackRoutine()
        {
            yield return new WaitForSeconds(1f);
            
            Debug.Log("Attacked");
            _stateMachine.ChangeStateByType(HandsStateType.Idle);
        }
        
        public void Execute() { }

        public void FixedExecute() { }
    }
}