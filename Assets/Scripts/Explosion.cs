using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 50f;
    public void Die()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            Zombies zombies=collision.GetComponent<Zombies>();
            zombies.TakeDamage(damage);
        }
    }
}
