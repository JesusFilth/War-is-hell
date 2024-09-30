using GameCreator.Runtime.Characters;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAbilitys _ability;
    [SerializeField] private Character _character;
    [SerializeField] private bool _isDontDestroy = true;

    public Transform Transform { get; private set; }
    public PlayerProgress Progress { get; private set; } = new();
    public PlayerAbilitys Abilitys => _ability;

    private Coroutine _coroutine;
    private WaitForSeconds _waitStartPosition = new WaitForSeconds(1.0f);
    private WaitForSeconds _waitInterval = new WaitForSeconds(0.1f);

    private void Awake()
    {
        Transform = transform;

        if(_isDontDestroy)
            DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public void SetPosition(Vector3 position)
    {
        _character.Driver.SetPosition(position);

        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(StartingPosition(position));
        }
    }

    public void AddGold(int gold)
    {
        Progress.AddGold(gold);
    }

    public void AddExperience(float exp)//temp
    {
        Debug.Log("Add Exp");
    }

    private IEnumerator StartingPosition(Vector3 position)
    {
        yield return _waitStartPosition;
        _character.Driver.SetPosition(position);

        _coroutine = null;
    }
}