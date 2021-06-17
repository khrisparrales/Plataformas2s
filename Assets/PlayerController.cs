using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float runspeed=2;
    public float jumpspeed = 3;
    public float failmultiplier=0.5f;
    public float lowjumpmultiplier = 1f;

    public bool betterjump=false;
     bool miradadefaul = true;
    Rigidbody2D rigibody;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // mousemove();
        movimiento();
    }
    void orientacion(float inputmov)
    {
        if ((miradadefaul == true && inputmov < 0) || (miradadefaul == false && inputmov > 0))
        {
            miradadefaul = !miradadefaul;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    void movimiento()
    {
        if (Input.GetKey("d")||Input.GetKey("right"))
        {
            rigibody.velocity = new Vector2( runspeed, rigibody.velocity.y);
        }else if(Input.GetKey("a") || Input.GetKey("left")){
            rigibody.velocity = new Vector2(-runspeed, rigibody.velocity.y);
        }else{
            rigibody.velocity = new Vector2(0, rigibody.velocity.y);
        }
        if(Input.GetKey("space")&&Checkground.isGrounded){
            rigibody.velocity=new Vector2(rigibody.velocity.x,jumpspeed );
        }
    if(betterjump){
            if (rigibody.velocity.y < 0)
            {
rigibody.velocity+=Vector2.up*Physics2D.gravity.y*(failmultiplier)*Time.deltaTime;
            }
            if (rigibody.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigibody.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultiplier) * Time.deltaTime;
            }
    }
        // float inputmovimientohori = Input.GetAxis("Horizontal");
        // if(inputmovimientohori>=1)
        // {
        //     rigibody.velocity = new Vector2( runspeed, rigibody.velocity.y);
        // }else if(inputmovimientohori <= -1){
        //     rigibody.velocity = new Vector2(-runspeed, rigibody.velocity.y);
        // }else{
        //     rigibody.velocity = new Vector2(0, rigibody.velocity.y);
        // }

            // // float inputmovimientover = Input.GetAxis("Vertical");    
            // // rigibody.velocity = new Vector2( rigibody.velocity.x,inputmovimientover * velocidad);
            // orientacion(inputmovimientohori);
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     rigibody.AddForce(Vector2.up * jumpspeed);
            // }
    }
}
