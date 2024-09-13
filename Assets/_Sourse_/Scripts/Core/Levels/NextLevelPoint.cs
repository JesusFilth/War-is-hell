using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelPoint : MonoBehaviour
{
    [Inject] LevelStorage _levelStorage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _levelStorage.ToNextRandomLevel();
        }
    }
}