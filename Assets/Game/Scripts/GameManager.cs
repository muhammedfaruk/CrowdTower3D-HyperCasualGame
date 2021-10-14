using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("PLAYER SPEED")]
    [SerializeField]
    private int PlayerMoveSpeed;


    [Header("OTHER SETTİNGS")]
    [SerializeField]
    private GameObject[] players ;
    [SerializeField]
    private int firstActivePlayerNum;
    [SerializeField]
    private GameObject playerObject;

    [Header("PANELS")]
    [SerializeField]
    private GameObject inGamePanel;
    [SerializeField]
    private GameObject MenuPanel;
    [SerializeField]
    private GameObject GameOverPanel;
    [SerializeField]
    private GameObject levelCompletePanel;

    

    [Header("Slider")]    
    public GameObject Player;
    public Slider levelSlider;  
    private GameObject finishLine;
    float maxDistance;
    private float sliderValue;

    [Header("Fantastic Images")]
    public Sprite[] sprites;
    public Image FantasticImage;

    GameObject cam;
    public static int playerNumber;
    private int velocityValue = 300;

    bool functionCallOnlyOnce = false;

    private void Awake()
    {
      if(instance == null)
        {
            instance = this;
        }    
    }

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        finishLine = GameObject.FindGameObjectWithTag("finishLine");
        maxDistance = distanceValue();
        levelSlider.maxValue = 1;
        

        AllPlayerDisabled();
        FirstActivePlayers();

        playerNumber = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    private void Update()
    {
        GameFinishControl();
        distanceSlider();
    }

    void GameFinishControl()
    {
        if (playerNumber <= 0)
        {
            if(PlayerCollider.finishLineControl == false)
            {
                // GAME OVER
                if(functionCallOnlyOnce == false)
                {
                    FindObjectOfType<AdManager>().ShowAdmobInterstitial();

                    soundManager.instance.GameOverSound();
                    mobileControl.moveSpeed = 0;
                    PlayerCollider.diamondNumber = 0;
                    playerObject.GetComponent<mobileControl>().enabled = false;

                    inGamePanel.SetActive(false);
                    GameOverPanel.SetActive(true);

                    functionCallOnlyOnce = true;
                }
                
            }
            else 
            {
                // LEVEL COMPLETED
              if(functionCallOnlyOnce == false)
                {
                    StartCoroutine(LevelCompleted(0));                   
                    functionCallOnlyOnce = true;
                }
                
            }
           
        }
               

    }

    public IEnumerator RandomSprite()
    {

        int rnd = Random.Range(0, sprites.Length);

        FantasticImage.sprite = sprites[rnd];

        FantasticImage.gameObject.SetActive(true);
        FantasticImage.gameObject.GetComponent<RectTransform>().DOScale(0.34f, 0.5f).SetEase(Ease.OutBack);

        yield return new WaitForSeconds(2);
        FantasticImage.gameObject.GetComponent<RectTransform>().DOScale(0.10f, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(0.5f);
        FantasticImage.gameObject.SetActive(false);
        
    }

    public void LevelCompleteActive(int second)
    {
        StartCoroutine(LevelCompleted(second));
    }

    public IEnumerator LevelCompleted(int second)
    {
        // SHOW ADS
        mobileControl.moveSpeed = 0;

        yield return new WaitForSeconds(second);

        FindObjectOfType<AdManager>().ShowAdmobRewardVideo();

        yield return new WaitForSeconds(1.5f);

        

        cam.transform.GetChild(0).gameObject.SetActive(true); // confeti effect
        

        FindObjectOfType<PlayerCollider>().setDiamond();   // multiply diamond number

        inGamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);  // complete canvas panel active 

        FindObjectOfType<starControl>().whichStar(PlayerCollider.lastCubeCount);          
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void StartTheGame()
    {        
        MenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        mobileControl.moveSpeed = PlayerMoveSpeed;

       
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelCompletePanelActive()
    {
        inGamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);       
        
    }

   

    #region SliderControl
    void distanceSlider()
    {

        if (Player.transform.position.z <= maxDistance && Player.transform.position.z <= finishLine.transform.position.z) // arasında mı?
        {
            float distance = 1 - (distanceValue() / maxDistance);
            addSlider(distance);
        }
    }

    float distanceValue()
    {
        return Vector3.Distance(Player.transform.position, finishLine.transform.position);

    }
    void addSlider(float deger)
    {
        levelSlider.value = deger;
    }
    #endregion



    #region PlayerSpawnControls
    void AllPlayerDisabled()
    {
        GameObject[] findPlayer = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject item in findPlayer)
        {
            item.SetActive(false);
        }
    }

    void FirstActivePlayers()
    {
        for (int i = 0; i < firstActivePlayerNum; i++)
        {     
            players[i].SetActive(true);
        }
    }

    public void ActivePlayerControl(int value)
    {                
        playerNumber += value;

        

        if(playerNumber <= 0)
        {
            AllPlayerDisabled();
            Debug.Log("Game Over");
        }
        else
        {
            AllPlayerDisabled();

            for (int i = 0; i < playerNumber; i++)
            {
                players[i].GetComponent<Rigidbody>().velocity = Vector3.up * velocityValue * Time.deltaTime;
                players[i].gameObject.SetActive(true);
            }

        }
      
    }

    public void ActivePlayerControl2(int value)
    {
        int newPlayerNumber = playerNumber / value;

        playerNumber = newPlayerNumber;

        
        if (Mathf.Round(newPlayerNumber) <= 0)
        {
            AllPlayerDisabled();
            Debug.Log("Game Over");
        }
        else
        {
            AllPlayerDisabled();

            for (int i = 0; i < Mathf.Round(newPlayerNumber); i++)
            {
                players[i].GetComponent<Rigidbody>().velocity = Vector3.up * velocityValue * Time.deltaTime;
                players[i].gameObject.SetActive(true);
            }

        }

      

    }

    public void ActivePlayerControl3(int value)
    {
        int newPlayerNumber = playerNumber * value;

        playerNumber = newPlayerNumber;

        

        if (newPlayerNumber <= 0)
        {
            AllPlayerDisabled();
            Debug.Log("Game Over");
        }
        else
        {
            AllPlayerDisabled();

            for (int i = 0; i < newPlayerNumber; i++)
            {
                players[i].gameObject.SetActive(true);                
                players[i].GetComponent<Rigidbody>().velocity = Vector3.up * velocityValue * Time.deltaTime;
            }

        }
       

    }
    #endregion




}
