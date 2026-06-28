using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        HandleInput();
    }
    
    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z=0;
            Vector2Int mouseCell=GridManager.Instance.GetCell(mouse);

            Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GridManager.Instance.isMouseinWorld(mouse))
            {
                SunManager.Instance.collectSun(mousePos);
                
                if (ShovelManager.Instance.IsUsingShovel())
                {
                    GridManager.Instance.ShovelTree(mouseCell);
                }
                else
                {
                    GridManager.Instance.PlantTree(mouseCell);
                }
            }
        }
    }
}
