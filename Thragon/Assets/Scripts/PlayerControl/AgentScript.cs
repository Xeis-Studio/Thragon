using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	public Transform target;
	public bool canMove;
	NavMeshAgent agent;
	//float speed;
	private Animator anim;
	//private HashIDs hash;

	public Material femaleMaterial;
	public Material maleMaterial;

	public GameObject tragon;

	void Awake()
	{
		anim = GetComponent<Animator>();
		canMove = true;
	}

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();

		if(PersistenciaUsuario.getSexo() == Sexo.mujer)
		{
			tragon.renderer.material = femaleMaterial;
			Debug.Log("Mujer");
		}else{
			tragon.renderer.material = maleMaterial;
			Debug.Log("Hombre");
		}
		//hash = GetComponent<HashIDs>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!canMove){
			agent.Stop();
			return;
		}
		agent.SetDestination(target.position);
		//speed = agent.speed;

		//Debug.Log("Distance Remaining"+agent.remainingDistance);

		if(agent.remainingDistance <= 0)
		{
			//Debug.Log("Idle");
			anim.SetFloat("velocity",0.0f);
			anim.SetBool("isWalking",false);
		}else{
			//Debug.Log("Walk");
			anim.SetFloat("velocity",0.2f);
			anim.SetBool("isWalking",true);
		}
	}
}
