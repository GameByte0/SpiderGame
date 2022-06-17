using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  [SerializeField] float camSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.D))
		{
      transform.position += Vector3.right*camSpeed;
		}
		else if (Input.GetKey(KeyCode.A))
		{
      transform.position += Vector3.left*camSpeed;
		}
    }
}
