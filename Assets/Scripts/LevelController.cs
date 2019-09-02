using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    //This controller will change according to scene
    //This is really more of a scene controller
    private WorldGrid worldGrid;
    private float sceneWidth;
    private float sceneHeight;

    //Use scene specific data to create the world grid
    //level controller only updates active partitions
    //Game state, Pause state, menu state. Each will have it's own controller.
    //A controller for every state
    //https://www.habrador.com/tutorials/programming-patterns/19-spatial-partition-pattern/
    public void Start()
    {
        sceneWidth = GameObject.FindGameObjectWithTag("LevelEnd").transform.position.x;
    }

    public void CreateWorld()
    {

    }

}
