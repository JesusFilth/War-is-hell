using UnityEngine;

public class GoldItem : MonoBehaviour
{
    [SerializeField] private int _count;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.AddGold(_count);
            Destroy(gameObject);
        }
    }
}
