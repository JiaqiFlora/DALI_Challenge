using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parabola : MonoBehaviour
{

    protected float animationTime;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            animationTime += Time.deltaTime;

        animationTime = animationTime % 3;

        transform.position = MathParabola.Parabola(transform.position, target.position, 2f, animationTime / 3f);
    }
}
