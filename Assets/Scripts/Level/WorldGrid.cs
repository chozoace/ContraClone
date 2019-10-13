using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldGrid", menuName = "ScriptableObjects/WorldGrid", order = 2)]
public class WorldGrid : ScriptableObject
{
    private Partition[,] partitions;
    private float gridWidth;
    public float GridWidth { get { return gridWidth; } }
    private float gridHeight;
    public float GridHeight { get { return gridHeight; } }
    private float partitionWidth;
    public float PartitionWidth { get { return partitionWidth; } }
    private float partitionHeight;
    public float PartitionHeight { get { return partitionHeight; } }
    private Vector2 gridOffset;
    public Vector2 GridOffset { get { return gridOffset; } }


    private void OnEnable()
    {
        partitionHeight = (Camera.main.orthographicSize * 2) + .5f;
        partitionWidth = (Camera.main.orthographicSize * 2 * Camera.main.aspect) + .5f;
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

    public void AddToWorld(GameObject gameObject)
    {
        int cellX = (int)((gameObject.GetComponent<Rigidbody2D>().position.x - gridOffset.x) / partitionWidth);
        int cellY = (int)(((gameObject.GetComponent<Rigidbody2D>().position.y - gridOffset.y) * -1) / partitionHeight);
        partitions[cellX, cellY].Add(gameObject);
    }
    
    public void Move(GameObject gameObject, Vector2 oldPos)
    {
        //determine old cell
        int oldCellX = (int)((oldPos.x - gridOffset.x) / partitionWidth);
        int oldCellY = (int)(((oldPos.y - gridOffset.y) * -1) / partitionHeight);

        //find new cell
        int cellX = (int)((gameObject.GetComponent<Rigidbody2D>().position.x - gridOffset.x) / partitionWidth);
        int cellY = (int)(((gameObject.GetComponent<Rigidbody2D>().position.y - gridOffset.y) * -1) / partitionHeight);

        //if it didn't change cell, return
        if (oldCellX == cellX && oldCellY == cellY)
        {
            return;
        }

        partitions[oldCellX, oldCellY].Remove(gameObject);
        partitions[cellX, cellY].Add(gameObject);
    }

    public List<Partition> GetUpdatablePartitions(GameObject centerPoint)
    {
        int centerPartitionX = (int)((centerPoint.transform.position.x - gridOffset.x) / partitionWidth);
        int centerPartitionY = (int)(((centerPoint.transform.position.y - gridOffset.y) * -1) / partitionHeight);

        List<Partition> result = new List<Partition>();
        int xLength = partitions.GetLength(0);
        int yLength = partitions.GetLength(1);

        for(int x = centerPartitionX - 1; x <= centerPartitionX + 1; x++)
        {
            for (int y = centerPartitionY - 1; y <= centerPartitionY + 1; y++)
            {
                if (x >= 0 && x < partitions.GetLength(0) && y >= 0 && y < partitions.GetLength(1))
                {
                    result.Add(partitions[x, y]);
                }
            }
        }

        return result;
    }
}
