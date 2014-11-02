using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public int isWalking;
	public int isRunning;
	public int isEating;
	public int velocity;

	void Awake()
	{
		isWalking = Animator.StringToHash("Base Layer.isWalking");
		isRunning = Animator.StringToHash("Base Layer.isRuning");
		isEating = Animator.StringToHash("Base Layer.isEating");
		velocity = Animator.StringToHash("Base Layer.Velocity");
	}
}
