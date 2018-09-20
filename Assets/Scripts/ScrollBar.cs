using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour {

    private static ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = this.GetComponent<ScrollRect>();
    }

    private void Update()
    {
        if (Input.anyKeyDown || Input.GetKeyDown(KeyCode.Return))
            scrollRect.verticalNormalizedPosition = 0;
    }
}
