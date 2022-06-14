using UnityEngine;

namespace ex01.Scripts
{
    public class Cube : MonoBehaviour
    {
        private float _speed;

        public KeyCode key;
        public GameObject end;

        // Start is called before the first frame update
        void Start()
        {
            _speed = Random.Range(1f, 10f);
        }

        void Ok()
        {
            float dist = (end.transform.position.y - transform.position.y);
            if (dist < 0)
                dist *= -1;
            Debug.Log("Precision: " + dist);
            GameObject.Destroy(this.gameObject);
        }

        void Miss()
        {
            Debug.Log("Miss!!!");
            GameObject.Destroy(this.gameObject);
        }
    
        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down * (Time.deltaTime * _speed));
            if (Input.GetKeyDown(KeyCode.A) && key == KeyCode.A)
                Ok();
            else if (Input.GetKeyDown(KeyCode.S) && key == KeyCode.S)
                Ok();
            else if (Input.GetKeyDown(KeyCode.D) && key == KeyCode.D)
                Ok();
            else if (end.transform.position.y - transform.position.y > 2)
                Miss();
        }
    }
}
