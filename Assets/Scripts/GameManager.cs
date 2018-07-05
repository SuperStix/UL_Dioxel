using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public List<GameObject> restrict;
    public GameObject mask;
    GameObject clone;

    public ColliderScript colScript;

    public float timer;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        MaskClone();
        RestrictLetter();
    }

    void MaskClone()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            GameObject cloneMask = Instantiate(mask, mousePos, Quaternion.identity);
            colScript.timer = 0.5f;
            cloneMask.tag = "Mask";
            cloneMask.name = "Clone";
            ColliderScript col = cloneMask.GetComponent<ColliderScript>();
            CircleCollider2D cc = cloneMask.GetComponent<CircleCollider2D>();
            //cc.isTrigger = true;
            Destroy(col, 0.5f);
        }
    }

    void RestrictLetter()
    {
        if (GameObject.FindGameObjectsWithTag("D").Length == 0)
        {
            colScript.restrictLetter = "O";
            colScript.nextLetter = "I";
            restrict[0].SetActive(false);
            //Debug.Log("No more D");
        }
        if (GameObject.FindGameObjectsWithTag("I").Length == 0)
        {
            colScript.restrictLetter = "X";
            colScript.nextLetter = "O";
            restrict[1].SetActive(false);
            //Debug.Log("No more I");
        }
        if (GameObject.FindGameObjectsWithTag("O").Length == 0)
        {
            colScript.restrictLetter = "E";
            colScript.nextLetter = "X";
            restrict[2].SetActive(false);
            //Debug.Log("No more O");
        }
        if (GameObject.FindGameObjectsWithTag("X").Length == 0)
        {
            colScript.restrictLetter = "L";
            colScript.nextLetter = "E";
            restrict[3].SetActive(false);
            //Debug.Log("No more X");
        }
        if (GameObject.FindGameObjectsWithTag("E").Length == 0)
        {
            colScript.restrictLetter = "";
            colScript.nextLetter = "L";
            restrict[4].SetActive(false);
            //Debug.Log("No more E");
        }
        if (GameObject.FindGameObjectsWithTag("L").Length == 0)
        {
            //Debug.Log("No more L");
            colScript.restrictLetter = "I";
            colScript.nextLetter = "D";
            SceneManager.LoadScene("edetailer");
        }
    }

    public void btnSkip()
    {
        SceneManager.LoadScene("edetailer");
    }

}
