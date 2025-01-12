using _Project.Development.Core.StateMachine;
using _Project.Development.ZombieSurvivalCore.Weapons;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Hands
{
    public class HandsController : MonoBehaviour
    {
        [SerializeField] private StateMachine stateMachine;

        [SerializeField] private Weapon _weapon;
        
        public Weapon Weapon => _weapon;

        public void Initialize()
        {
            stateMachine.Initialize();
        }
    }
}