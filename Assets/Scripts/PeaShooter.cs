using UnityEngine;

public class PeaShooter : Plants
{   
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePos;
    [SerializeField] private float shootInterval = 2f;
    private float nextShootTime;

    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        if(Time.time >= nextShootTime)
        {
            if (canShoot())
            {
            Instantiate(bulletPrefab, FirePos.position, Quaternion.identity);
            nextShootTime = Time.time + shootInterval;
            }
        }
    }
    public bool canShoot()
    {
        Vector2Int mycell=GridManager.Instance.GetCell(transform.position);
        Zombies[] zombies=FindObjectsByType<Zombies>(FindObjectsSortMode.None);
        foreach(Zombies zom in zombies)
        {
            Vector2Int zomcell=GridManager.Instance.GetCell(zom.transform.position);

            if (zomcell.x == mycell.x && zomcell.y >= mycell.y)
            {
                return true;
            }
        }
        return false;
    }
}
