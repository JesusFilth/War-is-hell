using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentifyApplication : MonoBehaviour
{
    [SerializeField] private MobileMovement _mobileMovement;
    [SerializeField] private DesktopMovement _desktopMovement;

    private void Awake()
    {
        if(Application.isMobilePlatform == true)
        {
            _mobileMovement.enabled = true;

            return;
        }

        _desktopMovement.enabled = true;
    }
}
