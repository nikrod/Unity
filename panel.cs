using UnityEngine;
using System.Collections;

public class panel : MonoBehaviour {

   
        int id;
        string titulo;

        public panel()
        {
            id = 0;
            titulo= "";
        }

        public panel(int identificador, string titu)
        {
            id = identificador;
            titulo = titu;
        }

        public int getid()
        {
            return id;
        }

        public string gettitulo()
        {
            return titulo;
        }

        public void setid(int id2)
        {
            id = id2;
        }

        public void settitulo(string titulo2)
        {
            titulo = titulo2;
        }
   
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
