using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float sunValue=50f;
    [SerializeField] private float speed=7f;
    [SerializeField] private float desTime=5f;
    private bool collected=false;
    private Transform target;
    void Start()
    {
        target=SunManager.Instance.GetSunDesPos();

        if (!collected)
        {
            Destroy(gameObject,desTime);
        }
    }
    void Update()
    {
        if(collected)
        {
            Move();
        }
        
    }
    public void collectSun()
    {
        collected=true;
        SunManager.Instance.addSun(sunValue);

        Destroy(gameObject,2f);
    }
    public bool GetCollected()
    {
        return collected;
    }
    public void Move()
    { 
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }
}
