using Entitas;
using UnityEngine;
/// <summary>
/// 游戏总控制器
/// </summary>
public class GameController : MonoBehaviour
{
    private GameSystemsController _systems;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _systems = new GameSystemsController(_contexts);

        DontDestroyOnLoad(_systems.gameObject);
    }

    void Start()
    { 
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy()
    {
        _systems.TearDown();
    }

    private void OnApplicationQuit()
    {
        _systems.TearDown();
    }




}