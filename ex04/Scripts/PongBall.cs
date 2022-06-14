using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PongBall : MonoBehaviour
{
    public GameObject lRacket;
    public GameObject rRacket;
    public GameObject left;
    public GameObject right;
    public GameObject top;
    public GameObject bottom;
    public float speed;

    private float _vSpeed;
    private float _hSpeed;
    private bool _isGoal;
    private int _lScore;
    private int _rScore;
    // Start is called before the first frame update
    void Start()
    {
        _isGoal = false;
        _lScore = 0;
        _rScore = 0;
        _hSpeed = Random.Range(0, 2) == 0 ? speed : -speed;
        _vSpeed = Random.Range(0, 2) == 0 ? speed : -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < left.transform.position.x)
        {
            _isGoal = true;
            _rScore++;
        }
        
        if (transform.position.x > right.transform.position.x)
        {
            _isGoal = true;
            _lScore++;
        }

        if (_isGoal)
        {
            _isGoal = false;
            Debug.Log("Player 1: " + _lScore + "\t|\tPlayer 2: " + _rScore);
            transform.position = new Vector3(0, 0, 0);
            _hSpeed = Random.Range(0, 2) == 0 ? speed : -speed;
            _vSpeed = Random.Range(0, 2) == 0 ? speed : -speed;
        }

        if (transform.position.y > top.transform.position.y || transform.position.y < bottom.transform.position.y)
            _vSpeed *= -1;
        
        if (transform.position.x + .1f > rRacket.transform.position.x)
            if ((transform.position.y > rRacket.transform.position.y - .6f) &&
                 (transform.position.y < rRacket.transform.position.y + .6f))
                _hSpeed *= -1f;
            else
                _hSpeed *= 1.1f;
        if (transform.position.x - .1f < lRacket.transform.position.x)
            if ((transform.position.y > lRacket.transform.position.y - .6f) &&
                 (transform.position.y < lRacket.transform.position.y + .6f))
                _hSpeed *= -1f;
            else
                _hSpeed *= 1.1f;
        transform.Translate(_hSpeed, _vSpeed, 0f);
    }
}
