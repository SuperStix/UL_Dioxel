using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject menuPage, ahaPage, cviPage; //SBR_02

    public GameObject ahaPage1, cviPage1;

    public GameObject ahaSkipOrMenu, cviSkipOrMenu;

    public int categoryPage;

    public bool isContinuous;//if the next page is from swipe or button tap

    public List<GameObject> ahaPages, cviPages;

    //Button function for Home Button of All Pages
    public void btnHome()
    {
        ahaPage.SetActive(false);
        ahaSkipOrMenu.SetActive(false);

        cviPage.SetActive(false);
        cviSkipOrMenu.SetActive(false);

        menuPage.SetActive(true);
    }

    //Button functions for CVI Pages
    public void CVI()
    {
        menuPage.SetActive(false);
        cviPage.SetActive(true);
        cviPage1.SetActive(true);

        categoryPage = 1;
    }
    public void CVIBtnStandard()
    {
        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[0].SetActive(true);
    }
    public void CVIBtnSafe()
    {
        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[1].SetActive(true);
    }
    public void CVIBtnStrength()
    {
        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[3].SetActive(true);
    }
    public void CVIBtnSeal()
    {
        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[2].SetActive(true);
    }
    public void CVIBtnADR()
    {
        isContinuous = false;
        cviSkipOrMenu.SetActive(false);
        cviPages[4].SetActive(true);
    }
    public void CVIBtnSkipOrMenu()
    {
        foreach (var pages in cviPages)
            pages.SetActive(false);

        cviSkipOrMenu.SetActive(true);
    }

    //Button functions for AHA Pages
    public void AHA()
    {
        menuPage.SetActive(false);
        ahaPage.SetActive(true);
        ahaPage1.SetActive(true);

        categoryPage = 0;
    }
    public void AHABtnStandard()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[0].SetActive(true);
    }
    public void AHABtnSymptoms()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[1].SetActive(true);
    }
    public void AHABtnSafe()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[2].SetActive(true);
    }
    public void AHABtnSeal()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[3].SetActive(true);
    }
    public void AHABtnStrength()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[4].SetActive(true);
    }
    public void AHABtnADR()
    {
        isContinuous = false;
        ahaSkipOrMenu.SetActive(false);
        ahaPages[5].SetActive(true);
    }
    public void AHABtnSkipOrMenu()
    {
        foreach (var pages in ahaPages)
            pages.SetActive(false);

        ahaSkipOrMenu.SetActive(true);
    }

}
