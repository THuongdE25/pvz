using UnityEngine;

public class ShovelManager : MonoBehaviour
{
    public static ShovelManager Instance;
    private bool isUsingShovel;
    [SerializeField] private Sprite shovel;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectShovel()
    {
        if (isUsingShovel)
        {
            isUsingShovel=false;
            CancelShovel();
            return;
        }
        isUsingShovel = true;
        PlantManager.Instance.ClearSelection();
        PreviewManager.Instance.setPreview(shovel);
    }

    public void CancelShovel()
    {
        isUsingShovel = false;
        PreviewManager.Instance.HidePreview();
    }

    public bool IsUsingShovel()
    {
        return isUsingShovel;
    }
}