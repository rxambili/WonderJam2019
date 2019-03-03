using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicBar : MonoBehaviour
{

    public GameObject publicBar;

    public void showPublicBar()
    {
        publicBar.SetActive(true);
    }


}
