using Core.GameSession;
using Reflex.Attributes;
using System;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        [Inject] protected IGameProgress Progress;

        protected void OnUpdateData(int value)
        {
            _text.text = value.ToString();
        }
    }
}