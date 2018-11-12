using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateElements : MonoBehaviour {

    public GameObject prefab;
    private Vector3 spawnCoords = Vector3.zero;
    public GameObject player;
    private const float planeLength = 50.0f;

    private List<GameObject> planes = new List<GameObject>();

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if((player.transform.position.x + planeLength) > spawnCoords.x) {
            spawnCoords.x += planeLength;
            GameObject go = Instantiate(prefab, spawnCoords, Quaternion.identity, gameObject.transform) as GameObject;
            planes.Add(go);
        }

        if(planes[0].transform.position.x < (player.transform.position.x - planeLength)) {
            Destroy(planes[0]);
            planes.RemoveAt(0);
        }
	}
}
