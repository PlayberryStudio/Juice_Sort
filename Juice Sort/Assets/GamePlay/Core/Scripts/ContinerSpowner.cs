using GamePlay;
using GamePlay.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ContinerSpowner : MonoBehaviour
{
    [SerializeField] private World2DGrid grid;

    private void Awake()
    {
        GameManager.OnLevelLoaded += OnLevelLoaded;
    }

    private void OnLevelLoaded(LevelConfig config)
    {
        int continerDataIndex = 0;

        var objects = grid.DrawCells(new Vector2(config.continers.Count, grid.grid.y), grid.childSize);
            
        foreach ( var continer in objects )
        {
            ContinerController controller = continer.GetComponent<ContinerController>();

            List<IFruit> fruits = new List<IFruit>();
            fruits.AddRange(config.continers[continerDataIndex].fruits);

            controller.Setup(fruits);

            continerDataIndex++;
        };
    }
}
