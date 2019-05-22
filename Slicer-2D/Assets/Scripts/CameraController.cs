using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    Camera cam;
    public GameObject panel;
    Image overlay;
    

    void Awake()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(SizeChange());
        overlay = panel.GetComponent<Image>();
    }


    IEnumerator SizeChange()
    {
        float t = 0;
        while(cam.orthographicSize<5)
        {
            //overlay.color = new Color(0, 0, 0, Mathf.Lerp(255, 0, t));
            cam.orthographicSize = Mathf.Lerp(2, 5, t);
            t += 2 * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
