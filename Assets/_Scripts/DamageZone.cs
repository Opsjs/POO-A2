using NaughtyAttributes;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField, Tag] string _playerTag;
    [SerializeField, Required] EntityHealth _health;
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //if (other.CompareTag(_playerTag))
        //{
        //    Debug.Log("Collision with player");
            //if (other.TryGetComponent<EntityHealth>(out EntityHealth _entityHealth))
            //{
                Debug.Log("Contact with player");
                _health.StartTakeDamage(damage);
            //}
        //}
    }
}
