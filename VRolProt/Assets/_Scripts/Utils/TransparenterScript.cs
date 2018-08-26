using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparenterScript : MonoBehaviour {
    GameObject currentTransparent;
    Material transparentMat;
    Material oldMaterial;
	// Use this for initialization
	void Start () {
        transparentMat = new Material(Shader.Find("Transparent/Diffuse"));
        transparentMat.color = new Color(0.8f, 0.8f, 0.8f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        var camPos = GlobalConfig.MainCamera.transform.position;
        var ray = new Ray(camPos, transform.position - camPos);
        var distance = Vector3.Distance(camPos, transform.position);

        if (Physics.Raycast(ray, out hit, distance))
        {
            var obj = hit.collider.gameObject;
            if (obj == currentTransparent)
                return;
            Detransparence();
            Transparence(obj);
        }
        else
            Detransparence();
	}

    private void Transparence(GameObject obj)
    {
        currentTransparent = obj;
        oldMaterial = currentTransparent.GetComponent<MeshRenderer>().material;
        currentTransparent.GetComponent<MeshRenderer>().material = transparentMat;
    }

    private void Detransparence()
    {
        if (currentTransparent == null)
            return;
        currentTransparent.GetComponent<MeshRenderer>().material = oldMaterial;
        currentTransparent = null;
    }
}
