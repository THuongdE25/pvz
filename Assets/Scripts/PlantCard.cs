using UnityEngine;
using UnityEngine.UI;

public class PlantCard : MonoBehaviour
{
    [SerializeField]private GameObject plantPrefab;
    [SerializeField] private Image image;
    private float cost;

    void Awake()
    {
        cost=plantPrefab.GetComponent<Plants>().GetSunCost();
    }
    public void SelectPlant()
    {
        PlantManager.Instance.SelectPlant(plantPrefab, cost);
    }
    void Refresh()
    {
        if (SunManager.Instance.GetcurrentSun() >= cost)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.gray;
        }
    }
    private void OnEnable() {
        SunManager.onSunChanged+=Refresh;
        //Refresh();
    }
    private void OnDisable()
    {
        SunManager.onSunChanged-=Refresh;
    }
}