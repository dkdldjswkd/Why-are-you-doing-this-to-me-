using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics ControllerCharacteristics;
    private InputDevice targetDevice;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //A버튼
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
           //Debug.Log("A버튼눌림");
        }

        //검지 트리거 버튼
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
        {
            if (ControllerCharacteristics == InputDeviceCharacteristics.Right)
            {
                VRPlayerMove.Instance.goline();
               // Debug.Log("검지 트리거 눌림");
            }
        }
        else if(!(triggerValue > 0.1f) && ControllerCharacteristics == InputDeviceCharacteristics.Right)
        {
            VRPlayerMove.Instance.noline();
        }

        //쥐는 버튼
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool primarygripButton);
        if (primarygripButton)
        {

            //Debug.Log("그립");
        }

        //동그라미 움직이는버튼
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        if (primary2DAxisValue != Vector2.zero)
        {
            if (ControllerCharacteristics == InputDeviceCharacteristics.Left)
            {
                     VRPlayerMove.Instance.playermove(primary2DAxisValue.x, primary2DAxisValue.y);
                    // Debug.Log("조이스틱");
            }
        }
        else
        {
            VRPlayerMove.Instance.nomove();
        }
    }
}
