using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class cargararchivo : MonoBehaviour
{

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void subir()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] fileInfo = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);
        GameObject.Find("File Selection").GetComponent<Dropdown>().options.Clear();
        foreach (FileInfo file in fileInfo)
        {
            Dropdown.OptionData optionData = new Dropdown.OptionData(file.Name);
            GameObject.Find("File Selection").GetComponent<Dropdown>().options.Add(optionData);
            GameObject.Find("File Selection").GetComponent<Dropdown>().value = 1;
        }
    }
}
