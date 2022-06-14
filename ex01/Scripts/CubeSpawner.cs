using UnityEngine;
using Random = UnityEngine.Random;

namespace ex01.Scripts
{
    public class CubeSpawner : MonoBehaviour
    {
        public GameObject aPrefab;
        public GameObject sPrefab;
        public GameObject dPrefab;
        public GameObject aStart;
        public GameObject sStart;
        public GameObject dStart;
        public GameObject start;
    
        private GameObject _aKey;
        private GameObject _sKey;
        private GameObject _dKey;
        private float _timer;
    
        // Start is called before the first frame update
        void Start()
        {
            _aKey = null;
            _sKey = null;
            _dKey = null;
            _timer = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            _timer += Time.deltaTime * Random.Range(1, 5);
            if (!(_timer >= .5f)) return;
            _timer %= .5f;
            switch (Random.Range(0, 5))
            {
                case 0:
                    if (!_aKey)
                        _aKey = GameObject.Instantiate(aPrefab, new Vector3(aStart.transform.position.x, start.transform.position.y, 0), Quaternion.identity);
                    break;
                case 1:
                    if (!_sKey)
                        _sKey = GameObject.Instantiate(sPrefab, new Vector3(sStart.transform.position.x, start.transform.position.y, 0), Quaternion.identity);
                    break;
                case 2:
                    if (!_dKey)
                        _dKey = GameObject.Instantiate(dPrefab,new Vector3(dStart.transform.position.x, start.transform.position.y, 0), Quaternion.identity);
                    break;
            }
        }
    }
}
