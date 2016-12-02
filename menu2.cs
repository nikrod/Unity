using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class menu2 : MonoBehaviour {

    public Text Id;
    public Text Nombre;

    // Use this for initialization
    public void boton_noticia()
    {
        int contador = int.Parse(Id.text.ToString());
        print(contador-1);
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
