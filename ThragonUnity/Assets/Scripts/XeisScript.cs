using UnityEngine;
using System.Collections;

public class XeisScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(nextScene());
	}
	
	// Update is called once per frame

	IEnumerator nextScene()
	{
		yield return new WaitForSeconds(4f);
		Application.LoadLevel("start");
	}
}
