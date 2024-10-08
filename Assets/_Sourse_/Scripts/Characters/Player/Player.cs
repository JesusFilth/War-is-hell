using GameCreator.Runtime.Characters;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float DelayPlayerPosition = 1f;

    [SerializeField] private PlayerAbilitys _ability;
    [SerializeField] private Character _character;
    [SerializeField] private bool _isDontDestroy = true;

    public Transform Transform { get; private set; }
    public PlayerProgress Progress { get; private set; } = new();
    public PlayerAbilitys Abilitys => _ability;

    private Coroutine _positionStarting;
    private WaitForSeconds _waitStartPosition = new WaitForSeconds(DelayPlayerPosition);

    private void Awake()
    {
        DIGameConteiner.Instance.InjectRecursive(gameObject);

        Transform = transform;

        if(_isDontDestroy)
            DontDestroyOnLoad(gameObject);
    }

    private void OnDisable()
    {
        if (_positionStarting != null)
        {
            StopCoroutine(_positionStarting);
            _positionStarting = null;
        }
    }

    public void SetPosition(Vector3 position)
    {
        _character.Driver.SetPosition(position);

        if(_positionStarting == null)
        {
            _positionStarting = StartCoroutine(StartingPosition(position));
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

        _positionStarting = null;
    }

    public void AddSkill_TEST(Skill skill)//temp
    {
        skill.ExecuteStratigy(Abilitys);
    }
}