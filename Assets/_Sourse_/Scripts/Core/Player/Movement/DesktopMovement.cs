using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DesktopMovement : MonoBehaviour
{
    private const int LeftDirection = -90;
    private const int RightDirection = 90;
    private const string IsAttack = "IsAttack";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, LeftDirection, 0);
            _animator.SetTrigger(IsAttack);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, RightDirection, 0);
            _animator.SetTrigger(IsAttack);
        }

        transform.position = new Vector3(0, 0, 0);
    }
}
