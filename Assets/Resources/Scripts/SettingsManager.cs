using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    #region DEFAULT
    private AudioClip[] auClipMusic; // array of music
    private readonly AudioClip[] auClipSfx = new AudioClip[8]; // audios sfx  
    [Header("0 - AudioSource Music"), Space(1), Header("1 - AudioSource Sfx"), Space(1), Header("2 - Toggle Music"), Space(1), Header("3 - Toggle Sfx"), Space(1), Header("4 - Slider Music"), Space(1), Header("5 - Slider Sfx")]
    public GameObject[] stMasterManager; // settings master manager
    public static bool check_Music; // check play music
    private int random_Sfx; // random sfx (audio)

    /// <summary>
    /// stMasterManager0 - auMusic
    /// stMasterManager1 - Sfx
    /// stMasterManager2 - tgMusic
    /// stMasterManager3 - tgSfx
    /// stMasterManager4 - slVolumeMusic
    /// stMasterManager5 - slVolumeAudio
    /// </summary>

    void Start()
    {
        // load states
        SaveStates();

        #region AUDIO COMPONENTS
        // get components audio source  and load audios
        stMasterManager[0].GetComponent<AudioSource>();
        stMasterManager[1].GetComponent<AudioSource>();
        auClipMusic = Resources.LoadAll<AudioClip>("Audios/Musics");

        for (int i = 0; i < 8; i++)
        {
            auClipSfx[i] = Resources.Load<AudioClip>("Audios/Sfxs/clicks/" + i + "");
        }

        random_Sfx = Random.Range(0, 8);
        AudioClip sfx = auClipSfx[random_Sfx];

        stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
        stMasterManager[0].GetComponent<AudioSource>().Play();
        check_Music = true;
        #endregion
    }

    void Update()
    {
        // check out if music not playing
        if (!stMasterManager[0].GetComponent<AudioSource>().isPlaying)
        {
            stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
            stMasterManager[0].GetComponent<AudioSource>().Play();
            check_Music = !check_Music;
            BGManager.r = Random.Range(0, 9);
            BGManager.t = Random.Range(0, 5);
        }
    }
    #endregion

    #region CHECK STATES 
    public void SettingsStates(int i)
    {
        switch (i)
        {
            // music
            case 0:
                if (stMasterManager[2].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("MUSIC", 0);
                    stMasterManager[0].GetComponent<AudioSource>().mute = true;
                    stMasterManager[4].GetComponent<Slider>().interactable = false;
                }
                else
                {
                    PlayerPrefs.SetInt("MUSIC", 1);
                    stMasterManager[0].GetComponent<AudioSource>().mute = false;
                    stMasterManager[4].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume music
            case 1:
                stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEMUSIC", stMasterManager[4].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;

            // audio
            case 2:
                if (stMasterManager[3].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("AUDIO", 0);
                    stMasterManager[1].GetComponent<AudioSource>().mute = true;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = false;
                    stMasterManager[5].GetComponent<Slider>().interactable = false;

                }
                else
                {
                    PlayerPrefs.SetInt("AUDIO", 1);
                    stMasterManager[1].GetComponent<AudioSource>().mute = false;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = true;
                    stMasterManager[1].GetComponent<AudioSource>().PlayOneShot(auClipSfx[random_Sfx]);
                    stMasterManager[5].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume audio
            case 3:
                stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEAUDIO", stMasterManager[5].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;
        }
    }

    void SaveStates()
    {
        stMasterManager[4].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEMUSIC"); // SAVE SETTINGS VOLUME OF MUSIC
        stMasterManager[5].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEAUDIO"); // SAVE SETTINGS VOLUME OF AUDIO

        // SAVE MUSIC SETTINGS
        if (PlayerPrefs.GetInt("MUSIC") == 0)
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = false;
            stMasterManager[0].GetComponent<AudioSource>().mute = true;
            stMasterManager[4].GetComponent<Slider>().interactable = false;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = true;
            stMasterManager[0].GetComponent<AudioSource>().mute = false;
            stMasterManager[4].GetComponent<Slider>().interactable = true;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }

        // SAVE AUDIO SETTINGS
        if (PlayerPrefs.GetInt("AUDIO") == 0)
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = false;
            stMasterManager[1].GetComponent<AudioSource>().mute = true;
            stMasterManager[5].GetComponent<Slider>().interactable = false;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = true;
            stMasterManager[1].GetComponent<AudioSource>().mute = false;
            stMasterManager[5].GetComponent<Slider>().interactable = true;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
    }
    #endregion
}