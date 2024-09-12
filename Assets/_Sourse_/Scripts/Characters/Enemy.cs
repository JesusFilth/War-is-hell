using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> Died;

    public bool IsDead { get; private set; }

    public void Die()
    {
        IsDead = true;
        Died?.Invoke(this);
    }
}