
using DefaultNamespace;
using UnityEngine;

public class Bootstrap : MonoBehaviour  , ICoroutineRunner
{
    [SerializeField] private GenerationSettings _generationSettings;
    [SerializeField] private LevelBound _levelBound;
    [SerializeField] private LevelPositionHandler _levelPosition;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private UIMediator _uiMediator;
    [SerializeField]private WindowsOpener _windowsOpener;
    private PrefabLoader _loader;
    private LevelFactory _levelFactory;
    private LevelGenerator _generator;
    
    private GameLoop _gameLoop;
    public void Start()
    {
        InitServices();
        
    }

    private void InitServices()
    {
        _loader = new PrefabLoader();
        _loader.StartLoad();
        _levelFactory = new LevelFactory(_loader , _playerInput , _levelPosition);
        _generator = new LevelGenerator(this , _generationSettings , _levelFactory);
        _gameLoop = new GameLoop(_levelFactory , _levelBound , _generator , _windowsOpener);
        _uiMediator.Construct(_gameLoop , _windowsOpener);

    }
}
