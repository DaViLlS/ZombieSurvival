using System.Collections.Generic;
using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies.EnemyStates.States;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies.EnemyStates
{
    public class EnemyStateMachine : StateMachine
    {
        [SerializeField] private Enemy enemy;

        public Enemy Enemy => enemy;
        
        private Dictionary<EnemyStateType, IState> _stateHandlers;
        
        public override void Initialize()
        {
            _stateHandlers = new Dictionary<EnemyStateType, IState>()
            {
                { EnemyStateType.Idle, new EnemyIdleState(this) },
                { EnemyStateType.Chase, new EnemyChaseState(this) },
                { EnemyStateType.Attack, new EnemyAttackState(this) },
            };

            ChangeStateByType(EnemyStateType.Chase);
        }
        
        public void ChangeStateByType(EnemyStateType enemyStateType)
        {
            ChangeState(_stateHandlers[enemyStateType]);
        }
    }
}