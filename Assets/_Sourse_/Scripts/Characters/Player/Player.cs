using GameCreator.Runtime.Characters;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour,
    IGamePlayer,
    IGameProgress,
    IPlayerAbilities
{
    private const float DelayPlayerPosition = 1f;

    [SerializeField] private PlayerAbilitys _ability;
    [SerializeField] private Character _character;

    public Transform Transform { get; private set; }
    public PlayerProgress Progress { get; private set; } = new();
    public PlayerAbilitys Abilitys => _ability;

    private Coroutine _positionStarting;
    private WaitForSeconds _waitStartPosition = new WaitForSeconds(DelayPlayerPosition);

    private void Awake()
    {
        Transform = transform;
    }

    private void OnDisable()
    {
        if (_positionStarting != null)
        {
            StopCoroutine(_positionStarting);
            _positionStarting = null;
        }
    }

    public Transform GetPlayerPosition()
    {
        return Transform;
    }

    public void AddExpirience(float exp)//??
    {
        Debug.Log("Add Exp");
    }

    public void Resurrect()
    {
        Abilitys.Resurrect();
    }

    public PlayerProgress GetPlayerProgress()
    {
        return Progress;
    }

    public PlayerAbilitys GetAbilities()
    {
        return Abilitys;
    }

    public void SetPosition(Vector3 position)
    {
        if(_positionStarting == null)
            _positionStarting = StartCoroutine(StartingPosition(position));
    }

    public void AddGold(int gold)
    {
        Progress.AddGold(gold);
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