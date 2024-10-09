using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool IsBusy { get; protected set; } = false;
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    public void ToBusy() => IsBusy = true;

    public void ToFree() => IsBusy = false;
}
