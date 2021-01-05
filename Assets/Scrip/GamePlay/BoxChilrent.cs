using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChilrent : MonoBehaviour
{
    public Rigidbody rigidbody;

   public IEnumerator _Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }    


}
