using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public GameObject firstPortal;
    Camera fCam1;
    Camera fCam2;
    public GameObject secondPortal;
    Camera sCam1;
    Camera sCam2;
    public Texture bluePortal;
    public Texture orangePortal;
    bool isFirst;


    public void SetPortal(GameObject portalInstance)
    {
        if (!isFirst)
        {
            if (firstPortal != null)
                Destroy(firstPortal);
            isFirst = true;
            firstPortal = portalInstance;
            fCam1 = firstPortal.transform.GetChild(0).GetComponent<Camera>();
            fCam2 = firstPortal.transform.GetChild(1).GetComponent<Camera>();
            portalInstance.gameObject.name = "FirstPortal";
            portalInstance.gameObject.tag = "FirstPortal";
            // portalInstance.GetComponent<Renderer>().material.mainTexture = bluePortal;
        }
        else
        {
            if (secondPortal != null)
                Destroy(secondPortal);
            isFirst = false;
            secondPortal = portalInstance;
            sCam1 = secondPortal.transform.GetChild(0).GetComponent<Camera>();
            sCam2 = secondPortal.transform.GetChild(1).GetComponent<Camera>();
            portalInstance.gameObject.name = "SecondPortal";
            portalInstance.gameObject.tag = "SecondPortal";
            // portalInstance.GetComponent<Renderer>().material.mainTexture = orangePortal;
        }
        portalInstance.GetComponent<BoxCollider>().enabled = true;
        portalInstance.GetComponent<BoxCollider>().isTrigger = true;
        SetPortalTextures();
    }

    void SetPortalTextures()
    {
        if (secondPortal != null)
        {
            if (fCam1)
                fCam1.enabled = true;
            if (fCam2)
                fCam2.enabled = false;
            if (sCam1)
                sCam1.enabled = false;
            if (sCam2)
                sCam2.enabled = true;
            firstPortal.GetComponent<Renderer>().material.mainTexture = secondPortal.transform.GetChild(1).GetComponent<Camera>().targetTexture;
            secondPortal.GetComponent<Renderer>().material.mainTexture = firstPortal.transform.GetChild(0).GetComponent<Camera>().targetTexture;
            // firstPortal.GetComponent<Renderer>().material.mainTexture = firstPortal.transform.GetChild(0).GetComponent<Camera>().targetTexture;
            // secondPortal.GetComponent<Renderer>().material.mainTexture = secondPortal.transform.GetChild(1).GetComponent<Camera>().targetTexture;
        }
    }
}
