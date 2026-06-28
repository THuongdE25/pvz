using UnityEngine;
public abstract class Zombies : MonoBehaviour
{
    [SerializeField] protected float maxhealth = 100f;
    [SerializeField] protected float currenthealth;
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float attackDamage = 10f;
    [SerializeField] protected float attackDelay = 1f;
    protected float nextAttack;
    protected bool isAttacking = false;
    [SerializeField] private GameObject Blood;
    protected virtual void Start()
    {
        currenthealth = maxhealth;
    }
    protected virtual void Update()
    {
        Move();
    }
    public virtual void TakeDamage(float damage)
    {
        currenthealth -= damage;
        if (currenthealth <= 0f)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Instantiate(Blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ZombiesManager.Instance.zombiesAlive--;
    }
    protected virtual void Move()
    {
        if(!isAttacking)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < -7)
        {
            GameManager.Instance.loseMenu();
        }
    }
    
    protected bool getisAttacking()
    {
        return isAttacking;
    }
    protected void setisAttacking(bool atk)
    {
        isAttacking=atk;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            Plants plants=collision.GetComponent<Plants>();
            if (Time.time > nextAttack)
            {
               plants.TakeDamage(attackDamage);
               nextAttack=Time.time+attackDelay;
            }
            setisAttacking(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Plants"))
        {
            setisAttacking(false);
        }
    }
}