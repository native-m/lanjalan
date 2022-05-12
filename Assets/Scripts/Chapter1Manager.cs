using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Chapter1Manager : MonoBehaviour
{
    public static Chapter1Manager Instance;

    private Player player;
    public Vector3 PlayerInteractPosition { private set; get; } = new Vector3(-1.2f, -0.3f, -2.6f);

    public UnityEvent InteractCallbackEvent;
    private RPGTalk rpgTalk = null;
    private int mainStoryIndex = 0;

    private bool isOnMinigame = false;

    public Dictionary<string, NPCData> NPCDatabase { private set; get; } = new Dictionary<string, NPCData>()
    {
        {"KepalaDesa", new NPCData
            (
                new Vector3(-1.4f, -0.32f, -1.2f),
                new Quaternion(0.0f, 0.8f, 0.0f, 0.6f),
                "kepalaDesaStart",
                "kepalaDesaEnd",
                true
            )
        },
        {"Roro", new NPCData
            (
                new Vector3(0.8f, -0.32f, -1.1f),
                new Quaternion(0.0f, 1f, 0.0f, -0.2f),
                "defaultRoroStart",
                "defaultRoroEnd",
                false
            )
        },
    };

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        InteractCallbackEvent = new UnityEvent();
        InteractCallbackEvent.AddListener(PostInteractHandler);
    }

    private void Update()
    {
        if(isOnMinigame)
        {
            return;
        }

        if(rpgTalk == null)
        {
            rpgTalk = FindObjectOfType<RPGTalk>();
        }
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }

    public void StartInteract(string start, string end, bool isMainStory)
    {
        if(isMainStory)
        {
            mainStoryIndex++;
        }
        rpgTalk.NewTalk(start, end, InteractCallbackEvent);
    }

    private void PostInteractHandler()
    {
        player.PostInteractHandler();
        PlayerInteractPosition = player.transform.position;
        if(mainStoryIndex == 1)
        {
            SceneManager.LoadScene(1);
            isOnMinigame = true;
            mainStoryIndex++;
            NPCDatabase["KepalaDesa"].dialogueStart = "defaultKepalaDesaStart";
            NPCDatabase["KepalaDesa"].dialogueEnd = "defaultKepalaDesaEnd";
            NPCDatabase["KepalaDesa"].isMainStory = false;
            NPCDatabase["Roro"].isMainStory = true;
        }
        else if (mainStoryIndex == 3)
        {
            SceneManager.LoadScene(2);
            mainStoryIndex++;
            NPCDatabase["Roro"].position = new Vector3(2.97f, -0.32f, 1.47f);
        }
        else if (mainStoryIndex == 5)
        {
            SceneManager.LoadScene(3);
            mainStoryIndex++;
            NPCDatabase["Roro"].isMainStory = false;
        }
    }

    public void OutFromMinigame()
    {
        isOnMinigame = false;
    }
}
