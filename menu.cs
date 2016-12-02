using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class menu : MonoBehaviour {

    // Use this for initialization
    public GameObject Lista_Prefab;
    public GameObject prefabnoticia;

    public RectTransform panelScrollDown;
    public RectTransform Sistematizacion;
    private int cont = 0;
    string cauxiliar;
    int registros = 0;
    private GameObject aux;
    private GameObject aux2;
    private string texto;
    private string auxiliar;
    public Text texto2;
    int verificador;
    //public int identificador;

    //public GameObject panel1;//creamos un objeto de la clase panel!

    private List<GameObject> paneles = new List<GameObject>();//lista de la clase panel!
    private List<GameObject> noticias = new List<GameObject>();

    void Start()
    {
        cargar();
        
    }

    void cargar()
    {
        cauxiliar = File.ReadAllText("Assets/noticia.txt");
        registros = int.Parse(cauxiliar);//
        //print(cauxiliar);

        for (int i = 0; i < registros; i++)
        {
            resultado();
            //print("entra " + cauxiliar);
        }
        cont = registros;
    }

    void guardar(int cont)
    {
        File.WriteAllText("Assets/noticia.txt",cont.ToString());
    }

    public void resultado()
    {

        //creacion de panel
        GameObject resultadoHijo = Instantiate(Lista_Prefab) as GameObject; //se crea el prefab
        //GameObject panel1 =GameObject.Instantiate(Lista_Prefab);
        //panel1.transform.SetParent(panelScrollDown.transform);    
        //panel panel3 = panel1.GetComponent<panel>();
        //panel3.transform.SetParent(panelScrollDown.transform);
      
        
        resultadoHijo.transform.SetParent(panelScrollDown.transform); //se le da herencia del panel con scrolldown

        
        //al cambiar el valor del contador de noticias se guarda el registro
         //se aumenta el contador para darle el nombre al prefab en los menus de unity
        //print("el contador es "+cont);
        cont++;
        guardar(cont);


        resultadoHijo.name = "Titulo" + cont;//se asigna el nombre a la instancia
        //resultadoHijo.setid(cont);
        //resultadoHijo.settitulo("Titulo" + cont);

        int caux = cont + 1; //se aumenta el contador en 1 para mostrarlo en los paneles desde 1 y no desde 0
        setnombre(caux.ToString());//se cambia el id del panel 
        RectTransform resultadoPanel = resultadoHijo.GetComponent<RectTransform>();//se ajusta la posicion y tamaño del panel
        resultadoHijo.transform.localScale = Vector3.one;
        resultadoHijo.transform.localPosition = Vector3.zero;
        resultadoHijo.gameObject.SetActive(true);

        //creacion de noticia
        GameObject noticia = Instantiate(prefabnoticia);
        noticia.transform.SetParent(Sistematizacion.transform);
        noticia.name = "Noticia" + cont;
        RectTransform resultadonocitia = noticia.GetComponent<RectTransform>();
        resultadonocitia.transform.localScale = Vector3.one;
        resultadonocitia.transform.localPosition = Vector3.zero;
        noticias.Add(noticia);//agrego el elemento a una lista para guardar la referencia al objeto desactivado
        resultadonocitia.gameObject.SetActive(false);

       
    }

    public void setnombre(string id)
    {
        texto2.text = id;
    }

    public void boton_noticia()
    {
        GameObject aux = GameObject.Find("titulo");
        //int contador = int.Parse(texto2.text.ToString());
        //print(contador-1);

    }


    public void borrar()
	{
        int contador = cont;
        if (cont > 0) 
		{
			aux = GameObject.Find ("Titulo"+cont);
            Destroy(aux);
            aux = noticias[cont-1];
            noticias.Remove(aux);
            Destroy(aux);
            cont--;
            guardar(cont);
		}
	}


	public void boton1()
	{
		resultado ();
	}

	// Update is called once per frame
	void Update () {
		/*
			//int registro1 = cont + 1;
			texto = cont.ToString ();
            print(texto);
			//File.WriteAllText("Assets/noticia.txt", texto);	
		*/}
	
}
