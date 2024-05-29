using UnityEngine;

namespace DefaultNamespace
{
    public class PrefabLoader
    {
        private const string PlatformPath = "Platform";
        private const string PlayerPath = "Player";
        private PlayerGravitation _player;
        private GameObject _platform;
        public void StartLoad()
        {
            _platform = Resources.Load<GameObject>(PlatformPath);
            _player = Resources.Load<PlayerGravitation>(PlayerPath);
        }

        public PlayerGravitation GetPlayer()
        {
            return _player;
        }

        public GameObject GetPlatform()
        {
            return _platform;
        }
    }                      
}