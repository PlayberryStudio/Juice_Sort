using GamePlay;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    [CreateAssetMenu(fileName = "NewLevelConfig", menuName = "Level/Level Object", order = 0)]
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        public List<LevelContiner> continers => _continers;

        public int levelIndex => _levelIndex;

        public int continerSectionCount => 5;

        [SerializeField]
        private List<LevelContiner> _continers;

        [SerializeField]
        private int _levelIndex;
    }
}