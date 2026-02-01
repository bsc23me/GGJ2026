using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;

    public static AudioManager Instance {  get { return instance; } }

    private AudioSource audioSource;

    [SerializeField] private AudioClip muffledMusic;
    [SerializeField] private AudioClip mainMusic;

    private void Awake()
    {
        if(instance == null)
            instance = this;
       DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = muffledMusic;
        //audioSource.Play();
        //audioSource.loop = true;
    }

    public void StartGame()
    {
        audioSource.clip = mainMusic;
    }
}
