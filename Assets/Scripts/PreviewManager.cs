using UnityEngine;

public class PreviewManager : MonoBehaviour
{
    public static PreviewManager Instance;
    private PlantManager plants;
    private  ShovelManager shovel;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }

    void Update()
    {
        preview();
    }
    public void setPreview(Sprite sprite)
    {
        spriteRenderer.sprite=sprite;
        gameObject.SetActive(true);
    }
    public void HidePreview()
    {
        gameObject.SetActive(false);
    }
    public void preview()
    {
        if(!gameObject.activeSelf){
            return;
        }
        Vector3 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z=0;
        transform.position=mouse;
    }
}
