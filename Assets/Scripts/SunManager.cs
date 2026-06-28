using System;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance;
    public static Action onSunChanged;
    private float currentSun;
    public float startSun=100f;
    [SerializeField] private TextMeshProUGUI sunTxt;
    [SerializeField] private Transform sunDesPos;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        UpdateSunTxt();
    }
    public void UpdateSunTxt()
    {
        sunTxt.text=currentSun.ToString();
        onSunChanged?.Invoke();
    }
    public void addSun(float sun)
    {
      currentSun+=sun;
      UpdateSunTxt();  
    }
    public bool spendSun(float sun)
    {
        if (sun > currentSun)
        {
            return false;
        }
        currentSun-=sun;
        UpdateSunTxt();
        return true;
    }
    public Transform GetSunDesPos()
    {
        return sunDesPos.transform;
    }
    public float GetcurrentSun()
    {
        return currentSun;
    }
    public void SetCurrentSun(float sun)
    {
        currentSun=sun;
        UpdateSunTxt();
    }
    public void collectSun(Vector2 mouseCell)
    {
        RaycastHit2D hit=Physics2D.Raycast(mouseCell,Vector2.zero);
        if (hit.collider != null)
        {
            Sun sun=hit.collider.GetComponent<Sun>();
            if (sun != null)
            {
                if (!sun.GetCollected())
                {
                    sun.collectSun();
                } 
            }
        }
    }
}
