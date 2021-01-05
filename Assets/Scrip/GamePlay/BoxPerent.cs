using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPerent : MonoBehaviour
{
    public BoxChilrent[] box;
    public int flyBox;
    public float speed;
    public void Start()
    {
        flyBox = 200;
    }
    public void Update()
    {
        speed -= 0.1f;
        gameObject.transform.Translate(new Vector3(0, 0, speed)*Time.deltaTime);
    }
    private void OnMouseDown()
    {
        GameManager.instance._PlusScore();       
        box[0].rigidbody.AddForce(new Vector3(-flyBox, -flyBox, flyBox));
        box[1].rigidbody.AddForce(new Vector3(-flyBox, flyBox, flyBox));
        box[2].rigidbody.AddForce(new Vector3(flyBox, -flyBox, flyBox));
        box[3].rigidbody.AddForce(new Vector3(flyBox, flyBox, flyBox));
        for (int i = 0; i < box.Length; i++)
        {
            box[i].rigidbody.useGravity = true;
            StartCoroutine(box[i]._Destroy());
            StartCoroutine(_DestroyParent());
        }
     
    }

    private IEnumerator _DestroyParent()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance._PlusFase();
    }
}
