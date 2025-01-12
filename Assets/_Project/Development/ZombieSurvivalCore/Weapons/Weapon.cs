using System;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        private const string WalkAnimationTitle = "IsWalking";
        private const string RunAnimationTitle = "IsRunning";
        public event Action OnAttackEnded;
        
        [SerializeField] protected Animator animator;

        public abstract void SimpleAttack();
        public abstract void Reload();
        public abstract void HoldableAttack();
        public abstract void HeavyAttack();

        public void WalkAnimation(bool state)
        {
            animator.SetBool(WalkAnimationTitle, state);
        }
        
        public void RunAnimation(bool state)
        {
            animator.SetBool(RunAnimationTitle, state);
        }

        protected void EndAttack()
        {
            OnAttackEnded?.Invoke();
        }
    }
}