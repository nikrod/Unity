using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class image : MonoBehaviour
{

    // Use this for initialization
    public string filePath = "";
    //public RawImage imagen;
    private WWW WWW; //objeto declardo para guardar la imagen
    private string noticia = "";//declarada para luego obtener el nombre de la escena
    private string dropbox = ""; //se genera esta variable para generar la ruta de la carpeta que contiene esta noticia
    public string url = ""; //variable declarada para obtener la url de una foto y cargarla al objeto
    public string rutadropbox = "";//agregar la ruta de dropbox en unity! no olvidar
    private string rutaimagen="";


    void Start()
    {
        //imagen = GameObject.Find("RawImage").GetComponent<RawImage>(); para buscar un objeto remplazar "RawImage"        
        noticia = SceneManager.GetActiveScene().name; //obtenemos el nombre de la Escena!       
        dropbox = rutadropbox + noticia + "/" + noticia + ".jpg";
        StartCoroutine("WaitForDownload", dropbox); //llamamos a la rutina
        
    }

    private IEnumerator WaitForDownload(string url) //rutina para bajar un archivo y cargarlo en el objeto actual
    {
        WWW = new WWW("file://" + url);//remplazar ruta por el objeto url declardo al inicio en caso de querer cargar una foto de dropbox!
        yield return WWW;
        this.GetComponent<RawImage>().texture = WWW.texture;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void subir()
    {

    #if UNITY_EDITOR
        filePath = EditorUtility.OpenFilePanel("Overwrite with png"
        , Application.streamingAssetsPath
        , "jpg");
    #endif

        WWW = new WWW("file://" + filePath);        
        this.GetComponent<RawImage>().texture = WWW.texture;   
        rutaimagen = "C:/Users/Niko/Documents/prueba 2/Assets/"+noticia+".jpg";//ruta donde se guardara la noticia
        FileUtil.DeleteFileOrDirectory(dropbox); // Nos aseguramos de que no exista el archivo!
        FileUtil.DeleteFileOrDirectory(rutaimagen);//verificamos que no exista la fotografia!
        FileUtil.CopyFileOrDirectory(filePath,rutaimagen);//se copia la imagen a la carpeta assets
        FileUtil.CopyFileOrDirectory(filePath,dropbox);//se copia la imagen a dropbox

    }

    /* public static IEnumerator urlTexture()  obtener imagen desde servidor ftp
     {
         string url = "ftp://username:password@HOST_IP/images/00013/01_01.jpg";
         Debug.Log("Request sent");
        // GlobalVariables.myUrl[1] = new WWW(url);
        // yield return GlobalVariables.myUrl[1];
     }*/
}
