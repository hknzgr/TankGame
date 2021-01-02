using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour {

	public static int hak=0;
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void openLevelOne()
    {
        hak = 10;
        SceneManager.LoadScene(1);
    }
    public void openLevelTwo()
    {
        hak = 5;
        SceneManager.LoadScene(2);
    }
    public void openLevelThree()
    {
        hak = 3;
        SceneManager.LoadScene(3);
    }
}
