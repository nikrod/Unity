﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;

public class claOpenFilePanel : MonoBehaviour
{
    public string filePath = "";
    public Texture2D texture;
    public GameObject m_goCube;

    // Use this for initialization
    void Start()
    {
        m_goCube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(210, 260, 100, 40), "Selecionar imagen"))
        {

#if UNITY_EDITOR
            filePath = EditorUtility.OpenFilePanel("Overwrite with png"
                                                , Application.streamingAssetsPath
                                                , ".jpg");
#endif
            if (filePath.Length != 0)
            {
                WWW www = new WWW("file://" + filePath);
                texture = new Texture2D(64, 64); //nueva imagen y dimensiones de esta
                www.LoadImageIntoTexture(texture);
                m_goCube.GetComponent<Renderer>().material.mainTexture = texture;

            }
        }
    }

    public void OpenFilePanel()
    {

    }
}