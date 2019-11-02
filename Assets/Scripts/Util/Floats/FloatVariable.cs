using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    [NonSerialized]
    public float RuntimeValue;

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {

    }
}
