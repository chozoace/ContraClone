using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partition
{
    private List<GameObject> gameObjectList = new List<GameObject>();

    public void Add(GameObject gameObject)
    {
        if (!gameObjectList.Contains(gameObject))
        {
            gameObjectList.Add(gameObject);
        }
    }

    public void Remove(GameObject gameObject)
    {
        if (gameObjectList.Contains(gameObject))
        {
            gameObjectList.Remove(gameObject);
        }
    }
}
