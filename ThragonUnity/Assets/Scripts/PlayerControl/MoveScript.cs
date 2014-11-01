using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed = 10.0f;
	GameObject player;
	RaycastHit hit;

	void Start()
	{
		player = GameObject.Find("target");
		hit = new RaycastHit(); 
	}
	// Update is called once per frame
	void Update () 
	{
		/*
		if(Input.touchCount == 0)
		{
			moveTouch();

		}else{

			moveMouse();
		}
		*/
		moveMouse();
	}

	void moveMouse()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (Input.GetMouseButtonDown(0)) {
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
				if (Physics.Raycast(ray, out hit, 1000.0f)) {
					Vector3 newpos = new Vector3(hit.point.x, 0.5f, hit.point.z);
					player.transform.position = newpos;
				}
			}
		}
	}
	
	void moveTouch()
	{
		for (int i = 0; i < Input.touches.Length; i++) {
			Touch touch = Input.GetTouch (i);
		
			Vector3 touchPos; touchPos.x=touch.position.x; touchPos.y=touch.position.y; touchPos.z=Camera.main.nearClipPlane;
			Vector3 currentLocation; currentLocation.x = transform.position.x; currentLocation.y = transform.position.y; currentLocation.z = Camera.main.nearClipPlane;
			Vector3 touchPos3D = Camera.main.WorldToScreenPoint(touchPos);
			Vector3 currentLocation3D = currentLocation;
			Vector3 forzeDir3D = touchPos3D-currentLocation3D; forzeDir3D.Normalize(); forzeDir3D*=speed;
			
			player.transform.position = forzeDir3D;
		}
	}
}
