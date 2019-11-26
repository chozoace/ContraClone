using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineObject : MonoBehaviour
{
    public static CoroutineObject instance;

    void Awake()
    {
        CoroutineObject.instance = this;
    }
}