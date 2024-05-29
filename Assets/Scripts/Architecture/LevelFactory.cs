using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelFactory
    {

        private List<PlatformMover> _pool = new List<PlatformMover>();
        private readonly PrefabLoader _prefabLoader;
        private PlayerInput _input;
        private LevelPositionHandler _levelPositionHandler;
        private PlayerGravitation _player;

        public LevelFactory(PrefabLoader prefabLoader , PlayerInput input , LevelPositionHandler levelPositionHandler)
        {
            _levelPositionHandler = levelPositionHandler;
            _input = input;
            _prefabLoader = prefabLoader;
        }
        
        public void ClearLevel()
        {
            foreach (var gameObject in _pool)
            {
                GameObject.Destroy(gameObject.gameObject);
            }
            if(_player != null)
             _player.Remove();
            _pool.Clear();
        }
        
        public void CreatePlayer()
        {
            var player = _prefabLoader.GetPlayer();
            _player = GameObject.Instantiate(player, _levelPositionHandler.PlayerSpawn.position, Quaternion.identity).GetComponent<PlayerGravitation>();
            _player.Construct(_input);
            _player.GetComponent<PlayerPointsCounter>().StartCount();
        }
        

        public void PauseAll(bool pause)
        {
            _player.SetPause(pause);
            _pool.ForEach(x => x.SetPause(pause));
            _player.GetComponent<PlayerPointsCounter>().SetPause(pause);
        }

        public void CreatePlatform(bool up , float xScale , bool first )
        {
            var platform = _prefabLoader.GetPlatform();
            PlatformMover platformMover;
            if (first)
            {
                platformMover = GameObject.Instantiate(platform , _levelPositionHandler.FirstPlatformPos.position,
                    Quaternion.identity).GetComponent<PlatformMover>();
            }
            else
            {
                 platformMover = GameObject.Instantiate(platform,
                    up ? _levelPositionHandler.UpPlatformSpawn.position : _levelPositionHandler.DownPlatformSpawn.position,
                    Quaternion.identity).GetComponent<PlatformMover>();

            }
            _pool.Add(platformMover);
            Vector3 startScale = platform.transform.localScale ;
            startScale.x = startScale.x * xScale;
            platformMover.transform.localScale = (startScale);
        }

        public int GetPlayerPoints()
        {
            return _player.GetComponent<PlayerPointsCounter>().GetPoints();
        }
    }
}