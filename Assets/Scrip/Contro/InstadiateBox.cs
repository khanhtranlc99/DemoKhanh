using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstadiateBox : MonoBehaviour
{
    public static InstadiateBox instadiate;
    public BoxPerent box;
    public List<BoxPerent> list;
    public GameObject[] gameObjects1;
    public bool wasOn;
    private void Awake()
    {
        instadiate = this;
        wasOn = true;
    }
    public IEnumerator _PlusBlox()
    {
        yield return new WaitForSeconds(0.5f);
        var x = Random.Range(-5, 5);
        var y = Random.Range(-3, 3);  
        Instantiate(box, new Vector3(x, y, 5), Quaternion.identity);
        list.Add(box);
        if( wasOn == true )
        {
            StartCoroutine(_PlusBlox());
        }
        else
        {
            StopCoroutine(_PlusBlox());
        }            

    }    
    public void _Pause()
    {
        StopCoroutine(_PlusBlox());
        wasOn = false;
        for (int i = 0; i < list.Count; i++)
        {
         
            list.Clear();
            Destroy(list[i].gameObject);
        }
        GameManager.instance.audio.Pause();
    }
    public void _Resuame()
    {
       StartCoroutine(_PlusBlox());
        wasOn = true;
        GameManager.instance.audio.Play();
    }    
}
