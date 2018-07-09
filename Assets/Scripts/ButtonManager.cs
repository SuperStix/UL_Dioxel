using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public SwipeManager sm;

    public GameObject menuPage, ahaPage, cviPage; //SBR_02

    public GameObject ahaPage1, cviPage1;

    public GameObject ahaSkipOrMenu, cviSkipOrMenu;

    public GameObject enlargeTable;

    public int categoryPage;

    public bool isContinuous;//if the next page is from swipe or button tap

    public List<GameObject> ahaPages, cviPages;

    public List<GameObject> ahaPageWithSkip, cviPageWithSkip;

    //Button function for Home Button of All Pages
    public void btnHome()
    {
        ahaPage.SetActive(false);
        ahaSkipOrMenu.SetActive(false);

        cviPage.SetActive(false);
        cviSkipOrMenu.SetActive(false);

        menuPage.SetActive(true);
    }

    public void btnEnlargeTable()
    {
        enlargeTable.transform.localScale = new Vector3(0.4433602f, 0.2140943f, 0.3495363f);
    }

    void btnTap()
    {
        sm.timer = 2f;
        //.canSwipe = false;
    }


    //Button functions for CVI Pages
    public void CVI()
    {
        btnTap();

        menuPage.SetActive(false);
        cviPage.SetActive(true);
        cviPage1.SetActive(true);

        categoryPage = 1;
    }
    public void CVIBtnStandard()
    {
        btnTap();

        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[0].SetActive(true);
        cviPage1.SetActive(false);
    }
    public void CVIBtnSafe()
    {
        btnTap();

        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[1].SetActive(true);
        cviPage1.SetActive(false);
    }
    public void CVIBtnStrength()
    {
        btnTap();

        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[3].SetActive(true);
        cviPage1.SetActive(false);
    }
    public void CVIBtnSeal()
    {
        btnTap();

        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[2].SetActive(true);
    }
    public void CVIBtnADR()
    {
        btnTap();

        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[4].SetActive(true);
    }
    public void CVIBtnSkipOrMenu()
    {
        btnTap();

        foreach (var pages in cviPageWithSkip)
            pages.SetActive(false);

        foreach (var pages in cviPages)
            pages.SetActive(false);

        cviSkipOrMenu.SetActive(true);
    }

    //Button functions for AHA Pages
    public void AHA()
    {
        btnTap();

        menuPage.SetActive(false);
        ahaPage.SetActive(true);
        ahaPage1.SetActive(true);

        categoryPage = 0;
    }
    public void AHABtnStandard()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[0].SetActive(true);
    }
    public void AHABtnSymptoms()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[1].SetActive(true);
    }
    public void AHABtnSafe()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[2].SetActive(true);
    }
    public void AHABtnSeal()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[3].SetActive(true);
    }
    public void AHABtnStrength()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[4].SetActive(true);
    }
    public void AHABtnADR()
    {
        btnTap();

        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[5].SetActive(true);
    }
    public void AHABtnSkipOrMenu()
    {
        btnTap();

        foreach (var pages in ahaPageWithSkip)
            pages.SetActive(false);

        foreach (var pages in ahaPages)
            pages.SetActive(false);
        
        ahaSkipOrMenu.SetActive(true);
    }

}
