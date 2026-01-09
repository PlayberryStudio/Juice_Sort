using GamePlay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<LevelConfig> levels => _levels;

    [SerializeField]
    private List<LevelConfig> _levels;

    public bool TryGetLevel(int levelIndex,out LevelConfig level)
    {
        level = _levels.FirstOrDefault(level => level.levelIndex.Equals(levelIndex));

        return !ReferenceEquals(level, null);
    }
}

public class Singleton<T> : MonoBehaviour
{
    public static Singleton<T> Instance;

    protected virtual void Awake()
    {
        if(ReferenceEquals(Instance,null))
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    protected virtual void OnDestroy()
    {
        if (ReferenceEquals(Instance, null) || !ReferenceEquals(Instance, this)) return;

        Instance = null;
    }
}
