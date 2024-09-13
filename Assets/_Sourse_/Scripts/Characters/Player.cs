using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAbilitys _ability;

    public Transform Transform { get; private set; }
    public PlayerAbilitys Abilitys => _ability;

    private void Awake()
    {
        Transform = transform;
        DontDestroyOnLoad(gameObject);
    }
}