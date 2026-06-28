using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private float damage=100f;
    private void Start()
    {
        Destroy(gameObject,0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            Plants plant=collision.GetComponent<Plants>();
            plant.TakeDamage(damage);
        }
    }
}
