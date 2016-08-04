using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeEscene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
         
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene("escena2");
    }
}
