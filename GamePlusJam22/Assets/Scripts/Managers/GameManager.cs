using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game")]
    public static GameManager instance = null;
    [SerializeField] Slider loadingSlider;
    [SerializeField] private float loadingProgress;
    [SerializeField] List<AudioClip> scriptClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> soundClips = new List<AudioClip>();

    [Header("Script 1")]
    [SerializeField] private GameObject chair;
    [SerializeField] private GameObject wallImages;

    [Header("Script 2")]
    [SerializeField] private GameObject cardboard;
    [SerializeField] private GameObject moralChoice;

    [Header("Script 3")]
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject pipe;

    [Header("Script 4")]
    [SerializeField] private GameObject btnXP;
    [SerializeField] private Text xpTxt;
    [SerializeField] private GameObject floor;
    [SerializeField] private Material floorMaterial;

    [Header("Script 6")]
    [SerializeField] private GameObject ceaseItem;
    [SerializeField] private GameObject cease;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private GameObject creditsScreen;

    [Header("Instances")]
    private SoundManager soundManager;
    private UiManager uiManager;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        InitializeGame();
        StartCoroutine(ScriptsCoroutine());
    }

    void FixedUpdate()
    {
        loadingSlider.value = loadingProgress;

        if (loadingProgress < 600)
        {
            loadingProgress += Time.deltaTime;
        }
    }

    IEnumerator ScriptsCoroutine()
    {
        yield return new WaitForSeconds(5f);
        soundManager.PlayScript(scriptClips[0]); // Script 1
        yield return new WaitForSeconds(41f);
        soundManager.PlaySound(soundClips[4]);
        chair.SetActive(true);
        yield return new WaitForSeconds(14f);
        soundManager.PlayBackgroundMusic();

        yield return new WaitForSeconds(30f);
        wallImages.SetActive(true);
        yield return new WaitForSeconds(10f);
        soundManager.PlayScript(scriptClips[1]); // Script 2
        yield return new WaitForSeconds(8f);
        cardboard.SetActive(true);
        yield return new WaitForSeconds(40f);
        cardboard.GetComponent<Animator>().Play("ByeCaine");
        yield return new WaitForSeconds(45f);
        soundManager.PlaySound(soundClips[4]);
        moralChoice.SetActive(true);

        yield return new WaitForSeconds(15f);
        soundManager.PlayScript(scriptClips[2]); // Script 3
        yield return new WaitForSeconds(27f);
        soundManager.PlaySound(soundClips[4]);
        ball.SetActive(true);
        yield return new WaitForSeconds(27f);
        pipe.SetActive(true);
        soundManager.PlaySound(soundClips[5]);

        yield return new WaitForSeconds(15f);
        soundManager.PlayScript(scriptClips[3]); // Script 4
        yield return new WaitForSeconds(102f);
        floor.GetComponent<Renderer>().material = floorMaterial;
        yield return new WaitForSeconds(18f);
        soundManager.BackgroundMusicFadeOut();
        yield return new WaitForSeconds(36f);
        soundManager.BackgroundMusicFadeIn();
        yield return new WaitForSeconds(28f);
        soundManager.PlaySound(soundClips[4]);
        btnXP.SetActive(true);

        yield return new WaitForSeconds(12f);
        LevelUp();
        soundManager.PlayScript(scriptClips[4]); // Script 5
        yield return new WaitForSeconds(63f);
        soundManager.PauseBackgroundMusic();

        yield return new WaitForSeconds(14f);
        soundManager.PlayScript(scriptClips[5]); // Script 6
        soundManager.PlaySound(soundClips[3]);
        ceaseItem.SetActive(true);

        yield return new WaitForSeconds(15f);
        ceaseItem.SetActive(false);
        cease.SetActive(true);
        soundManager.PlayScript(scriptClips[6]); // Script 7
        yield return new WaitForSeconds(45f);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);
        creditsScreen.SetActive(true);
        yield return new WaitForSeconds(6f);
        uiManager.OnQuitBtn();

        yield return null;
    }

    void InitializeGame()
    {
        soundManager = SoundManager.instance;
        uiManager = UiManager.instance;
        loadingProgress = 0;
        loadingSlider.value = 0;
        chair.SetActive(false);
        wallImages.SetActive(false);
        cardboard.SetActive(false);
        moralChoice.SetActive(false);
        ball.SetActive(false);
        pipe.SetActive(false);
        btnXP.SetActive(false);
        ceaseItem.SetActive(false);
        blackScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void LevelUp()
    {
        xpTxt.text = "XP Level: 80";
    }
}
