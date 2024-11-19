using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace Sourse.Scripts.Core.Spawner
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Actions _actions;

        protected virtual void Destroy()
        {
            _actions?.Invoke();
            Destroy(gameObject);
        }
    }
}
