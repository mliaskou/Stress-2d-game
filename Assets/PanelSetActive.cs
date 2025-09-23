using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSetActive : MonoBehaviour
{
    public GameObject panel;
   public void PanelGetActive()
    {
        panel.SetActive(true);
    }

    public void PanelDeactivate()
    {
        panel.SetActive(false);
    }
}
