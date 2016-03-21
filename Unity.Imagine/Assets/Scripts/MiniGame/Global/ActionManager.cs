﻿using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

    public Vector3 rotation { get; set; }

    public KeyCode keyCode { get; set; }

    public GameObject Enemy { get; set; }

    public bool isRendered { get; set; }

    public virtual void Action() { Debug.Log("仮想メソッドです。継承して使ってください。"); }

    const string MAIN_CAMERA_TAG_NAME = "MainCamera";

    Vector3 _offset = new Vector3(0.0f, 0.0f, -90.0f);

    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedを有効に 
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            isRendered = true;
        }
        //Debug.Log(isRendered);
    }

    public void Rotate()
    {
        gameObject.transform.eulerAngles = rotation + _offset;
    }
}
