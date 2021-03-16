using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcGISMapsSDK.Components;

public class LocationRect : MonoBehaviour
{
    public string A;
    ArcGISRendererComponent arcGisRender;
    public GameObject axisObj;//
    public GameObject axisObj0;//
    public bool IsActive;
    public bool IsActive2;
    public bool IsActive3;
    public bool IsActive4;

    // Start is called before the first frame update
    void Start()
    {
        if (!arcGisRender)
            arcGisRender = GameObject.Find("RenderContainer").GetComponent<ArcGISRendererComponent>();
        axisObj = this.gameObject;

        if (axisObj0 == null && this.transform.parent.Find("axiGo") == null)
        {
            axisObj0 = new GameObject("axiGo");
            axisObj0.transform.parent = this.transform.parent;
            axisObj0.transform.localPosition = Vector3.zero;
            axisObj0.transform.localEulerAngles = this.transform.localEulerAngles;
        }
        if (this.transform.parent.Find("axiGo") != null)
        {
            axisObj0 = this.transform.parent.Find("axiGo").gameObject;
        }

        //Rec2();
    }


    public void Rec2()
    {
        axisObj0.transform.LookAt(CoordinateHelper._instance.northPoint);
        axisObj.transform.localEulerAngles = new Vector3(180, -180 + axisObj0.transform.localEulerAngles.y - 0.8f/*- 0.5f*/, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            float deltaAngle = Vector3.Angle(arcGisRender.transform.right, axisObj.transform.right);

            //北天东坐标系的0，0，0
            Vector3 angle_nue0 = Vector3.right * -deltaAngle;//heading  pitch

            //Debug.Log(angle_nue0.x);
            axisObj.transform.localEulerAngles = new Vector3(180, angle_nue0.x, 0);
        }
        if (IsActive2)
        {
            axisObj0.transform.LookAt(CoordinateHelper._instance.northPoint);
            //axisObj.transform.localEulerAngles = new Vector3(180, -180 + axisObj0.transform.localEulerAngles.y/* - 0.5f*/, 0);
            axisObj.transform.localEulerAngles =      new Vector3(axisObj.transform.localEulerAngles.x,  axisObj0.transform.localEulerAngles.y, axisObj.transform.localEulerAngles.z);
                //axisObj0.transform.localEulerAngles;


            //  new Vector3(180, -180 + axisObj0.transform.localEulerAngles.y, -180);
        }
        if (IsActive3)
        {
            axisObj0.transform.LookAt(CoordinateHelper._instance.northPoint);
            axisObj.transform.localEulerAngles = new Vector3(180, -180 + axisObj0.transform.localEulerAngles.y, 0);
        }
        if (IsActive4)
        {
            axisObj0.transform.LookAt(CoordinateHelper._instance.northPoint);
            axisObj.transform.localEulerAngles = new Vector3(180, -180 + axisObj0.transform.localEulerAngles.y - 0.8f, 0);
        }
    }







    private Vector3 GetBetweenPoint(Vector3 start, Vector3 end, float percent = 0.5f)
    {
        Vector3 normal = (end - start).normalized;
        float distance = Vector3.Distance(start, end);
        return normal * (distance * percent) + start;
    }
}
