using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float xDeadZone;
    [SerializeField]
    float yDeadZone;

    [SerializeField]
    WorldGrid worldGrid;

    private Vector2 cameraSize;

    private void Start()
    {
        cameraSize = new Vector2(Camera.main.orthographicSize * 2 * Camera.main.aspect, Camera.main.orthographicSize * 2);
    }

    private void Update()
    {
        if (player != null)
        {
            FollowPlayer();
        }
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
