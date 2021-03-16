using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcGISMapsSDK.Components;

public class CoordinateHelper : MonoBehaviour
{
    public static CoordinateHelper _instance;
    public ArcGISRendererComponent arcGisRender;

    private void Awake()
    {
        _instance = this;
    }





    private void Start()
    {

    }

    public Vector3 EarthCenterPoint;
    public Vector3 northPoint;
    public Vector3 northDir;
    public Vector3 EastDir;

    //设置北极点 center
    void SetArcGisModelCenter()
    {
        double CAH = Camera.main.transform.GetComponent<ArcGISCameraComponent>().Height;
        EarthCenterPoint = Vector3.down * (6378137f + (float)CAH);
        northPoint = arcGisRender.ArcGISPointConvertToUnityPoint(0, 90, 0);
        //Vector3 EastPoint = arcGisRender.ArcGISPointConvertToUnityPoint(0, 0, 0);
        northDir = (northPoint - EarthCenterPoint).normalized;
        //EastDir = (EastPoint - EarthCenterPoint).normalized;

        //Debug.Log("地心位置:" + EarthCenterPoint);
        //Debug.Log("北极点:"+ northPoint);
        //Debug.Log("北极朝向"+ northDir);
    }


    #region  扩展方法  放到  ArcGISRendererComponent
    //public Vector3 ArcGISPointConvertToUnityPoint(double lng, double lat, double alt)
    //{
    //    var pos = RendererScene.ToGameEngineCoord(localRotation, localOrigin, new ArcGISGlobalCoordinatesPosition(lat, lng, alt));
    //    return pos.ToVector3();
    //}

    //public Quaternion ArcGISQuaternionConvertToUnityQuaternion(double lng, double lat, double alt, double heading, double pitch, double roll)
    //{
    //    var rotation = RendererScene.ToGameEngineRotation(localOrigin, new ArcGISGlobalCoordinatesPosition(lat, lng, alt),
    //                                                            new ArcGISRotation(pitch, roll, heading));
    //    return rotation.ToQuaternion();
    //}
    #endregion


    // Update is called once per frame
    void Update()
    {
        if (!arcGisRender)
        {
            if (GameObject.Find("RenderContainer") != null)
            {
                arcGisRender = GameObject.Find("RenderContainer").GetComponent<ArcGISRendererComponent>();
            }
        }
        SetArcGisModelCenter();
    }
}
