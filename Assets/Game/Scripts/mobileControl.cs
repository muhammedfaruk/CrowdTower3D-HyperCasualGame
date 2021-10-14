using UnityEngine;

public class mobileControl : MonoBehaviour
{
    [Header("MovingSpeed")]
    public static float moveSpeed = 0;

    [Header("LeftRight Control")]
    [SerializeField] private float speed;
    [SerializeField] private float smoothness;

    [Space()]
    
    float firstPos,lastPos;
    float distance;
    Vector3 pos;


    public static bool leftRightControl = true;

    void Update()
    {
        move();
        xClamp();
    }

    void move()
    {

        if(leftRightControl == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition.x;
            }

            if (Input.GetMouseButton(0))
            {
                lastPos = Input.mousePosition.x;
                distance = (lastPos - firstPos) / smoothness;

            }

        }
       

        transform.Translate(distance * Time.deltaTime * speed, 0, moveSpeed * Time.deltaTime);
    }

    
    void xClamp()
    {
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -20.3f, -11.5f);
        transform.position = pos;

    }

   
    
}
