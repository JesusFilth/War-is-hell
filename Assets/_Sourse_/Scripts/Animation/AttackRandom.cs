using UnityEngine;

public class AttackRandom : StateMachineBehaviour
{
    private const string AttackId = "AttackId";

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger(AttackId, Random.Range(0, 2));
    }
}
