using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	public GameObject selectedTower;

	// Use this for initialization
	void Start () {
	  Screen.SetResolution(1280, 1024, true);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

	public void SelectTowerType(GameObject prefab) {
		selectedTower = prefab;
	}
}
