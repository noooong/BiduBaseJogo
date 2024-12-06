using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoMuro : MonoBehaviour
{
    GameObject Bidu;
    [SerializeField]int LayerFrente, LayerTras;
    SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        Bidu = BiduController.Instance.gameObject;
        StartCoroutine(Layers());
    }

   
    void Update()
    {
        
    }

    IEnumerator Layers()
    {
        if(transform.position.y < Bidu.transform.position.y)
        {
            spriteRender.sortingOrder = LayerFrente;
        }
        else
        {
            spriteRender.sortingOrder = LayerTras;
        }
        yield return new WaitForSeconds (0.3f);
        StartCoroutine(Layers());

    }
}
