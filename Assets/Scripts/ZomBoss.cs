using UnityEngine;

public class ZomBoss : Zombies
{
    [SerializeField] private GameObject miniZom;
    [SerializeField] private GameObject bomb;
    private Vector2Int cell;
    private bool isSkill=false;
    protected override void Update()
    {
        if (!isSkill&& currenthealth <= maxhealth / 2)
        {
            Skill();
        }
        base.Update();
    }
    public void Skill()
    {
        cell=GridManager.Instance.GetCell(transform.position);
        if (currenthealth <= maxhealth / 2)
        {
            if (cell.y - 2 > 0)
            {
                Instantiate(miniZom,GridManager.Instance.GetWorldPosition(cell.x,cell.y-2),Quaternion.identity);
            }
            else
            {
                Instantiate(miniZom,GridManager.Instance.GetWorldPosition(cell.x,0),Quaternion.identity);
            }
            ZombiesManager.Instance.zombiesAlive++;
            isSkill=true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            Vector2Int zomCell= GridManager.Instance.GetCell(transform.position);
            if (Time.time > nextAttack)
            {
               Instantiate(bomb,GridManager.Instance.GetWorldPosition(zomCell.x,zomCell.y),Quaternion.identity);
               nextAttack=Time.time+attackDelay;
            }
            setisAttacking(true);
        }
    }
}
