using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
   

    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.Equals("Player"))
            {
                this.transform.parent = collision.transform;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.Equals("Player"))
            {
                this.transform.parent = null;
            }
        }


    
}
