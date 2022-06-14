using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;

    public float ground;
    public float sky;
    
    private float _fly;
    // Start is called before the first frame update
    void Start()
    {
        _fly = .00005f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= ground || transform.position.y >= sky)
            GameObject.Destroy(this.gameObject);

        if (Input.GetKey(KeyCode.Space))
            _fly += 0.00005f;
        
        if (_fly > 0f)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            _fly -= 0.00005f;
        }
        else
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
