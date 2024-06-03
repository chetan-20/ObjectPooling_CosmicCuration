
using CosmicCuration.PowerUps;
using CosmicCuration.Utilities;
using System;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxView;
        public VFXPool(VFXView vfxView) => this.vfxView = vfxView;
        public VFXController GetVFXController() => GetItem<VFXController>();
        protected override VFXController CreateItem<T>() => new VFXController(this.vfxView);        
    }           
}