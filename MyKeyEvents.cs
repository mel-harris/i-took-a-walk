using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyKeyEvents : MonoBehaviour
{
    [SerializeField] float _initialFOV;
    [SerializeField] float _currentFOV;
    [SerializeField] float _factor;
    private bool _isShift = false;
    [SerializeField] float _currentOS;
    
    

    void Start()
    {
        _factor = 10.0f;
        _currentFOV = 50.0f;
        _initialFOV = Camera.main.fieldOfView;
        Debug.Log("MyKeyEvents Initialized: " + _initialFOV); 
        // Camera.main.usePhysicalProperties = true;


        
    }

    void Update()
    {

        float amt = _factor;
        if (_isShift) {
            amt /= 2.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            _isShift = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            _isShift = false;
        }
        if (Input.GetKeyDown("y")) {
            _currentFOV += amt;
            Debug.Log(_currentFOV);
        } else if (Input.GetKeyDown("u")) {
            _currentFOV -= amt;
            Debug.Log(_currentFOV);
        } else if (Input.GetKeyDown("i")) {
            _currentFOV = _initialFOV;
        }
        Camera.main.fieldOfView = _currentFOV;


        Orthographic();


    }

    public void Orthographic() {
        
        Camera.main.orthographicSize = _currentOS;
        
        if (Input.GetKeyDown("o")){
            Camera.main.orthographic = !Camera.main.orthographic;
        }
        if (Input.GetKeyDown("p")){
            _currentOS ++; 
            Debug.Log(_currentOS);
        } else if (Input.GetKeyDown(KeyCode.LeftBracket)){
            _currentOS --;
            Debug.Log(_currentOS);
        }
    }
}