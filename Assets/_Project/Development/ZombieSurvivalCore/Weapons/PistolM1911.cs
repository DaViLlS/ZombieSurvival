using System.Collections;
using _Project.Development.ZombieSurvivalCore.Bullets;
using _Project.Development.ZombieSurvivalCore.Health;
using _Project.Development.ZombieSurvivalCore.Weapons.ShootEffect;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons
{
    public class PistolM1911 : Weapon
    {
        [SerializeField] private Transform bulletParent;
        [SerializeField] private Bullet bullet;
        [SerializeField] private float damage;
        [SerializeField] private ShootEffectController shootEffect;
        
        public override void SimpleAttack()
        {
            animator.SetBool("IsSimpleAttack", true);
            
            var angle = Vector3.Dot(UnityEngine.Camera.main.transform.forward, transform.forward);
            var direction = UnityEngine.Camera.main.transform.forward - (transform.forward * angle);
            
            Instantiate(bullet, bulletParent.position, Quaternion.LookRotation(transform.forward, direction));
            
            var layerMaskOnlyPlayer = 1 << 8;
            var layerMaskWithoutPlayer = ~layerMaskOnlyPlayer;
            
            if (Physics.Raycast(UnityEngine.Camera.main.transform.position,
                    UnityEngine.Camera.main.transform.forward, out var hitInfo, 100, layerMaskWithoutPlayer))
            {
                if (hitInfo.collider.gameObject.TryGetComponent<Limb>(out var limb))
                {
                    Debug.Log(hitInfo.collider.gameObject.name);
                    limb.Damage(damage);
                }
            }
            
            shootEffect.Play();
            
            StartCoroutine(AttackEndRoutine());
            StartCoroutine(ShootEffectRoutine());
        }

        public override void Reload()
        {
            animator.SetBool("IsReloading", true);
            StartCoroutine(ReloadingEndRoutine());
        }

        private IEnumerator ShootEffectRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            shootEffect.Stop();
        }
        
        private IEnumerator  AttackEndRoutine()
        {
            yield return new WaitForSeconds(0.6666667f);
            
            animator.SetBool("IsSimpleAttack", false);
            animator.SetBool("IsHeavyAttack", false);
            EndAttack();
        }

        private IEnumerator ReloadingEndRoutine()
        {
            yield return new WaitForSeconds(0.9162011f);
            animator.SetBool("IsReloading", false);
            EndReload();
        }

        public override void HoldableAttack() { }

        public override void HeavyAttack() { }
    }
}