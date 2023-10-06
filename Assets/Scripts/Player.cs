using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* private float _vertical;*/
    public float movementSpeed;
    private float _tempMovementSpeed;
    public float jumpForce;
    private float _tempJumpForce;

    public float reflectSpeed;
    private float _tempReflectSpeed;

    public float superJump;
    private float _tempSuperJump;

    public float runSpeed;
    private float _tempRunSpeed;

    [SerializeField] private Vector3 _startPos;

    private Transform _transform;
    private Rigidbody _rb;

    private float _startTime;
    private float _finishTime;

    public GameObject objectToActivateAndDeactivate;
    public GameObject secretPlatform;
    public GameObject secretPlatform2;
    public GameObject destroyBoss;
    public GameObject bulletT;
    public GameObject bulletT2;
    public GameObject bulletT3;
    public GameObject bulletT4;
    public GameObject bulletT5;
    public GameObject bulletT6;

    

    private void Awake()
    {
        _transform = transform;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _tempMovementSpeed = movementSpeed;
        _tempJumpForce = jumpForce;
        _tempReflectSpeed = reflectSpeed;
        _tempSuperJump = superJump;
        _tempRunSpeed = runSpeed;


        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector3(0, jumpForce, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = new Vector3(0, jumpForce, 0);
        }

        
    }

    void Move()
    {
        /*_vertical = Input.GetAxis("Vertical");*/
        _transform.position += new Vector3(0, 0, 1) * (movementSpeed * Time.deltaTime);
        
    }

    public void StopPlayer()
    {
        movementSpeed = 0;
        jumpForce = 0;
        StartCoroutine(ResetPos());
        
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(2.00f);
        _transform.position = _startPos;
        movementSpeed = _tempMovementSpeed;
        _startTime = Time.time;
        jumpForce = _tempJumpForce;
        secretPlatform.SetActive(false);
        secretPlatform2.SetActive(false);
        objectToActivateAndDeactivate.SetActive(true);
        destroyBoss.SetActive(true);
        bulletT.SetActive(true);
        bulletT2.SetActive(true);
        bulletT3.SetActive(true);
        bulletT4.SetActive(true);
        bulletT5.SetActive(true);
        bulletT6.SetActive(true);
        StopAllCoroutines();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            StopPlayer();
            Debug.Log("Bilinmeyen bir cisme çarptýnýz.");
        }
        
        if (collision.gameObject.CompareTag("Moon"))
        {
            StopPlayer();
            Debug.Log("Bir uyduya çarptýnýz.");
        }
        
        if (collision.gameObject.CompareTag("Neptune"))
        {
            StopPlayer();
            Debug.Log("Bir gezegene sert bir iniþ yaptýnýz ancak kurtulan olmadý.");
        }
        
        if (collision.gameObject.CompareTag("Reflect"))
        {
            movementSpeed = _tempReflectSpeed;
            Debug.Log("Bir solucan deliði sizi geri yönlendirdi.");
        }
        
        if (collision.gameObject.CompareTag("Gate1"))
        {
            StopPlayer();
            Debug.Log("Þüpheli bir cisme çarptýn.");
        }
            
        if (collision.gameObject.CompareTag("Stop"))
        {
            movementSpeed = 0;
            jumpForce = 0;
            objectToActivateAndDeactivate.SetActive(false);
        }
        
        if (collision.gameObject.CompareTag("Run"))
        {
            movementSpeed = _tempRunSpeed ;
            jumpForce = _tempSuperJump;
            objectToActivateAndDeactivate.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            StopPlayer();
            Debug.Log("Uzayda olmamasý gereken bir cisme çarptýn.");
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StopPlayer();
            Debug.Log("Kemgöze kurban gittin.");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("invisgate"))
        {
            secretPlatform.SetActive(true);
            Debug.Log("Bu da ne ???");
        }
        if (other.gameObject.CompareTag("Meteor"))
        {
            Debug.Log("Bunlar Meteor mu?");
            secretPlatform2.SetActive(true);
        }
    }
    private void OnTriggerEnter (Collider other)
    {
      
        if (other.gameObject.CompareTag("Boss"))
        {
            //Finish Bölümü
            StopPlayer();
            Debug.Log("Kemgözü kör ettin. Sayende evren kurtuldu.");
            GetFinishTime();
            destroyBoss.SetActive(false);
            bulletT.SetActive(false);
            bulletT2.SetActive(false);
            bulletT3.SetActive(false);
            bulletT4.SetActive(false);
            bulletT5.SetActive(false);
            bulletT6.SetActive(false);
            
        }
        
                
    }
    void GetFinishTime()
    {
        _finishTime = Time.time - _startTime;
        Debug.Log($"{_finishTime} Sürede tamamladýnýz.");
    }
   
}
