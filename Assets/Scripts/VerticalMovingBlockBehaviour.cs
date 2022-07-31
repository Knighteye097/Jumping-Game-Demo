using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingBlockBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA;

    [SerializeField]
    private Transform _pointB;

    [SerializeField]
    private float _step = 5;

    private bool _switching = false;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = _pointA.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _step * Time.deltaTime);
        }

        else if(_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _step * Time.deltaTime);
        }

        if(transform.position == _pointA.position)
        {
            _switching = false;
        }

        else if(transform.position == _pointB.position)
        {
            _switching = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }   

        if(other.tag == "Collectible1")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
