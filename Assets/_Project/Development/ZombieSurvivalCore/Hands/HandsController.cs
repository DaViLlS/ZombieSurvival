using _Project.Development.Core.StateMachine;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Hands
{
    public class HandsController : MonoBehaviour
    {
        [SerializeField] private StateMachine stateMachine;

        public void Initialize()
        {
            stateMachine.Initialize();
        }
    }
}