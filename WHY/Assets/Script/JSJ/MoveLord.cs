using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class MoveLord : MonoBehaviour
{
    private VRMBlendShapeProxy proxy;

    float o = 0.0f;
    bool up = true;
    void Update()
    {
        var proxy = GetComponent<VRMBlendShapeProxy>();
        if (TextUI.Instance.gettexttime() == 3)
        {
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Joy), 0.7f);
        }
        else if (TextUI.Instance.gettexttime() == 4)
        {
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Joy), 0.0f);
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Angry), 0.6f);
            if (up)
            {
                proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.O), o);
                o += 0.01f;
                if(o >= 0.5f)
                {
                    up = false;
                }
            }
            else
            {
                proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.O), o);
                o -= 0.01f;
                if (o <= 0.0f)
                {
                    up = true;
                }
            }
        }
        else if (TextUI.Instance.gettexttime() == 5)
        {
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Angry), 0);
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.O), 0);
        }
        else if (TextUI.Instance.gettexttime() == 6)
        {
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Angry), 0);
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.O), 0);
            proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(BlendShapePreset.Sorrow), 1.0f);
        }
        proxy.Apply();
    }
}
