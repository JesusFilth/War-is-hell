using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
