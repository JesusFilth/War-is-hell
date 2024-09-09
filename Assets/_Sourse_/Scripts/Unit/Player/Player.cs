using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }
}