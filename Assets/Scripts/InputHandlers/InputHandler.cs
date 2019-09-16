using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler : ScriptableObject
{
    public abstract Action HandleInput();

}
