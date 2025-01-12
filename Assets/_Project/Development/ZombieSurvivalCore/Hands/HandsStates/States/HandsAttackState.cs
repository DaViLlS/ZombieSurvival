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
        private float _heavyAttackTime;
        
        public HandsAttackState(HandsStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void OnEnterState()
        {
            _stateMachine.InputHandler.OnAttackCancelled += OnAttackCancelled;
            _heavyAttackTime = 0f;
            _waitCoroutine = _stateMachine.StartCoroutine(WaitAttackRoutine());
        }

        public void OnExitState() { }
        
        private void OnAttackCancelled()
        {
            _stateMachine.InputHandler.OnAttackCancelled -= OnAttackCancelled;
            _stateMachine.StopCoroutine(_waitCoroutine);

            if (_heavyAttackTime >= FixedTime)
            {
                _stateMachine.HandsController.Weapon.OnAttackEnded += OnAttackEnded;
                _stateMachine.HandsController.Weapon.HeavyAttack();
            }
            else
            {
                _stateMachine.HandsController.Weapon.OnAttackEnded += OnAttackEnded;
                _stateMachine.HandsController.Weapon.SimpleAttack();
            }
        }

        private void OnAttackEnded()
        {
            _stateMachine.HandsController.Weapon.OnAttackEnded -= OnAttackEnded;
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
        
        public void Execute() { }

        public void FixedExecute() { }
    }
}