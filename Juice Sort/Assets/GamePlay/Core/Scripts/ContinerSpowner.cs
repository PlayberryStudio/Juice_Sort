using GamePlay;
using System;
using UnityEngine;

public class ContinerSpowner : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnLevelLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(LevelConfig config)
    {
        foreach(var continer in config.continers)
        {
            
        }
    }
}
