using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Sourse.Scripts.SDK
{
    public class LeaderboadElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _rank;
        [SerializeField] private TMP_Text _playerName;
        [SerializeField] private TMP_Text _playerScore;
        [SerializeField] private RawImage _icon;

        private Coroutine _avatarLoading;

        private void OnEnable()
        {
            try
            {
                Validate();
            }
            catch (ArgumentNullException ex)
            {
                enabled = false;
                throw ex;
            }
        }

        private void OnDisable()
        {
            if (_avatarLoading != null)
            {
                StopCoroutine(_avatarLoading);
                _avatarLoading = null;
            }
        }

        public void Init(string rank, string name, string score, string avatar)
        {
            _rank.text = rank;
            _playerName.text = name;
            _playerScore.text = score;

            if (_avatarLoading == null)
                _avatarLoading = StartCoroutine(LoadingImage(avatar));
        }

        private IEnumerator LoadingImage(string imageUrl)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    _icon.texture = texture;
                }
            }

            _avatarLoading = null;
        }

        private void Validate()
        {
            if (_rank == null)
                throw new ArgumentNullException(nameof(_rank));

            if (_playerName == null)
                throw new ArgumentNullException(nameof(_playerName));

            if (_playerScore == null)
                throw new ArgumentNullException(nameof(_playerScore));
        }
    }
}
