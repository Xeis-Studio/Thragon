using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Despensa : ScriptableObject {

	public List<Alimento> alimentos;
	public int lastId;

}
