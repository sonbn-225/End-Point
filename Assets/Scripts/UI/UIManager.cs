using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUIManager
{
    public GameObject buttonPanel, attackPanel, defendPanel, resourcePanel;


    public void InitAttackPanel()
    {
        attackPanel = Instantiate(Resources.Load("AttackPanel")) as GameObject;
        attackPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        attackPanel.SetActive(false);
    }

    public void InitButtonPanel()
    {
		buttonPanel = Instantiate(Resources.Load("ButtonPanel")) as GameObject;
		buttonPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    public void InitDefendPanel()
    {
		defendPanel = Instantiate(Resources.Load("DefendPanel")) as GameObject;
		defendPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        defendPanel.SetActive(false);
    }

    public void InitResourcePanel()
    {
		resourcePanel = Instantiate(Resources.Load("ResourcePanel")) as GameObject;
		resourcePanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        resourcePanel.SetActive(false);
    }

	public void AttackButtonClicked()
	{
        attackPanel.SetActive(true);
        defendPanel.SetActive(false);
        resourcePanel.SetActive(false);
	}

	public void DefendButtonClicked()
	{
        attackPanel.SetActive(false);
        defendPanel.SetActive(true);
		resourcePanel.SetActive(false);
	}

    public void ResourceButtonClicked()
    {
        attackPanel.SetActive(false);
		defendPanel.SetActive(false);
        resourcePanel.SetActive(true);
    }

    public void ClosePanelButtonClicked()
    {
		attackPanel.SetActive(false);
		defendPanel.SetActive(false);
        resourcePanel.SetActive(false);
    }
}
