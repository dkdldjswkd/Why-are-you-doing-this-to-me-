using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class test : MonoBehaviour
{
    private VRMBlendShapeProxy proxy;

    void Start()
    {
    }
    void Update()
    {
        var proxy = GetComponent<VRMBlendShapeProxy>();
        proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Joy), 0.6f);
        proxy.Apply();
    }

}
