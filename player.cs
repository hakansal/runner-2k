using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] LayerMask _groundlayer;
    private float _gravity = -15f;
    private CharacterController _charactercontroller;
    private Vector3 _velocity;
    public bool _isgrounded;
    public float _horizontalinput;
    public float _speed;
    private Animator _anime;
    [SerializeField] private Transform[] _wallcheck;
    [SerializeField] AudioSource aud;
    bool _startbool = false;
    public GameObject button;
     public GameObject _GameManager;
    public GameObject pool;
    public ads _ads;

    void Start()
    {
        
        _charactercontroller = GetComponent<CharacterController>();
        _anime = GetComponent<Animator>();
        _GameManager.GetComponent<GameManager>();

    }
    void Update()
    {

         
        _horizontalinput = 1;
        transform.forward = new Vector3(_horizontalinput, 0, Mathf.Abs(_horizontalinput) - 1);
        _isgrounded = Physics.CheckSphere(transform.position, 0.1f, _groundlayer, QueryTriggerInteraction.Ignore);

        if (_isgrounded && _velocity.y < 0)
        {
            _velocity.y = 0;
        }
        else
        {
            _velocity.y = _velocity.y + _gravity * Time.deltaTime;
        }
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            if (_isgrounded && _touch.phase == TouchPhase.Began)
            {
                _velocity.y = _velocity.y + Mathf.Sqrt(-3 * _gravity);
                aud.Play();

            }
        }
        var blocked = false;
        foreach (var walcheck in _wallcheck)
        {
            if (Physics.CheckSphere(walcheck.position, 0.01f, _groundlayer, QueryTriggerInteraction.Ignore))
            {
                blocked = true;
                break;
            }
        }
        if (!blocked && _startbool == true)
        {
            _charactercontroller.Move(new Vector3(_horizontalinput, 0, 0) * _speed * Time.deltaTime);
            run();
        }

        _charactercontroller.Move(_velocity * Time.deltaTime);
    }
    public void startbutton()
    {
        
        _startbool = true;
        button.SetActive(false);
        _ads.GetComponent<ads>().isbannerload = true;
        
    }
  
    public void run()
    { 
        _anime.SetBool("start", true);
        _anime.SetBool("isground", _isgrounded);
        _anime.SetFloat("verticalspeed", _velocity.y);

    }
    void OnTriggerEnter(Collider other)
    { 
           
               

        
             
        if(other.gameObject.CompareTag("floor")) _GameManager.GetComponent<GameManager>().whendown();
        
    }
}
