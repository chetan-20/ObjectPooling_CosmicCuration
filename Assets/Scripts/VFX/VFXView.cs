using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;

        [SerializeField] private List<VFXData> particle;
        private ParticleSystem currentParticleEffect;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType type, Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;

            foreach (VFXData item in particle)
            {
                if (item.type == type)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    currentParticleEffect = item.particleSystem;
                }
                else
                    item.particleSystem.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (currentParticleEffect != null)
            {
                if (currentParticleEffect.isStopped)
                {
                    currentParticleEffect.gameObject.SetActive(false);
                    currentParticleEffect = null;
                    controller.OnParticleEffectCompleted();
                    gameObject.SetActive(false);
                }
            }
        }

    }


    [Serializable]
    public class VFXData
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}