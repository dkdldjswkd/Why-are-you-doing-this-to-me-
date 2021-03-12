using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviourPunCallbacks
{
    public float turnSmooth;
    private PhotonView PV;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffest;

    void Start()
    {
        PV = photonView;
        headBodyOffest = transform.position - headConstraint.position;
    }

    void LateUpdate()
    {
        if (PV.IsMine)
        {
            transform.position = headConstraint.position + headBodyOffest;
            transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmooth);
            head.Map();
            leftHand.Map();
            rightHand.Map();
            //PV.RPC("Test", RpcTarget.All);
        }
    }

    [PunRPC]
    void Test()
    {
        transform.position = headConstraint.position + headBodyOffest;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmooth);
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
