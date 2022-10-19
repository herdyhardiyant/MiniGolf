using UnityEngine;

namespace Scenes.Scripts
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float forcePower = 100f;
        [SerializeField] private Camera camera;

        public Vector3 Position => _rigidbody.position;
        
        private Transform _transform;
        // Start is called before the first frame update
        void Awake()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("space"))
            {
               _rigidbody.AddForce(Vector3.back * forcePower,ForceMode.Impulse );
            }

        }
    }
}
