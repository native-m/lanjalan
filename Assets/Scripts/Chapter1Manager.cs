using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Chapter1Manager : MonoBehaviour
{
    public static Chapter1Manager Instance;

    private Player player;

    public UnityEvent InteractCallbackEvent;
    [SerializeField] private RPGTalk rpgTalk;

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
        print(player.transform.position);
    }

    private void Start()
    {
        InteractCallbackEvent = new UnityEvent();
        InteractCallbackEvent.AddListener(PostInteractHandler);
    }

    public void StartInteract(string start, string end)
    {
        rpgTalk.NewTalk(start, end, InteractCallbackEvent);
    }

    private void PostInteractHandler()
    {
        player.PostInteractHandler();
    }
}
