using UnityEngine;
using System.Collections;

public class FireplaceControl : MonoBehaviour {

	public float minIntensity = 1.1f; 
	public float maxIntensity = 2.3f;
	float myrandom;

	// Use this for initialization
	void Start () {
		myrandom = Random.Range(0.0f, 65535.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float noise = Mathf.PerlinNoise(myrandom, Time.time);
		this.gameObject.light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
	}
}
