using UnityEngine;

public class CellLayoutManager : MonoBehaviour
{
    [SerializeField]
    private int numberOfCells = 4;     // Number of cells

    [SerializeField]
    private float innerWidth = 10f;    // Inner width between two objects

    private float cellWidth;           // Width of each cell
    private float cellSpacing;         // Spacing between cells

    private void Start()
    {
        CalculateCellWidth();
        CalculateCellSpacing();
        PositionChildObjects();
    }

    private void CalculateCellWidth()
    {
        // Subtract the total cell spacing from the inner width
        float totalSpacing = (numberOfCells - 1) * cellSpacing;
        cellWidth = (innerWidth - totalSpacing) / numberOfCells;
    }

    private void CalculateCellSpacing()
    {
        // Divide the remaining space evenly between cells
        float remainingWidth = innerWidth - (cellWidth * numberOfCells);
        cellSpacing = remainingWidth / (numberOfCells - 1);
    }

    private void PositionChildObjects()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Calculate the x position based on cell index and cell width
            float xPos = i * (cellWidth + cellSpacing);

            // Set the local position of the child object
            Vector3 newPosition = new Vector3(xPos, 0f, 0f);
            child.localPosition = newPosition;
        }
    }
}
