using System;

namespace UI.Game.FMS
{
    public abstract class GameUIState
    {
        private IGameUI _view;

        public GameUIState(IGameUI view)
        {
            if(view == null)
                throw new ArgumentNullException(nameof(view));

            _view = view;
        }

        public void Open() => _view.Show();

        public void Close() => _view.Hide();
    }
}
