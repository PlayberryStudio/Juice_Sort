using GamePlay;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static Action<LevelConfig> OnLevelLoaded;

    public GameObject orange;
    public GameObject apple;

    [SerializeField]
    private int levelIndex = 1;

    private void Start()
    {
        LevelManager.Instance.TryGetLevel(levelIndex, out LevelConfig level);

        if (ReferenceEquals(level, null)) return;

        Debug.Log(JsonUtility.ToJson(level.continers));

        OnLevelLoaded?.Invoke(level);
    }
}
