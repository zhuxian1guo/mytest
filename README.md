
# mytest
   Scripts LocationRect  enable -->   IsActive2   enable ---> Model AutoRec  
    1.Installing the Arcgis SDK  
    2.		Note: Currentsky (hdrp)  
    3.    	ArcGisRenrderComponents.cs  add the code:  
    	 public Vector3 ArcGISPointConvertToUnityPoint(double lng, double lat, double alt)  
		{  
			var pos = RendererScene.ToGameEngineCoord(localRotation, localOrigin, new ArcGISGlobalCoordinatesPosition(lat, lng, alt));  
			return pos.ToVector3();  
		}  
  
		public Quaternion ArcGISQuaternionConvertToUnityQuaternion(double lng, double lat, double alt, double heading, double pitch, double roll)  
		{  
			var rotation = RendererScene.ToGameEngineRotation(localOrigin, new ArcGISGlobalCoordinatesPosition(lat, lng, alt),  
																	new ArcGISRotation(pitch, roll, heading));  
			return rotation.ToQuaternion();  
		}  
    
    4. run PrefabScene.sence  
    
    
    
