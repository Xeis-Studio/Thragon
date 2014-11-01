using UnityEngine;
using System.Collections;

public class PopitScript : MonoBehaviour {

	public string gameobjectName;
	public GameObject spot;
	public int caloriesSelected;

	void Awake(){

	}

	IEnumerator animationCoorutine(){
		GameObject food = GameObject.Find(gameobjectName);

		GameObject ipa = food.gameObject.GetComponent<InformacionPorAlimento>().foodPrefab;
		Transform tmp = Instantiate(ipa, spot.transform.position, Quaternion.identity) as Transform; 
		yield return new WaitForSeconds(1.4f);
		Destroy(GameObject.Find(ipa.gameObject.name+"(Clone)"));
	}

	public void spawnFood(GameObject thragon){
		thragon.gameObject.GetComponent<EatingMovementScript>().executeEatingLoop(thragon);
		this.closePopit();
	}

	public void setFoodName(string name){
		gameobjectName = name;
		//Debug.Log("Name : "+gameobjectName);
	}

	public void openPopit(GameObject food){
		this.gameObject.SetActive(true);
	}

	public void closePopit(){

		this.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
