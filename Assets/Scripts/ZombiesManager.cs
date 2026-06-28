using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public enum ZombieType
{
    Normal, Hat1, Hat2, Fly, Magic, Mini, Bomb, Boss
}
[System.Serializable] public class ZombieSpawn
{
    public ZombieType type;
    public int amount;
}
[System.Serializable] public class Wave
{
    public ZombieSpawn[] zombieSpawns;
    public float spawnDelay=1f;
    public float waveDelay=2f;
}
public class ZombiesManager : MonoBehaviour
{
    public static ZombiesManager Instance;
    [SerializeField] private GameObject[] ZombiePrefabs;
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private Wave[] waves;
    private Coroutine spawn;
    public int zombiesAlive=0;
    public bool wavefinished=false;
    private void Awake() {
        Instance=this;
    }
    void Start()
    {
        spawn=StartCoroutine(spawnWave());
    }
    void Update()
    {
        if (zombiesAlive == 0&&wavefinished)
        {
            GameManager.Instance.winMenu();
            wavefinished=false;
        }
    }
    public void spawnZombie(ZombieType type)
    {
        int row=Random.Range(0,spawnPos.Length);
        Instantiate(ZombiePrefabs[(int)type],spawnPos[row].position,Quaternion.identity);
        zombiesAlive++;
    }
    IEnumerator spawninWave(Wave wave)
    {
        foreach (ZombieSpawn zombie in wave.zombieSpawns)
        {
         for(int i = 0; i < zombie.amount; i++)
            {
                yield return new WaitForSeconds(wave.spawnDelay);
                spawnZombie(zombie.type);
            }   
        }
    }
    IEnumerator spawnWave()
    {
        foreach (Wave wave in waves)
        {
            yield return StartCoroutine(spawninWave(wave));
            yield return new WaitForSeconds(wave.waveDelay);
        }
        wavefinished=true;
    }
    public void restartSpawn()
    {
        zombiesAlive=0;
        wavefinished=false;
        StopAllCoroutines();
        spawn=StartCoroutine(spawnWave());
    }
}
