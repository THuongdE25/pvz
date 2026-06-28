using UnityEngine;

public abstract class Plants : MonoBehaviour
{   
    [SerializeField] protected float maxhealth = 100f;
    [SerializeField]protected float currenthealth;
    protected int rows,cols;
    [SerializeField]protected float suncost=100;
    protected virtual void Start()
    {
        currenthealth = maxhealth;
        
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
        GridManager.Instance.removePlant(transform.position);
        Destroy(gameObject);
    }
    public int getRow()
    {
        return rows;
    }
    public int getCol()
    {
        return cols;
    }
    public float GetSunCost()
    {
        return suncost;
    }
}
