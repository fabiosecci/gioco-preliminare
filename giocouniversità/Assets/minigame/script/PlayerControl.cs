using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float jumpForce;
    public float speed;
    public float delayJump;
    public float gravity = 9.81f;
    private int OneHeart=36;
    public float HeartSize;
    public float HeartSize2;
    public float pushPower = 1;
    public float jumpInput = 0;
    public float slopelimitcar = 30;

    public float coolDownTime = 0.5f;
    private float nextFire;  
    public GameObject bullet;
    public Transform spawn;
    public Image hearts;
    public Image hearts2;
    public Text counText;
    public Text winText;

    public CameraControl Cam;


    // private bool isOnGround;

    private int count;
    private Rigidbody rb;
    private CharacterController controller;
    private Vector3 movement;

    // Use this for initialization
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

        count = 0;
        SetCountText();
        winText.text = "";
    }
    void Update()
    {

        float movementH = Input.GetAxis("Horizontal");
        float movementV = Input.GetAxis("Vertical");
        
        Vector3 forwardMovement = transform.forward * movementV;
        Vector3 rightMovement = transform.right * movementH;

        if (controller.isGrounded)
        {
                   
            if (controller.SimpleMove((forwardMovement + rightMovement) * speed)==true)
            {
                CameraControl cam = Cam.GetComponent<CameraControl>();

                cam.Ruota();

            }
        }


        if (Input.GetButton("Jump"))
        {
            jumpInput = 1;
            controller.slopeLimit = 90;
            controller.Move(Vector3.up*jumpForce*Time.deltaTime);
        }
        else
        {
            jumpInput = 0;
            controller.slopeLimit = slopelimitcar;            
        }
        
        controller.SimpleMove((forwardMovement + rightMovement)*speed);
        
        
        
        
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + coolDownTime;

            

            Instantiate(bullet, spawn.position, spawn.rotation);
        }

    }
    /*
        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float jump = 0.0f;

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f , moveVertical);
            Vector3 movement= (moveVertical * transform.forward) + (moveHorizontal * transform.right);
            movement = movement.normalized * speed;

            rb.AddForce(movement * speed);
            ////qui
            if (Mathf.Abs(moveVertical)   > inputDelay)
            {
                //rBody.velocity = transform.forward * fowardInput * fowardVel;


            }
            else
            {
               // rb.velocity = transform.TransformDirection(movement);
            }




            if(isOnGround){

                jump = Input.GetAxis("Jump") ;
                Vector3 jumpVector = new Vector3(0f, jump * jumpForce, 0f);
                rb.AddForce(jumpVector, ForceMode.Impulse);

                if (Input.GetKey("space"))
                {
                    isOnGround = false;
                }

                if (Input.GetKey("g"))
                {

                }

            }

        }*/

        private void OnTriggerEnter(Collider other)
        {
            TakeTriggerDamage(other);
            TakeHeart(other);       
        } 

            private void OnCollisionEnter(Collision collision)
        {
            //isOnGround = true;
            TakeCollisionDamage(collision);
        } /*

        private void OnCollisionStay(Collision collision)
        {

        }  

        void delay()
        {
            isOnGround = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            //jumpForce = 10;
            //isOnGround = false;
        }*/
   




    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
      
        if (rb == null || rb.isKinematic || hit.gameObject.CompareTag("Bullet"))
        {
            return;
        }

        Vector3 pushDir = new Vector3(controller.velocity.x, controller.velocity.y, controller.velocity.z);
        rb.velocity = pushDir * pushPower;

    }


    void TakeTriggerDamage(Collider other)
    {
        float damage=0;

        if (other.gameObject.CompareTag("Enemy"))
        {
            damage = 1;
            TakeDamage(damage);
        }     
    } 

    void TakeCollisionDamage(Collision other)
    {
        float damage = 0;

        if (other.gameObject.CompareTag("Bullet"))
        {
            damage = 1;
            TakeDamage(damage);
        }
    }

    void TakeDamage(float damage)
    {

        if (HeartSize > 4 && HeartSize2 == 4)
        {
            HeartSize = HeartSize - damage * OneHeart;
            hearts.rectTransform.SetSizeWithCurrentAnchors(0, HeartSize);
            count = count - 1;
            SetCountText();
        }

        if (HeartSize2 > 4 && HeartSize == 10 * OneHeart + 4)
        {
            HeartSize2 = HeartSize2 - damage * OneHeart;
            hearts2.rectTransform.SetSizeWithCurrentAnchors(0, HeartSize2);

            count = count - 10;
        }
    }


    void TakeHeart(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            JumpCandy pippo;
            pippo=other.gameObject.GetComponent<JumpCandy>();
            
            
            if (pippo.taken == false) {
                pippo.taken = true;
                count = count + 1; 
            }
            //isOnGround = true;
                
            SetCountText();


            if (HeartSize2 < 10 * OneHeart && HeartSize == 10 * OneHeart + 4)
            {
                HeartSize2 = HeartSize2 + OneHeart;
                hearts2.rectTransform.SetSizeWithCurrentAnchors(0, HeartSize2);
            }

            if (other.gameObject.CompareTag("PickUp") && HeartSize < 10 * OneHeart + 4)
            {               
                HeartSize = HeartSize + OneHeart;                        
                hearts.rectTransform.SetSizeWithCurrentAnchors(0, HeartSize);
            }       
        }        
    }


    void SetCountText()
    {
        counText.text = "Count " + count.ToString();

        if (count >= 31)
        {
            winText.text = "YOU WIN!!!";
        }
    }
} 
                // other.gameObject.SetActive(false);
                //jumpForce = 10;
                //Invoke("deley", delayJump * Time.deltaTime);