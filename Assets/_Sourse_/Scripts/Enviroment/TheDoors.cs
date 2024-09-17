using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoors : MonoBehaviour
{
    [SerializeField] private Door[] _doors;

    [Inject] private SkillStorage _skillStorage;

    private void Awake()
    {
        if (DIGameConteiner.Instance != null)
            DIGameConteiner.Instance.InjectRecursive(gameObject);
    }
}
