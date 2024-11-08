using GamePush;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private RawImage _avatar;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private Button _logIn;
    [SerializeField] private Button _logOut;

    private Coroutine _avatarLoading;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _logIn.onClick.AddListener(OnLogIn);
        _logOut.onClick.AddListener(OnLogOut);

        GP_Leaderboard.OnFetchPlayerRatingSuccess += OnFetchPlayerRatingSuccess;
        GP_Player.OnLoginComplete += OnLoginComplete;
        GP_Player.OnLoginError += OnLoginError;

        GP_Player.OnLogoutComplete += OnLoginComplete;
    }

    private void OnDisable()
    {
        _logIn.onClick.RemoveListener(OnLogIn);
        _logOut.onClick.RemoveListener(OnLogOut);

        GP_Leaderboard.OnFetchPlayerRatingSuccess -= OnFetchPlayerRatingSuccess;
        GP_Player.OnLoginComplete -= OnLoginComplete;
        GP_Player.OnLoginError -= OnLoginError;

        GP_Player.OnLogoutComplete -= OnLoginComplete;

        if (_avatarLoading != null)
        {
            StopCoroutine(_avatarLoading);
            _avatarLoading = null;
        }
    }

    private void Initialize()
    {
        _score.text = GP_Player.GetScore().ToString();

        string name = GP_Player.GetName();

        if (string.IsNullOrEmpty(name) == false)
            _name.text = name;

        if (GP_Player.IsLoggedIn())
        {
            _logIn.gameObject.SetActive(false);
            _logOut.gameObject.SetActive(true);
        }
        else
        {
            _logIn.gameObject.SetActive(true);
            _logOut.gameObject.SetActive(false);
        }

        FetchPlayerRating();

#if UNITY_WEBGL && !UNITY_EDITOR
        LoadAvatar();
#endif
    }

    private void LoadAvatar()
    {
        if (_avatarLoading == null)
            _avatarLoading = StartCoroutine(LoadingImage(GP_Player.GetAvatarUrl()));
    }

    private void OnLoginComplete()
    {
        Initialize();
    }

    private void OnLoginError()
    {
        Debug.Log("LogoutError");
    }

    private void FetchPlayerRating() => GP_Leaderboard.FetchPlayerRating();

    private void OnFetchPlayerRatingSuccess(string fetchTag, int position)
    {
        _rank.text = position.ToString();
    }

    private void OnLogIn()
    {
        GP_Player.Login();
    }
    private void OnLogOut()
    {
        GP_Player.Logout();
    }


    private IEnumerator LoadingImage(string imageUrl)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                _avatar.texture = texture;
            }
        }

        _avatarLoading = null;
    }
}
