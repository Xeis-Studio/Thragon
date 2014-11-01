using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorAlacena : EditorWindow {

	static private Despensa despensa;

	Vector2 scrollPosition;
	int posicionSeleccionada;
	Alimento alimentoSeleccionado;
	int id = 0;
	//int tmpId = 0;
	string nombre = "";
	string tmpNombre = "";
	string grupo;
	string tmpGrupo;
	string descripcion = "";
	string tmpDescripcion = "";
	float calorias = 0;
	//string tmpCalorias = "";
	//float parseCalorias = 0;
	GameObject prefab = null;

	bool creando = false;
	bool verDescripcion = false;
	bool editando = false;
	bool verAlerta = false;

	//Rect alertRect = new Rect(10,300,290,100);

	[MenuItem("Thragon/Alacena/Crear")]
	public static void crearAlacena(){
		Despensa asset = ScriptableObject.CreateInstance<Despensa>();
		asset.alimentos = new List<Alimento>();
		AssetDatabase.CreateAsset(asset,"Assets/AlacenaDatabase.asset");
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}

	[MenuItem("Thragon/Alacena/Editor")]
	static void init(){
		EditorAlacena ventana = (EditorAlacena)EditorWindow.GetWindow(typeof (EditorAlacena));
		ventana.minSize = new Vector2(600,400);
		ventana.maxSize = new Vector2(600,400);
		ventana.creando = false;
		ventana.verDescripcion = false;
		ventana.editando = false;
		ventana.verAlerta = false;
		
	}

	void OnGUI (){
		if(despensa == null){
			despensa = (Despensa)AssetDatabase.LoadAssetAtPath("Assets/AlacenaDatabase.asset",typeof(Despensa));
		}

		//---panel izquierdo
		GUILayout.BeginArea(new Rect(10,10,290,380),"Lista");
		GUILayout.Space(15);
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);
		for(int i = 0; i < despensa.alimentos.Count; i++){
			if(GUILayout.Button(despensa.alimentos[i].nombre)){
				posicionSeleccionada = i;
				alimentoSeleccionado = despensa.alimentos[i];
				editando = false;
				verDescripcion = true;
				//editando = true;
			}
		}
		GUILayout.EndScrollView();
		if(GUILayout.Button("Nuevo")){
			tmpNombre = "";
			tmpDescripcion = "";
			tmpGrupo = "";
			calorias = 0;
			prefab = null;
			creando = true;
		}
		if(verAlerta){
			alertDelete();
		}else{
			if(GUILayout.Button("Vaciar")){
				verAlerta = true;
			}
		}
		GUILayout.EndArea();


		//panel derecho
		GUILayout.BeginArea(new Rect(310,10,280,380),"Descripcion");
		GUILayout.Space(15);

		if(creando){
			guiCreando();
		} else if(verDescripcion){
			guiDescripcion();
		} else if(editando){
			guiEdicion();
		}
		GUILayout.EndArea();
	}

	private void guiCreando(){
		//nombre
		GUILayout.BeginHorizontal();
		GUILayout.Label("nombre: ");
		tmpNombre = GUILayout.TextField(tmpNombre);
		GUILayout.EndHorizontal();
		//descripcion
		GUILayout.BeginHorizontal();
		GUILayout.Label("descripcion: ");
		tmpDescripcion = GUILayout.TextField(tmpDescripcion);
		GUILayout.EndHorizontal();
		//grupo
		GUILayout.BeginHorizontal();
		GUILayout.Label("grupo: ");
		tmpGrupo = GUILayout.TextField(tmpGrupo);
		GUILayout.EndHorizontal();
		//calorias
		calorias = EditorGUILayout.FloatField("Calorias",calorias);

		//prefab
		prefab = (GameObject) EditorGUILayout.ObjectField("prefab",prefab,typeof(GameObject),false);

		//label error
		if(!camposValidosNuevo()){
			GUILayout.Label("Error en los campos");
		} else {
			if(GUILayout.Button("Guardar")){
				Alimento al = new Alimento();
				al.id = ++despensa.lastId;
				al.nombre = tmpNombre;
				al.descripcion = tmpDescripcion;
				al.grupo = tmpGrupo;
				al.calorias = calorias;
				al.prefab = prefab;
				despensa.alimentos.Add(al);
				creando = false;
				EditorUtility.SetDirty(despensa);
				AssetDatabase.SaveAssets();
			}
		}
		if(GUILayout.Button("Cancelar")){
			creando = false;
		}
	}

	private void guiDescripcion(){
		//id
		GUILayout.Label("ID: "+alimentoSeleccionado.id);
		//nombre
		GUILayout.Label("nombre: "+alimentoSeleccionado.nombre);
		//descripcion
		GUILayout.Label("descripcion: "+alimentoSeleccionado.descripcion);
		//grupo
		GUILayout.Label("grupo: "+alimentoSeleccionado.grupo);
		//calorias
		GUILayout.Label("calorias: "+alimentoSeleccionado.calorias);

		//prefab
		if(alimentoSeleccionado.prefab != null){

			GUILayout.Label("prefab: "+alimentoSeleccionado.prefab.name);
		}

		if(GUILayout.Button("Editar")){
			id = alimentoSeleccionado.id;
			nombre = alimentoSeleccionado.nombre;
			descripcion = alimentoSeleccionado.descripcion;
			grupo = alimentoSeleccionado.grupo;
			//tmpCalorias = ""+alimentoSeleccionado.calorias;
			prefab = alimentoSeleccionado.prefab;
			verDescripcion = false;
			editando = true;
		}
		if(GUILayout.Button("Borrar")){
			despensa.alimentos.RemoveAt(posicionSeleccionada);
			verDescripcion = false;
		}

	}

	private void guiEdicion(){
		//id
		GUILayout.Label("ID: "+id);
		//nombre
		GUILayout.BeginHorizontal();
		GUILayout.Label("nombre: ");
		nombre = GUILayout.TextField(nombre);
		GUILayout.EndHorizontal();
		//descripcion
		GUILayout.BeginHorizontal();
		GUILayout.Label("descripcion: ");
		descripcion = GUILayout.TextField(descripcion);
		GUILayout.EndHorizontal();
		//grupo
		GUILayout.BeginHorizontal();
		GUILayout.Label("grupo: ");
		grupo = GUILayout.TextField(grupo);
		GUILayout.EndHorizontal();

		//calorias
		calorias = EditorGUILayout.FloatField("calorias",calorias);

		//prefab
		prefab = (GameObject) EditorGUILayout.ObjectField("prefab",prefab,typeof(GameObject),false);

		if(!camposValidosEdicion()){
			GUILayout.Label("Error en los campos");
		} else {
			if(GUILayout.Button("Guardar")){
				alimentoSeleccionado.nombre = nombre;
				alimentoSeleccionado.descripcion = descripcion;
				alimentoSeleccionado.grupo = grupo;
				alimentoSeleccionado.calorias = calorias;
				alimentoSeleccionado.prefab = prefab;
				editando = false;
				verDescripcion = true;
				EditorUtility.SetDirty(despensa);
				AssetDatabase.SaveAssets();
			}
		}
		if(GUILayout.Button("Cancelar")){
			editando = false;
			verDescripcion = true;
		}
	}

	private void alertDelete(){
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Cancelar")){
			verAlerta = false;
		}
		if(GUILayout.Button("Aceptar")){
			despensa.alimentos = new List<Alimento>();
			despensa.lastId = 0;
			verAlerta = false;
			EditorUtility.SetDirty(despensa);
			AssetDatabase.SaveAssets();
		}
		GUILayout.EndHorizontal();
	}

	private bool camposValidosNuevo(){
		if(tmpNombre == "")
			return false;
		if(tmpDescripcion == "")
			return false;
		if(tmpGrupo == "")
			return false;
		if(calorias < 0)
			return false;
		return true;
	}

	private bool camposValidosEdicion(){
		if(nombre == "")
			return false;
		if(descripcion == "")
			return false;
		if(grupo == "")
			return false;
		if(calorias < 0)
			return false;
		return true;
	}
}
