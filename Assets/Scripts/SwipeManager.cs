using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {

    public ButtonManager btnManager;
    public List<GameObject> AHAPages, CVIPages;
    public GameObject enlargeTable;
    
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public int ahaSwipe, cviSwipe;

    public bool canSwipe;

    void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

        EnlargeTableActive();
        Swipe();
	}

    void EnlargeTableActive()
    {
        if (enlargeTable.activeInHierarchy)
            canSwipe = false;
        else
            canSwipe = true;
    }


    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Debug.Log("firstPressPos: " + firstPressPos);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);        
            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            //normalize the 2d vector
            currentSwipe.Normalize();

            ////swipe upwards
            //if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            //{
            //    Debug.Log("up swipe");
            //}
            ////swipe down
            //if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            //{
            //    Debug.Log("down swipe");
            //}

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");        
            
                SwipeLeft();
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
            
                SwipeRight();
            }           
        }
    }


    //Go to Next Page if the user swipe left
    void SwipeLeft()
    {
        //if the AHA Button from Menu Page tapped
        if (btnManager.categoryPage == 0)
        {
            AHAPageLeft();       
        }
        //if the CVI Button from Menu Page tapped
        else if(btnManager.categoryPage == 1)
        {
            if (canSwipe)
                CVIPageLeft();
        }
    }
    //Go to Previous Page if the user swipe right
    void SwipeRight()
    {
        //if the AHA Button from Menu Page tapped
        if (btnManager.categoryPage == 0)
        {
            AHAPageRight();
        }
        //if the CVI Button from Menu Page tapped
        else if (btnManager.categoryPage == 1)
        {
            if (canSwipe)
                CVIPageRight();
        }
    }


    //AHA Page if swipe left
    void AHAPageLeft()
    {
        //page_3
        if (AHAPages[0].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[1].SetActive(true);
        }
        //page_4
        else if (AHAPages[1].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[2].SetActive(true);
        }
        //page_5
        else if (AHAPages[2].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[3].SetActive(true);
        }
        //page_6
        else if (AHAPages[3].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[4].SetActive(true);
            btnManager.isContinuous = true;
        }
        //page_7
        else if (AHAPages[4].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[5].SetActive(true);
            //if the page is from button tap
            else
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 4;
            }
        }
        //page_8
        else if (AHAPages[5].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[6].SetActive(true);
            //if the page is from button tap
            else
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 5;
            }
        }
        //page_9
        else if (AHAPages[6].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[7].SetActive(true);
            //if the page is from button tap
            else
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 6;
            }
        }
        //page_10
        else if (AHAPages[7].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[8].SetActive(true);
            //if the page is from button tap
            else
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 7;
            }
        }
        //page_11
        else if (AHAPages[8].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[9].SetActive(true);
            //if the page is from button tap
            else
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 8;
            }
        }
        //page_12
        else if (AHAPages[9].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
            {
                AHAPages[10].SetActive(true);
                ahaSwipe = 9;
            }
            //if the page is from button tap
            else
            {
                AHAPages[3].SetActive(true);
            }
        }
        //page_13
        else if (AHAPages[10].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[11].SetActive(true);
        }
        //page_14
        else if (AHAPages[11].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[3].SetActive(true);
        }       
    }
    //AHA Pages if swipe right
    void AHAPageRight()
    {
        //page_3
        if (AHAPages[0].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            btnManager.menuPage.SetActive(true);
        }
        //page_4
        else if (AHAPages[1].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[0].SetActive(true);
        }
        //page_5
        else if (AHAPages[2].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[1].SetActive(true);
        }
        //page_6
        else if (AHAPages[3].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[2].SetActive(true);
        }
        //page_7
        else if (AHAPages[4].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[3].SetActive(true);
        }
        //page_8
        else if (AHAPages[5].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[4].SetActive(true);
            //if the page is from button tap
            else
                AHAPages[3].SetActive(true);
        }
        //page_9
        else if (AHAPages[6].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[5].SetActive(true);
            //if the page is from button tap
            else
                AHAPages[3].SetActive(true);
        }
        //page_10
        else if (AHAPages[7].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[6].SetActive(true);
            //if the page is from button tap
            else
                AHAPages[3].SetActive(true);
        }
        //page_11
        else if (AHAPages[8].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[7].SetActive(true);
            //if the page is from button tap
            else
                AHAPages[3].SetActive(true);
        }
        //page_12
        else if (AHAPages[9].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            //if the page is from swipe
            if (btnManager.isContinuous)
                AHAPages[8].SetActive(true);
            //if the page is from button tap
            else
                AHAPages[3].SetActive(true);
        }
        //page_13
        else if (AHAPages[10].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[ahaSwipe].SetActive(true);
        }
        //page_14
        else if (AHAPages[11].activeInHierarchy)
        {
            foreach (var page in AHAPages)
                page.SetActive(false);

            AHAPages[10].SetActive(true);
        }
    }


    //CVI Pages if swipe left
    void CVIPageLeft()
    {
        //page_15
        if(CVIPages[0].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[1].SetActive(true);
        }
        //page_16
        else if (CVIPages[1].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[2].SetActive(true);
        }
        //page_17
        else if (CVIPages[2].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[3].SetActive(true);
        }
        //page_18
        else if (CVIPages[3].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[4].SetActive(true);
            btnManager.isContinuous = true;
        }
        //page_19
        else if (CVIPages[4].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                enlargeTable.SetActive(false);
                CVIPages[5].SetActive(true);
            }
            else
            {
                CVIPages[9].SetActive(true);
                cviSwipe = 4;
            }
        }
        //page_20
        else if (CVIPages[5].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            enlargeTable.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[6].SetActive(true);
            }
            else
            {
                CVIPages[9].SetActive(true);
                cviSwipe = 5;
            }
        }
        //page_21
        else if (CVIPages[6].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[7].SetActive(true);
            }
            else
            {
                CVIPages[9].SetActive(true);
                cviSwipe = 6;
            }
        }
        //page_22
        else if (CVIPages[7].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[8].SetActive(true);
            }
            else
            {
                CVIPages[9].SetActive(true);
                cviSwipe = 7;
            }
        }
        //page_23
        else if (CVIPages[8].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[9].SetActive(true);
            }
            else
            {
                CVIPages[3].SetActive(true);
                cviSwipe = 8;
            }
        }
        //page_24
        else if (CVIPages[9].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[10].SetActive(true);
        }
        //page_25
        else if (CVIPages[10].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[3].SetActive(true);
        }
    }
    //CVI Pages if swipe right
    void CVIPageRight()
    {
        //page_15
        if (CVIPages[0].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            btnManager.menuPage.SetActive(true);
        }
        //page_16
        else if (CVIPages[1].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[0].SetActive(true);
        }
        //page_17
        else if (CVIPages[2].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[1].SetActive(true);
        }
        //page_18
        else if (CVIPages[3].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[2].SetActive(true);
        }
        //page_19
        else if (CVIPages[4].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[3].SetActive(true);
        }
        //page_20
        else if (CVIPages[5].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            enlargeTable.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[4].SetActive(true);
            }
            else
            {
                CVIPages[3].SetActive(true);
            }
        }
        //page_21
        else if (CVIPages[6].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[5].SetActive(true);
            }
            else
            {
                CVIPages[3].SetActive(true);
            }
        }
        //page_22
        else if (CVIPages[7].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[6].SetActive(true);
            }
            else
            {
                CVIPages[3].SetActive(true);
            }
        }
        //page_23
        else if (CVIPages[8].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[7].SetActive(true);
            }
            else
            {
                CVIPages[3].SetActive(true);
            }
        }
        //page_24
        else if (CVIPages[9].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            if (btnManager.isContinuous)
            {
                CVIPages[8].SetActive(true);
            }
            else
            {
                CVIPages[cviSwipe].SetActive(true);
            }
        }
        //page_25
        else if (CVIPages[10].activeInHierarchy)
        {
            foreach (var page in CVIPages)
                page.SetActive(false);

            CVIPages[9].SetActive(true);
        }
    }

}


