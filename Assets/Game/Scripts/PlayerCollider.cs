using UnityEngine;
using TMPro;

public class PlayerCollider : MonoBehaviour
{
    [Header("Camera")]
    public GameObject Statencamera;

    [Header("Canvas")]
    public Transform gameCanvas;
    public GameObject diamondEffect;

    [Header("Texts")]
    public TextMeshProUGUI diamondText;    
    public TextMeshProUGUI menuDiamondText;

    [Header("LastCubeColors")]
    public Color[] color;

    public static int lastCubeCount = 0;
    public static int diamondNumber;

    public static bool finishLineControl = false;

    bool finishPos= false;

    private void Start()
    {
        lastCubeCount = 0;
        menuDiamondText.text = PlayerPrefs.GetInt("diamond").ToString();

        mobileControl.leftRightControl = true;

        Debug.Log(finishLineControl);
        finishLineControl = false;
    }

    private void Update()
    {
        if(finishPos == true)
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-15f, transform.position.y, transform.position.z), 5 * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("diamond"))
        {
            soundManager.instance.DiamondSound();
            Destroy(other.gameObject);
            DiamondEffect();
        }
        if (other.gameObject.CompareTag("finishLine"))
        {
            Physics.gravity = new Vector3(0, -10, 0);

            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        }
        if (other.gameObject.CompareTag("obstacle") && other.gameObject.name == "lastCube")
        {
            // LEVEL COMPLETED BUT NOT İN DANCE AREA            

            

            int random = Random.Range(0, color.Length);
            other.gameObject.GetComponent<Renderer>().material.color = color[random];
            other.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = color[random];

            soundManager.instance.WinSound();
            finishPos = true;
            mobileControl.leftRightControl = false;
            finishLineControl = true;
            lastCubeCount++;
            Debug.Log(lastCubeCount); 
            
        }
        if (other.gameObject.CompareTag("dance"))
        {
           
            mobileControl.moveSpeed = 0;

            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Player"))
            {
                int random = Random.Range(0, 3);  // we have 3 different dance animation and choosing randomly

                if (random == 0)
                {
                    Debug.Log("dans1");
                    item.GetComponent<Animator>().Play("dance");

                }
                else if (random == 1)
                {
                    Debug.Log("dans2");
                    item.GetComponent<Animator>().Play("dance2");
                }
                else if (random == 2)
                {
                    Debug.Log("dans3");
                    item.GetComponent<Animator>().Play("dance3");
                }

                
               

            }
            Statencamera.GetComponent<Animator>().Play("cam2"); //switch Camera 2
            GameManager.instance.LevelCompleteActive(2);  // PLAYER WILL WATCH DANCE 2 SECONDS AFTER THAT COMPLETE PANEL WILL BE ACTIVE
        }
    }


   

    void DiamondEffect()
    {
        diamondNumber++;

        diamondEffect.GetComponent<Animator>().SetTrigger("diamond");        

        diamondText.text = diamondNumber.ToString();
        
    }

    public void setDiamond()
    {                              
        int newDiamondNumber = diamondNumber * lastCubeCount;
        PlayerPrefs.SetInt("diamond", newDiamondNumber);
       
    }

}
