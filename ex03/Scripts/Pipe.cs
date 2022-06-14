using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float start;

    public float end;

    public float speed;

    public float ceiling;

    public float floor;

    private int _score;

    public GameObject bird;
    
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < end)
        {
            transform.Translate(start, 0, 0);
            _score += 5;
            speed += .3f;
        }
        if(bird)
        {
            if ((transform.position.x - bird.transform.position.x > -.5f) &&
                (transform.position.x - bird.transform.position.x < .5f))
                if ((bird.transform.position.y > ceiling) || (bird.transform.position.y < floor))
                    Destroy(bird);
        }
        else
        {
            if (speed != 0)
                Debug.Log("Score: " + _score + "\nTime: " + Mathf.RoundToInt(Time.time) + "s");
            speed = 0;
        }
    }
}
