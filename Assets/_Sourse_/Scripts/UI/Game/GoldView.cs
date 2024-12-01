namespace UI.Game
{
    public class GoldView : ResourcesView
    {
        private void OnEnable()
        {
            Progress.GetPlayerProgress().GoldChanged += OnUpdateData;
        }

        private void OnDisable()
        {
            Progress.GetPlayerProgress().GoldChanged -= OnUpdateData;
        }
    }
}
