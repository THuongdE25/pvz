using UnityEngine;

public class CherryBomb : Plants
{
    [SerializeField] private GameObject explosion;
    protected override void Start()
    {
        base.Start();
    }
    public override void Die()
    {
       Instantiate(explosion, transform.position, Quaternion.identity);
       base.Die();
    }
    
}
