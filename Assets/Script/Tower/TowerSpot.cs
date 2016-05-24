using UnityEngine;
using System.Collections;

public class TowerSpot : MonoBehaviour {
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(90f, 0, 0);
    }
	void OnMouseUp() {
		

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if(bm.selectedTower != null) {
			/*ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
			if(sm.money < bm.selectedTower.GetComponent<Tower>().cost) {
				Debug.Log("Not enough money!");
				return;
			}

			sm.money -= bm.selectedTower.GetComponent<Tower>().cost;
            */
			
			Instantiate(bm.selectedTower, transform.position, transform.rotation);
			Destroy(transform.gameObject);
         
                GameObject[] obj = GameObject.FindGameObjectsWithTag("DRAG");
                foreach (GameObject ob in obj)
                {

                    Destroy(ob);

                }
            
        }
	}
   
 
}
