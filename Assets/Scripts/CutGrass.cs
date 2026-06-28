using UnityEngine;

public class CutGrass : MonoBehaviour
{
    [SerializeField] private float speed=2f;
    private bool isRunning=false;
    private Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (isRunning)
        {
            animator.SetBool("isRun",true);
            transform.Translate(Vector3.right*speed*Time.deltaTime);
        }
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombies"))
        {
            isRunning=true;
            Zombies zombies=collision.GetComponent<Zombies>();
            zombies.Die();
        }
    }
}
