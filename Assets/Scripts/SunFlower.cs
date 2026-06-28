using UnityEngine;

public class SunFlower : Plants
{
    [SerializeField] private GameObject sunPrefab;
    [SerializeField] private Transform sunPos;
    [SerializeField] private float TimeSpawn = 7f;
    private float nextSunSpawnTime;

    protected override void Start()
    {
        base.Start();
        nextSunSpawnTime = Time.time + TimeSpawn; 
    }
    void Update()
    {
        SpawnSun();
    }
    public void SpawnSun()
    {
        if(Time.time >= nextSunSpawnTime)
        {
            Instantiate(sunPrefab, sunPos.position, Quaternion.identity);
            nextSunSpawnTime = Time.time + TimeSpawn; 
        }
    }
}
