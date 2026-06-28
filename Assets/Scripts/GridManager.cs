using UnityEngine;


public class Cell
{
    public int row;
    public int col;
    public bool occupied;
    public GameObject plant;

    public Cell(int row, int col)
    {
        this.row = row;
        this.col = col;
        occupied = false;
        plant=null;
    }
}
public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private Transform topLeft;
    [SerializeField] private Transform bottomRight;
    private int rows=5,cols=9;
    private Cell[,] grid;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        GenerateGrid();
    }
    private void OnDrawGizmos()
    {
        if (topLeft == null || bottomRight == null  )//|| grid==null )
            return;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // if (grid[row, col].occupied)
                //     Gizmos.color = Color.green;
                // else
                     Gizmos.color = Color.red;

                Gizmos.DrawWireCube(GetWorldPosition(row, col),new Vector3(GetCellWidth(),GetCellHeight(),0));
            }
        }
    }
    private void GenerateGrid()
    {
        grid = new Cell[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                grid[row, col] = new Cell(row, col);
            }
        }
    }

    public Vector3 GetWorldPosition(int row, int col)
    {
        float cellWidth =
            (bottomRight.position.x - topLeft.position.x) / (cols - 1);

        float cellHeight =
            (topLeft.position.y - bottomRight.position.y) / (rows - 1);

        float x = topLeft.position.x + col * cellWidth;
        float y = topLeft.position.y - row * cellHeight;

        return new Vector3(x, y, 0);
    }
    public Cell GetGrid(int row,int col)
    {
        return grid[row,col];
    }
    public float GetCellWidth()
    {
        return (bottomRight.position.x - topLeft.position.x) / (cols - 1);
    }
    public float GetCellHeight()
    {
        return (topLeft.position.y - bottomRight.position.y) / (rows - 1);
    }
    public Vector2Int GetCell(Vector3 position)
    {
        int col = Mathf.RoundToInt((position.x - topLeft.position.x) / GetCellWidth());
        int row = Mathf.RoundToInt((topLeft.position.y - position.y) / GetCellHeight());
        
        return new Vector2Int(row, col);
    }
    public void removePlant(Vector3 pos)
    {
        Vector2Int cell=GetCell(pos);

        grid[cell.x,cell.y].occupied=false;
        grid[cell.x,cell.y].plant=null;
    }
    public bool isMouseinWorld(Vector3 mouse)
    {
        if (mouse.x < topLeft.transform.position.x || 
            mouse.y > topLeft.transform.position.y || 
            mouse.x > bottomRight.transform.position.x || 
            mouse.y < bottomRight.transform.position.y)
        {
            return false;
        }
        return true;
    }
    public void PlantTree(Vector2Int mouseCell)
    {
        GameObject plant=PlantManager.Instance.GetSelectedPlant();
        if (plant == null)
        {
            return;
        }
        if (!grid[mouseCell.x, mouseCell.y].occupied&&SunManager.Instance.spendSun(PlantManager.Instance.GetSelectedCost()))
        {
            GameObject newplant=Instantiate(plant,GetWorldPosition(mouseCell.x,mouseCell.y),Quaternion.identity);

            grid[mouseCell.x, mouseCell.y].occupied = true;
            grid[mouseCell.x, mouseCell.y].plant = newplant;

            PlantManager.Instance.ClearSelection();
        } 
    }
    public void ShovelTree(Vector2Int mouseCell)
    {
        if (grid[mouseCell.x, mouseCell.y].occupied)
        {
            GameObject plant = grid[mouseCell.x, mouseCell.y].plant;
            SunManager.Instance.addSun(plant.GetComponent<Plants>().GetSunCost() / 2);
            Vector3 mouse=Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Destroy(grid[mouseCell.x,mouseCell.y].plant);
            removePlant(mouse);
            ShovelManager.Instance.CancelShovel();
        }
    }
}
