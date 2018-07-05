using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject mask;
    public ColliderScript colScript;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
       {
           Instantiate(mask, mousePos, Quaternion.identity);
       }
        RestrictLetter();      
    }

    void RestrictLetter()
    {
        if (GameObject.FindGameObjectsWithTag("D").Length == 0)
        {
            colScript.restrictLetter = "O";
            colScript.nextLetter = "I";
            Debug.Log("No more D");
        }
        if (GameObject.FindGameObjectsWithTag("I").Length == 0)
        {
            colScript.restrictLetter = "X";
            colScript.nextLetter = "O";
            Debug.Log("No more I");
        }
        if (GameObject.FindGameObjectsWithTag("O").Length == 0)
        {
            colScript.restrictLetter = "E";
            colScript.nextLetter = "X";
            Debug.Log("No more O");
        }
        if (GameObject.FindGameObjectsWithTag("X").Length == 0)
        {
            colScript.restrictLetter = "L";
            colScript.nextLetter = "E";
            Debug.Log("No more X");
        }
        if (GameObject.FindGameObjectsWithTag("E").Length == 0)
        {
            colScript.restrictLetter = "";
            colScript.nextLetter = "L";
            Debug.Log("No more E");
        }
        if (GameObject.FindGameObjectsWithTag("L").Length == 0)
        {
            Debug.Log("No more L");
            SceneManager.LoadScene("edetailer");
        }
    }

    public void btnSkip()
    {
        SceneManager.LoadScene("edetailer");
    }
    
}
