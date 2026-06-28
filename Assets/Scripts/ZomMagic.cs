using UnityEngine;

public class ZomMagic : Zombies
{
    [SerializeField] private GameObject Zombies;
    [SerializeField] private float spawnDelay = 3f;
    private Vector2Int cell;
    private float nextSpawnTime;    
    protected override void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
        base.Start();
    }
    protected override void Update()
    {
        SpawnZombies();
        base.Update();
    }
    public void SpawnZombies()
    {
        cell = GridManager.Instance.GetCell(transform.position);
        if(Time.time >= nextSpawnTime)
        {
            if (!(cell.x + 1 > 4))
            {
             Instantiate(Zombies, GridManager.Instance.GetWorldPosition(cell.x+1, cell.y), Quaternion.identity);
             ZombiesManager.Instance.zombiesAlive++;
            }
            if (!(cell.x - 1 < 0))
            {
              Instantiate(Zombies, GridManager.Instance.GetWorldPosition(cell.x-1, cell.y), Quaternion.identity);
              ZombiesManager.Instance.zombiesAlive++;
            }
            
            Instantiate(Zombies, GridManager.Instance.GetWorldPosition(cell.x, cell.y+1), Quaternion.identity);
            Instantiate(Zombies, GridManager.Instance.GetWorldPosition(cell.x, cell.y-1), Quaternion.identity);
            ZombiesManager.Instance.zombiesAlive+=2;
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
