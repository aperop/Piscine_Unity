using UnityEngine;

namespace ex02.Scripts
{
    public class Club : MonoBehaviour
    {
        public Ball ball;

        public GameObject border;

        private float _power;
        private bool _isUsing;

        // Start is called before the first frame update
        private void Start()
        {
            _power = 0;
            _isUsing = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (ball.ball_in_hole())
                return;
            if (Input.GetKey(KeyCode.Space) && transform.position.y > border.transform.position.y)
            {
                _isUsing = true;
                if (_power < .6f)
                    _power += .01f;
                transform.Translate(Vector3.down * (Time.deltaTime * 2));
            }
            else
            {
                if (_isUsing)
                {
                    _isUsing = false;
                    transform.position = ball.transform.position;
                    ball.set_power(_power);
                    _power = 0f;
                }
            }
        }

        public void set_pos(float yPos)
        {
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }

    }
}
