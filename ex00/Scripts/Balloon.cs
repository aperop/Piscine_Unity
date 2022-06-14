using UnityEngine;

namespace ex00.Scripts
{
    public class Balloon : MonoBehaviour
    {
        private int _blow;
        private float _unblow;
        // Start is called before the first frame update
        void Start()
        {
            transform.localScale += new Vector3(2, 2, 0);
            _blow = 4;
            _unblow = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && _blow > 0)
            {
                --_blow;
                transform.localScale += new Vector3(1f, 1f, 0);
            }
            else
            {
                transform.localScale += new Vector3(-.01f, -.01f, 0);
            }
            _unblow += Time.deltaTime;
            if(_unblow >= .3f)
            {
                _unblow %= .3f;
                if(_blow < 4)
                    ++_blow;
            }
            if(transform.localScale.x <= 0.1 || transform.localScale.x >= 10)
            {
                GameObject.Destroy(this.gameObject);
                GameObject.Destroy(this);
                Debug.Log("Balloon life time: " + Mathf.RoundToInt(Time.time) + "s");
            }
        }
    }
}
