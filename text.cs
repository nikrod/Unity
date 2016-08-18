using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class text : MonoBehaviour {

    // Use this for initialization
    public InputField input; //declaramos el input field, recordar asignar el objeto en unity!
    public Text texto; //declaramos el cuadro de texto, recordar asignar el objeto en unity!
    private string noticia = ""; // string para obtener el nombre de la escena!
    public string rutadropbox = ""; //se obtiene la ruta de la carpeta dropbox, recordar asignar en unity y verificar que se encuentre la ruta completa!

    void Start ()
    {
        noticia = SceneManager.GetActiveScene().name; //obtenemos el nombre de la Escena!  
        texto.text = File.ReadAllText(rutadropbox+noticia+"/"+noticia+".txt");//remplazar la ruta del parentesis para obtener texto!
    }

	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void guardar()
    {
        texto.text = input.text.ToString();     //pasamos el texto desde el inputfield al cuadro de texto  
        File.WriteAllText("Assets/"+noticia + ".txt", texto.text);//creamos el txt en la carpeta assets
        File.WriteAllText(rutadropbox+noticia+"/"+noticia+".txt", texto.text);//creamos el txt en el dropbox
    }

}
