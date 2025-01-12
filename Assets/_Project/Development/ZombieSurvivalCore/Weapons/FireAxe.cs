using System.Collections;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons
{
    public class FireAxe : Weapon
    {
        public override void SimpleAttack()
        {
            animator.SetBool("IsSimpleAttack", true);
            
            StartCoroutine(AttackEndRoutine());
        }

        public override void Reload() { }

        public override void HoldableAttack()
        {
            
        }

        public override void HeavyAttack()
        {
            animator.SetBool("IsHeavyAttack", true);

            StartCoroutine(AttackEndRoutine());
        }

        private IEnumerator AttackEndRoutine()
        {
            yield return new WaitForSeconds(1f);
            
            animator.SetBool("IsSimpleAttack", false);
            animator.SetBool("IsHeavyAttack", false);
            EndAttack();
        }
    }
}