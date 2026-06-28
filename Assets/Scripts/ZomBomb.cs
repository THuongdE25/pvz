using UnityEngine;

public class ZomBomb : Zombies
{
    [SerializeField] private GameObject Boom;
    protected override void Update()
    {
        if (getisAttacking())
        {
            Die();
        }
        base.Update();
    }
    public override void Die()
    {
        Vector2Int Cell=GridManager.Instance.GetCell(transform.position);
        Instantiate(Boom,GridManager.Instance.GetWorldPosition(Cell.x,Cell.y),Quaternion.identity);
        base.Die();
    }
}
