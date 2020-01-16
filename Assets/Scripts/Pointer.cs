using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class Pointer : MonoBehaviour
{

    private string path;
    public RawImage imageBig;
    public RawImage imageTab;
    public SteamVR_LaserPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {      
    }

    

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Explore")
        {
            path = EditorUtility.OpenFilePanel("title png", "", "png");
            if (path != null)
            {
                WWW www = new WWW($"file:///{path}");
                imageBig.texture = www.texture;
                imageTab.texture = www.texture;
            }
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        print("inside e.target.name:" + e.target.name);
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        print("outside e.target.name:" + e.target.name);
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        }
    }

}
