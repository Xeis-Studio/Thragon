using UnityEngine;
using System.Collections;

public class SpinAnimation : MonoBehaviour {

	public float rotSpeed = 100;
	public bool isRunning;

	void Awake(){
		isRunning = false;
	}


	IEnumerator animationCoorutine(){
		if(!isRunning){
			isRunning = true;
			yield return new WaitForSeconds(8f);
			isRunning = false;
		}
	}

	// Use this for initialization
	void Start () {

	}

	public void StartAnimation(){
		StartCoroutine(animationCoorutine());
	}
	
	// Update is called once per frame
	void Update () {
		if(isRunning){
			transform.Rotate(rotSpeed*Time.deltaTime,0 , 0, Space.World);
		}
		else{
			return;
		}
	}
}
