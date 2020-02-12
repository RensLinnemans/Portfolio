using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColls : MonoBehaviour
{
    public float minDis = 1f;
    public float maxDis = 4f;
    public float smooth = 5f;
    public float dis;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjust;

    void Awake()
    {
        //Just gets and sets the cam position
        dollyDir = transform.localPosition.normalized;
        dis = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDis);
        RaycastHit hit;
        if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit))
        {
            dis = Mathf.Clamp((hit.distance* 0.8f), minDis, maxDis);
        }
        else
        {
            dis = maxDis;
        }
        //vector3.lerp Hard t oexplain but basically finds a mid point when needed (https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html)
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * dis, Time.deltaTime * smooth);
        Debug.DrawLine(transform.parent.position, desiredCameraPos, Color.green, 2f);
    }
}
