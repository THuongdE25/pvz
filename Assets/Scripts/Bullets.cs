using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField]private float damage = 20f;

    void Update()
    {
       Move(); 
    }
    public void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            Zombies zombies=collision.GetComponent<Zombies>();
            zombies.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
