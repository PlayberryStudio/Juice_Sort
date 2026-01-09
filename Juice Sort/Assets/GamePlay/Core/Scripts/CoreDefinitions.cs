

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public enum fruitType
    {
        None = 0,
        Apple = 1,
        Orange = 2,
    }

    public interface IFruit
    {
        public fruitType fruitType { get; }

        public GameObject fruitPrefab { get; }
    }

    public interface IContiner
    {
        public List<IFruit> fruits { get; }

        public int continerSectionCount { get; }
    }

    public interface IGameContiner : IContiner
    {
        public bool isFill { get; }

        public IFruit lastFruit { get; }
    }

    public interface ILevelConfig
    {
        public List<LevelContiner> continers { get; }

        public int levelIndex { get; }

        public int continerSectionCount { get; }
    }

    [System.Serializable]
    public class LevelContiner
    {
        public List<Fruit> fruits => _fruits;

        public string name;

        [SerializeField]
        private List<Fruit> _fruits;
    }

    [System.Serializable]
    public class Fruit : IFruit
    {
        public fruitType fruitType => _fruitType;

        public GameObject fruitPrefab => _fruitPrefab;

        public string name;

        [SerializeField]
        private fruitType _fruitType;

        [SerializeField]
        private GameObject _fruitPrefab;
    }
}