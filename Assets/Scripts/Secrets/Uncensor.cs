using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uncensor : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshPro text;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.enabled = true;
        print("9:S");
    }
}
