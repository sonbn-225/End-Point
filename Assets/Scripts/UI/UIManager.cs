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
        Debug.Log("InitAttackPanel");
    }

    public void InitButtonPanel()
    {
        
    }

    public void InitDefendPanel()
    {
    }

    public void InitResourcePanel()
    {
    }
}
