using System.Collections.Generic;
using UnityEngine;

namespace _Project.Development.ZombieSurvivalCore.Weapons.ShootEffect
{
    public class ShootEffectController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem mainParticle;
        [SerializeField] private ParticleSystem glow;
        [SerializeField] private GameObject shootLight;
        [SerializeField] private ParticleSystem planeParticle1;
        [SerializeField] private ParticleSystem planeParticle2;
        [SerializeField] private ParticleSystem planeParticle3;
        [SerializeField] private ParticleSystem sparksParticle;

        public void Play()
        {
            gameObject.SetActive(true);
            mainParticle.Play();
            glow.Play();
            planeParticle1.Play();
            planeParticle2.Play();
            planeParticle3.Play();
            sparksParticle.Play();
            shootLight.SetActive(true);
        }

        public void Stop()
        {
            gameObject.SetActive(false);
            mainParticle.Stop();
            glow.Stop();
            planeParticle1.Stop();
            planeParticle2.Stop();
            planeParticle3.Stop();
            sparksParticle.Stop();
            shootLight.SetActive(false);
        }
    }
}