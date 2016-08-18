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
    public string noticia = "";
    public string dropbox = "";
    public string url = "";
    public string rutadropbox = "";


    void Start()
    {
        //imagen = GameObject.Find("RawImage").GetComponent<RawImage>(); para buscar un objeto remplazar "RawImage"
        StartCoroutine("WaitForDownload", url);
        
    }

    private IEnumerator WaitForDownload(string url)
    {
        WWW = new WWW(url);
        //while (!WWW.isDone) // D:
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
        noticia=SceneManager.GetActiveScene().name; //obtenemos el nombre de la Escena!       
        dropbox = rutadropbox + noticia + "/"+ noticia+".jpg";
        Debug.Log(noticia);
        FileUtil.DeleteFileOrDirectory(dropbox); // Nos aseguramos de que no exista el archivo!
        FileUtil.CopyFileOrDirectory(filePath, dropbox);

    }

    /* public static IEnumerator urlTexture()  obtener imagen desde servidor ftp
     {
         string url = "ftp://username:password@HOST_IP/images/00013/01_01.jpg";
         Debug.Log("Request sent");
        // GlobalVariables.myUrl[1] = new WWW(url);
        // yield return GlobalVariables.myUrl[1];
     }*/
}
