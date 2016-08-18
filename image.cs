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
    private WWW WWW;
    private WWW WWW2;
    private string noticia = "";
    private string dropbox = "";
    public string url = "";
    public string rutadropbox = "";
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
        WWW = new WWW("file://" + url);
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
        rutaimagen = "C:/Users/Niko/Documents/prueba 2/Assets/"+noticia+".jpg";
        FileUtil.DeleteFileOrDirectory(dropbox); // Nos aseguramos de que no exista el archivo!
        FileUtil.DeleteFileOrDirectory(rutaimagen);
        FileUtil.CopyFileOrDirectory(filePath,rutaimagen);    
        FileUtil.CopyFileOrDirectory(filePath,dropbox);

    }

    /* public static IEnumerator urlTexture()  obtener imagen desde servidor ftp
     {
         string url = "ftp://username:password@HOST_IP/images/00013/01_01.jpg";
         Debug.Log("Request sent");
        // GlobalVariables.myUrl[1] = new WWW(url);
        // yield return GlobalVariables.myUrl[1];
     }*/
}
