using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    private GameObject selectedPlant;
    private float selectedCost;

    private void Awake()
    {
        Instance = this;
    }
    public void SelectPlant(GameObject plant, float cost)
    {   if (selectedPlant == plant)
        {
            ClearSelection();
            return;
        }
        if (cost > SunManager.Instance.GetcurrentSun())
        {
            ClearSelection();
            return;
        }
        selectedPlant = plant;
        selectedCost = cost;
        ShovelManager.Instance.CancelShovel();
        PreviewManager.Instance.setPreview(plant.GetComponent<SpriteRenderer>().sprite);
    }

    public GameObject GetSelectedPlant()
    {
        return selectedPlant;
    }

    public float GetSelectedCost()
    {
        return selectedCost;
    }

    public void ClearSelection()
    {
        selectedPlant = null;
        selectedCost=0;
        PreviewManager.Instance.HidePreview();
    }
}