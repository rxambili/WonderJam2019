using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audienceBar : MonoBehaviour
{

    private Image publicBar;
    public RoundManager RM;

    // Start is called before the first frame update
    void Start()
    {
        publicBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        publicBar.fillAmount = (float)RM.audienceHype / RoundManager.maxAudienceHype;
    }
}
