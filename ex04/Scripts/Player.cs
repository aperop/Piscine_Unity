using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject lRacket;
    public GameObject rRacket;
    public GameObject top;
    public GameObject bottom;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && lRacket.transform.position.y < top.transform.position.y - 1f)
            lRacket.transform.Translate(0f, 0.05f, 0f);
        
        if (Input.GetKey(KeyCode.S) && lRacket.transform.position.y > bottom.transform.position.y + 1f)
            lRacket.transform.Translate(0f, -0.05f, 0f);
        
        if (Input.GetKey(KeyCode.UpArrow) && rRacket.transform.position.y < top.transform.position.y - 1f)
            rRacket.transform.Translate(0f, 0.05f, 0f);
        
        if (Input.GetKey(KeyCode.DownArrow) && rRacket.transform.position.y > bottom.transform.position.y + 1f)
            rRacket.transform.Translate(0f, -0.05f, 0f);
    }
}
