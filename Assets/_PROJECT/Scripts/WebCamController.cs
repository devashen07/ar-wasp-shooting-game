using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WebCamController : MonoBehaviour
{
    #region VARIABLES
    public GameObject m_WebCameraPlane;
    public Button m_ShootButton;
    #endregion

    #region UNITY EVENTS
    public void Start()
    {
        // Setup camera position if on mobile 
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        // Enable gyroscope
        Input.gyro.enabled = true;

        m_ShootButton.onClick.AddListener(OnButtonDown);

        // Debugging
        WebCamTexture webCamTexture = new WebCamTexture();
        m_WebCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }

    public void Update()
    {
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = cameraRotation;
    }
    #endregion

    #region HELPER FUNCTIONS
    private void OnButtonDown()
    {
        GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
        Rigidbody rigidBody = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = Camera.main.transform.rotation;
        bullet.transform.position = Camera.main.transform.position;
        rigidBody.AddForce(Camera.main.transform.forward * 500f);
        Destroy(bullet, 3);

        GetComponent<AudioSource>().Play();
    }
    #endregion
}
