using System.Collections;
using _Project.Development.ZombieSurvivalCore.Bullets;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons
{
    public class PistolM1911 : Weapon
    {
        [SerializeField] private Transform bulletParent;
        [SerializeField] private Bullet bullet;
        
        public override void SimpleAttack()
        {
            animator.SetBool("IsSimpleAttack", true);
            
            Instantiate(bullet, bulletParent.position, bulletParent.rotation);
            
            StartCoroutine(AttackEndRoutine());
        }

        public override void Reload()
        {
            animator.SetBool("IsReloading", true);
        }
        
        private IEnumerator  AttackEndRoutine()
        {
            yield return new WaitForSeconds(0.6666667f);
            
            animator.SetBool("IsSimpleAttack", false);
            animator.SetBool("IsHeavyAttack", false);
            EndAttack();
        }

        public override void HoldableAttack() { }

        public override void HeavyAttack() { }
    }
}