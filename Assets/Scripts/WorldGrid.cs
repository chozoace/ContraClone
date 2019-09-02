using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid
{
    private Partition[,] partitions;
    private float gridWidth;
    private float partitionWidth;
    private float partitionHeight;

    //Orthographic size means how many units in world space the viewport half height is

    public void Start()
    {
        partitionHeight = Camera.main.orthographicSize * 2;
        partitionWidth = partitionHeight * Screen.width / Screen.height;
    }

    public void CreatePartitions()
    {

    }

}
