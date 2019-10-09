using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //needs to follow player until reach scene end
    [SerializeField]
    GameObject player;

    [SerializeField]
    //farthest distance x player can walk before camera follows
    float xDeadZone;
    [SerializeField]
    float yDeadZone;

    [SerializeField]
    WorldGrid worldGrid;

    private Camera camera;

    private Vector2 cameraSize;

    private void Start()
    {
        camera = Camera.main;
        cameraSize = new Vector2(camera.orthographicSize * 2 * camera.aspect, camera.orthographicSize * 2);
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player.transform.position.x > this.transform.position.x + xDeadZone &&
            (Mathf.Abs(this.transform.position.x - worldGrid.GridOffset.x)) + (cameraSize.x / 2) < worldGrid.GridWidth)
        {
            this.transform.position = new Vector3(player.transform.position.x - xDeadZone, this.transform.position.y, this.transform.position.z);
        }
        if (player.transform.position.x < this.transform.position.x - xDeadZone &&
            (Mathf.Abs(this.transform.position.x - worldGrid.GridOffset.x)) - (cameraSize.x / 2) > 0)
        {
            this.transform.position = new Vector3(player.transform.position.x + xDeadZone, this.transform.position.y, this.transform.position.z);
        }

        if (player.transform.position.y > this.transform.position.y + yDeadZone &&
            (Mathf.Abs(this.transform.position.y - worldGrid.GridOffset.y)) - (cameraSize.y / 2) > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y - yDeadZone, this.transform.position.z);
        }
        if (player.transform.position.y < this.transform.position.y - yDeadZone &&
            (Mathf.Abs(this.transform.position.y - worldGrid.GridOffset.y)) + (cameraSize.y / 2) < worldGrid.GridHeight)
        {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + yDeadZone, this.transform.position.z);
        }
    }

}
