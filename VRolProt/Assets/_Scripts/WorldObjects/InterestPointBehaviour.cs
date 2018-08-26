using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPointBehaviour : MonoBehaviour {

	public Vector3 Position { get { return gameObject.transform.position; } }
    public string PointName { get; private set; }

    public static Dictionary<string, InterestPointBehaviour> ScenePoints = new Dictionary<string, InterestPointBehaviour>();

    public static void OnSceneLoading()
    {
        ScenePoints.Clear();
    }
	void Awake () {
        PointName = gameObject.name;
        ScenePoints.Add(PointName, this);
        Debug.Log("Añadido punto de interés " + PointName);
	}

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
