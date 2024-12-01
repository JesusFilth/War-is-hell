namespace UI.Game
{
    public class ScoreView : ResourcesView
    {
        private void OnEnable()
        {
            Progress.GetPlayerProgress().ScoreChanged += OnUpdateData;
        }

        private void OnDisable()
        {
            Progress.GetPlayerProgress().ScoreChanged -= OnUpdateData;
        }
    }
}