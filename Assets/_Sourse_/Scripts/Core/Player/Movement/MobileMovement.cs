using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(Animator))]
public class MobileMovement : MonoBehaviour
{
    private const int LeftDirection = -90;
    private const int RightDirection = 90;
    private const string IsAttack = "IsAttack";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += Move;
    }

    private void OnDisable()
    {
        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= Move;
    }

    private void Move(Finger finger)
    {
        if (finger.screenPosition.x < (Screen.width / 2))
        {
            transform.localEulerAngles = new Vector3(0, LeftDirection, 0);
        }
        else if (finger.screenPosition.x > (Screen.width / 2))
        {
            transform.localEulerAngles = new Vector3(0, RightDirection, 0);
        }

        _animator.SetTrigger(IsAttack);
    }
}
