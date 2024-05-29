using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GenerationSettings" , menuName = "GenerationSettings")]
    public class GenerationSettings:ScriptableObject
    {
        public float _maxPlatformLength;
        public float _minPlatformLength;
        public float _minTimeGap;
        public float _maxTimeGap;
    }
}