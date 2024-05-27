using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private BulletPool bulletPool;
        private PlayerController playerController;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPrefab, bulletScriptableObject);
            bulletPool = new BulletPool(bulletPrefab,bulletScriptableObject);
        }

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();
        
    } 
}