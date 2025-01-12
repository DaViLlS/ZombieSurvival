using System.Collections;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons
{
    public class PistolM1911 : Weapon
    {
        public override void SimpleAttack()
        {
            animator.SetBool("IsSimpleAttack", true);
            StartCoroutine(AttackEndRoutine());
        }

        public override void Reload()
        {
            animator.SetBool("IsReloading", true);
        }
        
        private IEnumerator  AttackEndRoutine()
        {
            yield return new WaitForSeconds(0.6f);
            
            animator.SetBool("IsSimpleAttack", false);
            animator.SetBool("IsHeavyAttack", false);
            EndAttack();
        }

        public override void HoldableAttack() { }

        public override void HeavyAttack() { }
    }
}