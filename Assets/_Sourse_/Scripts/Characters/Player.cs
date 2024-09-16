using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAbilitys _ability;
    [SerializeField] private bool _isDontDestroy = true;

    public Transform Transform { get; private set; }
    public PlayerAbilitys Abilitys => _ability;

    public PlayerProgress Progress { get; private set; } = new();

    private void Awake()
    {
        Transform = transform;
        Debug.Log("Awake");
        if(_isDontDestroy)
            DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}