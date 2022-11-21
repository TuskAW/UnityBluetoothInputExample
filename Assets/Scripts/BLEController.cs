using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class BLEController : MonoBehaviour
{
    GameObject dialog = null;
    // Start is called before the first frame update
    void Start()
    {
        if(!MLPermissions.CheckPermission(MLPermission.Bluetooth).IsOk)
        {
            MLPermissions.RequestPermission(MLPermission.Bluetooth);
            MLPermissions.RequestPermission(MLPermission.BluetoothAdmin);
            dialog = new GameObject();
        }
    }

    private void OnGUI()
    {
        if (!MLPermissions.CheckPermission(MLPermission.Bluetooth).IsOk)
        {
            dialog.AddComponent<PermissionsRationaleDialog>();
            return;
        }    
        else if (dialog != null)
        {
            Destroy(dialog);
        }
    }


    private void OnApplicationPause(bool pause)
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
