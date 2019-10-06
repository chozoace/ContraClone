using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldGrid", menuName = "ScriptableObjects/WorldGrid", order = 2)]
public class WorldGrid : ScriptableObject
{
    private Partition[,] partitions;
    private float gridWidth;
    private float gridHeight;
    private float partitionWidth;
    private float partitionHeight;
    private Vector2 gridOffset;

    private void OnEnable()
    {
        partitionHeight =(Camera.main.orthographicSize * 2) + 1;
        partitionWidth = (Camera.main.orthographicSize * 2 * Camera.main.aspect) + 1;
    }

    public void CreateGrid(Vector2 topLeftCorner, Vector2 bottomRightCorner)
    {
        gridOffset = topLeftCorner;
        gridWidth = Mathf.Abs(bottomRightCorner.x - topLeftCorner.x);
        gridHeight = Mathf.Abs(bottomRightCorner.y - topLeftCorner.y);

        partitions = new Partition[(int)Mathf.Ceil(gridWidth / partitionWidth),
            (int)Mathf.Ceil(gridHeight / partitionHeight)];

        for (int i = 0; i < partitions.GetLength(0); i++)
        {
            for(int j = 0; j < partitions.GetLength(1); j++)
            {
                partitions[i, j] = new Partition();
            }
        }        
    }
    
    public void Move(GameObject gameObject, Vector2 oldPos)
    {

    }
}
