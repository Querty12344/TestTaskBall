using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelGenerator
    {
        private ICoroutineRunner _runner;
        private readonly GenerationSettings _settings;
        private LevelFactory _levelFactory;
        private bool _pause;

        public LevelGenerator(ICoroutineRunner runner , GenerationSettings settings , LevelFactory levelFactory)
        {
            _levelFactory = levelFactory;
            _runner = runner;
            _settings = settings;
        }
        public void StartGenerating()
        {
            _runner.StartCoroutine(Generation());
        }

        public void SetPause(bool pause)
        {
            _pause = pause;
        }

        public void Clear()
        {
            _runner.StopAllCoroutines();
        }
        
        private IEnumerator Generation()
        {
            int i = 0;
            _levelFactory.CreatePlatform(i%2 == 0 , Random.Range(_settings._minPlatformLength , _settings._maxPlatformLength) , true);
            while(true)
            {
                i++;
                if (!_pause)
                {
                    _levelFactory.CreatePlatform(i%2 == 0 , Random.Range(_settings._minPlatformLength , _settings._maxPlatformLength) , false);
                }

                yield return new WaitForSeconds(Random.Range(_settings._minTimeGap,_settings._maxTimeGap));
            }
            
        }
    }
}