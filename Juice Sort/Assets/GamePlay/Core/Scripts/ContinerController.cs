using GamePlay;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContinerController : MonoBehaviour , IGameContiner
{
    public bool isFill => true;

    public IFruit lastFruit => throw new System.NotImplementedException();

    public List<IFruit> fruits => _fruits;

    public int continerSectionCount => throw new System.NotImplementedException();

    private List<IFruit> _fruits = new List<IFruit>();

    [SerializeField]
    private List<Transform> places = new List<Transform>();

    public void Setup(List<IFruit> fruits)
    {
        _fruits = fruits;

        Debug.Log("Fruit : " + _fruits.Count);

        for(int i =0;i< _fruits.Count; i++)
        {
            GameObject fruit = Instantiate(_fruits[i].fruitPrefab, places[i]);
            fruit.transform.localPosition = new Vector2(0,0);
            fruit.transform.localScale = _fruits[i].fruitPrefab.transform.localScale;
        }
    }
}
