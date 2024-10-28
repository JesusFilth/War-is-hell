using Reflex.Attributes;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    [Inject] private IGameProgress _progress;

    private void OnEnable()
    {
        _progress.GetPlayerProgress().ScoreChanged += UpdateData;
        _progress.GetPlayerProgress().UpdateScore();
    }

    private void OnDisable()
    {
        if (_progress.GetPlayerProgress() != null)
            _progress.GetPlayerProgress().ScoreChanged -= UpdateData;
    }

    private void UpdateData(int score)
    {
        _score.text = score.ToString();
    }
}
