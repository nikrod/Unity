using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class image : MonoBehaviour
{

    // Use this for initialization
    public string filePath = "";
    //public RawImage imagen;
    private WWW WWW;


    void Start()
    {
        //imagen = GameObject.Find("RawImage").GetComponent<RawImage>(); para buscar un objeto remplazar "RawImage"
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

        WWW WWW = new WWW("file://" + filePath);        
        this.GetComponent<RawImage>().texture = WWW.texture;

    }

    /* public static IEnumerator urlTexture()  obtener imagen desde servidor ftp
     {
         string url = "ftp://username:password@HOST_IP/images/00013/01_01.jpg";
         Debug.Log("Request sent");
        // GlobalVariables.myUrl[1] = new WWW(url);
        // yield return GlobalVariables.myUrl[1];
     }*/
}
