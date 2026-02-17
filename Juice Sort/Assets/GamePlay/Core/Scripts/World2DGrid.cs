
using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Tools
{

    public class World2DGrid : MonoBehaviour
    {
        [SerializeField]
        private bool isScreenWidth, isScreenheight;

        [SerializeField]
        public Vector2 size,grid;

        [SerializeField]
        float spacing = .1f;

        [SerializeField]
        private ObjectScaler scaler;

        [SerializeField]
        private GameObject prefab;

        [SerializeField]
        public Vector2 childSize;

        [SerializeField]
        private Transform pool;

        private void Start()
        {
            scaler.onSetCurrentAspect += OnScale;
        }
        private void OnDestroy()
        {
            scaler.onSetCurrentAspect -= OnScale;
        }

        private void OnScale(float raito)
        {
            Debug.Log(raito);

            size *= raito;
        }

        public List<GameObject> DrawCells(Vector2 grid, Vector2 cellSize)
        {
            GetFirstYPos(cellSize, out float yOffset);

            List<GameObject> objects = new List<GameObject>();
            Debug.Log("yOffset : "+ yOffset);
            for (int y = 0;y < grid.y; y++)
            {
                GetFirstXPos(cellSize.x, pool.childCount, y, grid.x,spacing, out float xOffset);
                for (int x = 0; x < grid.x; x++)
                {
                    GameObject obj = Instantiate(prefab);
                    obj.transform.localPosition = new Vector3(xOffset, yOffset);

                    xOffset -= cellSize.x + spacing;
                    Debug.Log("xOffset "+ xOffset);
                    objects.Add(obj);
                }

                yOffset -= cellSize.y + spacing;
            }

            return objects;
        }

        private void GetFirstYPos(Vector2 child,out float firstYPoint)
        {
            firstYPoint = GetRequirmentHeight(spacing,grid, child) / 2 - (child.y /2);
        }

        private float GetRequirmentHeight(float spacing,Vector2 grid, Vector2 child)
        {
            return (spacing * (grid.y - 1)) + (grid.y * child.y);
        }

        private void GetFirstXPos(float cellXSize, float allChilds, float lineIndex, float gridX,float xSpacing,out float xOffset)
        {
            if(GetChildInLine(gridX, allChilds, lineIndex, out float childInLineCount))
            {
                childInLineCount = gridX;
            }

            Debug.Log("childInLineCount " + lineIndex + "  "+ childInLineCount);

            xOffset = (xSpacing * (gridX - ((gridX + 1) - childInLineCount)) + childInLineCount * cellXSize) / 2 - (cellXSize / 2);
            Debug.Log("xOffset " + xOffset);
        }

        private bool GetChildInLine(float gridX,float allChilds,float lineIndex,out float childInLineCount)
        {
            childInLineCount = 0;
            float currentChildInLineCount = allChilds - (gridX * (lineIndex + 1));
            if (currentChildInLineCount >= 0) return true;

            childInLineCount = gridX - currentChildInLineCount;
            return false;
        }
    }
}