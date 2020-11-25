using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    /* I changed this variable gravity from the PauseMenu script change 
       it if it was not the correct way
    */
    public static float gravity = 1;
    public float gravityTime = 1f;
    public float gravityScale = 0.1f;

    public WeightBar weightBar;

    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeGravity());
    }

    
    void FixedUpdate()
    {
        rb2D.gravityScale = gravity;
    }

    public void AddGravity(float value)
    {
        gravity += value;
        weightBar.SetSliderValue(gravity);
    }

    IEnumerator changeGravity()
    {
        bool run = true;
        while (run)
        {
            if (gravity > 0)
            {
                yield return new WaitForSeconds(gravityTime);
                gravity -= gravityScale;
                weightBar.SetSliderValue(gravity);
            }
            else if (gravity <= 0)
            {

                Debug.Log("Game over!");
                run = false;
            }
        }
    }
}
