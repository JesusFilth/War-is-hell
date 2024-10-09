using System.Collections;
using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

public class InjectPlayerTemp : MonoBehaviour
{
    private Player _player;

    public void On()
    {
        if (_player != null)
        {
            Debug.Log("Good");
        }
        else
        {
            Debug.Log("Bad");
        }
    }
}
