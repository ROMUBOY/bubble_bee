using UnityEngine;

public class TranslatingObject : MonoBehaviour
{    
    [SerializeField] private float _radius;    
    [SerializeField] private float _speed;
    private float _factor;
    private Vector3 _reference;
    public float _w;
    [Range(0,360)]
    [SerializeField]private float _initialPosition;

    [SerializeField]private GameObject _centerObject;

    public void SetValues(float radius, float speed)
    {
        _radius = radius;
        _speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _w = ((- _initialPosition/_speed) + 90) * Mathf.Deg2Rad;
        if(_centerObject == null)
        {
            _reference = this.transform.position;
        }
        else
        {
            _reference = _centerObject.transform.position;
        }
        
        _factor = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {        
        _w = _w + Time.deltaTime * _factor;   

        if(_centerObject != null)
        {
            CenterPositionControler();
        }

        PositionControler();
    }
   
    void PositionControler()
    {
        transform.position = new Vector3(_reference.x + _radius * Mathf.Sin(_speed * _w), _reference.y + _radius * Mathf.Cos(_speed * _w));
    }

    void CenterPositionControler()
    {
        _reference = _centerObject.transform.position;
    }
}
