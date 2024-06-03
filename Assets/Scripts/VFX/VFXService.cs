using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        //private List<VFXData> vfxData = new List<VFXData>();
        private VFXPool vpool;

        public VFXService(VFXView vfxView)
        {
            vpool = new VFXPool(vfxView);
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vpool.GetVFXController();
            vfxToPlay.Configure(type, spawnPosition);
        }
        public void ReturnToPool(VFXController returnVFX) => vpool.ReturnItem(returnVFX);
    } 
}