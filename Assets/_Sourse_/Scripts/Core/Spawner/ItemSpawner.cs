using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Spawner
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private List<ItemSpawnModel> _itemModels;
        [SerializeField] private SpawnPoint[] _points;
        [SerializeField] private int _capasity;

        private Dictionary<Item, int> _items = new ();

        private void Start()
        {
            Initialize();
            Create();
        }

        private void Initialize()
        {
            float totalWeight = _itemModels.Sum(spawnModel => spawnModel.Weight);

            foreach (ItemSpawnModel spawnModel in _itemModels)
            {
                int count = (int)Mathf.Round(spawnModel.Weight / totalWeight * _capasity);

                _items.Add(spawnModel.Item, count);
            }
        }

        private void Create()
        {
            foreach (var item in _items)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    SpawnPoint freePoint = GetRandomFreePoint();
                    freePoint.ToBusy();
                    Item temp = Instantiate(item.Key, freePoint.Transform, false);
                }
            }
        }

        private SpawnPoint GetRandomFreePoint()
        {
            SpawnPoint[] freePoints = _points.Where(point => point.IsBusy == false).ToArray();

            if (freePoints == null || freePoints.Length == 0)
                throw new ArgumentNullException(nameof(freePoints));

            return freePoints[Random.Range(0, freePoints.Length)];
        }
    }
}
