using System;
using UnityEngine;

namespace Core.Spawner
{
    [Serializable]
    public class ItemSpawnModel
    {
        [SerializeField] private Item _item;
        [SerializeField][Range(1, 100)] private float _weight = 50f;

        public Item Item => _item;
        public float Weight => _weight;
    }
}
