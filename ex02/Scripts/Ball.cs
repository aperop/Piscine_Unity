using UnityEngine;

namespace ex02.Scripts
{
    public class Ball : MonoBehaviour
    {
        public Club club;
        public GameObject hole;
        public GameObject borderBottom;
        public GameObject borderTop;

        private float _power;

        private bool _direction;

        private bool _isMoving;

        private int _score;
        
        // Start is called before the first frame update
        private void Start()
        {
            _power = 0f;
            _direction = true;
            _isMoving = false;
            _score = -15;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_power > 0)
            {
                if (_direction)
                    if (transform.position.y >= borderTop.transform.position.y)
                    {
                        transform.Translate(Vector3.down * _power);
                        _direction = false;
                    }
                    else
                        transform.Translate(Vector3.up * _power);
                else
                    if (transform.position.y <= borderBottom.transform.position.y)
                    {
                        transform.Translate(Vector3.up * _power);
                        _direction = true;
                    }
                    else
                        transform.Translate(Vector3.down * _power);
                ball_in_hole();
                _power -= 0.005f;
            }
            else
            {
                _direction = true;
                if (_isMoving == true)
                {
                    _isMoving = false;
                    _score += 5;
                    Debug.Log("Score: " + _score);
                    if (!ball_in_hole())
                        club.set_pos(transform.position.y);
                }
            }
        }

        public bool ball_in_hole()
        {
            if (hole.transform.position.y - transform.position.y <= .5f && hole.transform.position.y - transform.position.y >= -.5f && _power < .03f)
            {
                Debug.Log("End game!!! Total score: " + _score);
                transform.position = new Vector3(0f, hole.transform.position.y, -10f);
                club.set_pos(0f);
                return true;
            }
            return false;
        }

        public void set_power(float power)
        {
            if (_isMoving == false)
            {
                this._power = power;
                _isMoving = true;
            }
        }
    }

}
