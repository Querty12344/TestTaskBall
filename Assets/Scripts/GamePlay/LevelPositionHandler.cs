using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelPositionHandler:MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawn;
        [SerializeField] private Transform _firstPlatformSpawn;
        [SerializeField] private Transform _upPlatformSpawn;
        [SerializeField] private Transform _downPlatformSpawn;
        
        public Transform PlayerSpawn => _playerSpawn;
        public Transform UpPlatformSpawn => _upPlatformSpawn;
        public Transform DownPlatformSpawn => _downPlatformSpawn;
        public Transform FirstPlatformPos => _firstPlatformSpawn;
    }
}