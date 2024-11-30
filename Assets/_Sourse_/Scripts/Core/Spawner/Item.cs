using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace Core.Spawner
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Actions _actions;

        protected void Destroy()
        {
            _actions?.Invoke();
            Destroy(gameObject);
        }
    }
}
