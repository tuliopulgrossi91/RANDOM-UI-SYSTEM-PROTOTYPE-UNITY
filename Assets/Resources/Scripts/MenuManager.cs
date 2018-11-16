using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    #region DEFAULT
    public GameObject[] elements;
    [Header("Settings"), Space(1), Header("0 - Panel Base"), Space(1), Header("1 - Checkmark Toggle Music"), Space(1), Header("2 - Checkmark Toggle Sfx"), Space(1), Header("3 - Handle Slider Music"), Space(1), Header("4 - Handle Slider Sfx")]
    public GameObject[] settings;
    private bool check; // check panel
    private readonly string[] painel_Title = new string[4] { "Select", "Settings", "Credits", "Exit" };
    private readonly Sprite[] sprites_UI_0 = new Sprite[11]; // array sprites ui 0
    private readonly Sprite[] sprites_UI_1 = new Sprite[11]; // array sprites ui 1
    private readonly Sprite[] sprites_UI_2 = new Sprite[11]; // array sprites ui 2
    private readonly Sprite[] sprites_UI_3 = new Sprite[11]; // array sprites ui 3
    private readonly Sprite[] sprites_UI_4 = new Sprite[11]; // array sprites ui 4
    private readonly Font[] fonts = new Font[11]; // array fonts
    private Font f; // receive a new font
    private Sprite s; // receive a new sprite
    private int random_Color, sprite_Random; // random color and sprite

    void Start()
    {
        #region SET RANDOM FONT
        for (int i = 0; i < 11; i++)
        {
            fonts[i] = Resources.Load("Fonts/" + i + "") as Font;
        }
        f = fonts[Random.Range(0, 11)];
        #endregion

        #region SET RANDOM SPRITES
        random_Color = Random.Range(0, 5);
        Debug.Log("Random Color: " + random_Color);

        if (random_Color == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                sprites_UI_0[i] = Resources.Load<Sprite>("Sprites/UI/0/" + i + "");
            }

            settings[0].GetComponent<Image>().sprite = sprites_UI_0[7];
            settings[3].GetComponent<Image>().sprite = sprites_UI_0[8];
            settings[4].GetComponent<Image>().sprite = sprites_UI_0[8];
            sprite_Random = Random.Range(0, 7);
            s = sprites_UI_0[sprite_Random];
        }

        if (random_Color == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                sprites_UI_1[i] = Resources.Load<Sprite>("Sprites/UI/1/" + i + "");
            }

            settings[0].GetComponent<Image>().sprite = sprites_UI_1[7];
            settings[3].GetComponent<Image>().sprite = sprites_UI_1[8];
            settings[4].GetComponent<Image>().sprite = sprites_UI_1[8];
            sprite_Random = Random.Range(0, 7);
            s = sprites_UI_1[sprite_Random];
        }

        if (random_Color == 2)
        {
            for (int i = 0; i < 11; i++)
            {
                sprites_UI_2[i] = Resources.Load<Sprite>("Sprites/UI/2/" + i + "");
            }

            settings[0].GetComponent<Image>().sprite = sprites_UI_2[7];
            settings[3].GetComponent<Image>().sprite = sprites_UI_2[8];
            settings[4].GetComponent<Image>().sprite = sprites_UI_2[8];
            sprite_Random = Random.Range(0, 7);
            s = sprites_UI_2[sprite_Random];
        }

        if (random_Color == 3)
        {
            for (int i = 0; i < 11; i++)
            {
                sprites_UI_3[i] = Resources.Load<Sprite>("Sprites/UI/3/" + i + "");
            }

            settings[0].GetComponent<Image>().sprite = sprites_UI_3[7];
            settings[3].GetComponent<Image>().sprite = sprites_UI_3[8];
            settings[4].GetComponent<Image>().sprite = sprites_UI_3[8];
            sprite_Random = Random.Range(0, 7);
            s = sprites_UI_3[sprite_Random];
        }

        if (random_Color == 4)
        {
            for (int i = 0; i < 11; i++)
            {
                sprites_UI_4[i] = Resources.Load<Sprite>("Sprites/UI/4/" + i + "");
            }

            settings[0].GetComponent<Image>().sprite = sprites_UI_4[7];
            settings[3].GetComponent<Image>().sprite = sprites_UI_4[8];
            settings[4].GetComponent<Image>().sprite = sprites_UI_4[8];
            sprite_Random = Random.Range(0, 7);
            s = sprites_UI_4[sprite_Random];
        }
        #endregion

        #region LOAD FONT AND SPRITE
        for (int j = 1; j < 18; j++)
        {
            elements[j].GetComponent<Text>().font = f;
        }

        for (int j = 20; j < 32; j++)
        {
            elements[j].GetComponent<Button>().GetComponent<Image>().sprite = s;
        }
        #endregion
    }

    void Update()
    {
        Check_Toggles();
    }

    #region UI MANAGER
    public void ButtonAction(int i)
    {
        #region CLICK MODE
        // button back = 0
        if (check == false)
        {
            // panel true
            check = !check;
            elements[0].SetActive(check);
        }
        else
        {
            // panel false
            check = !check;
            elements[0].SetActive(check);
        }
        #endregion

        #region SELECT MODE
        if (i >= 0)
        {   // change text title prefab
            elements[6].GetComponent<Text>().text = "" + painel_Title[i];
            elements[13].GetComponent<Text>().text = "Back";
            elements[12].GetComponent<Text>().text = "";
            elements[20].SetActive(false);

            // select
            if (i == 0)
            {
                elements[18].SetActive(true);
                elements[19].SetActive(false);
                elements[12].SetActive(false);
            }
            // settings
            if (i == 1)
            {
                elements[18].SetActive(false);
                elements[19].SetActive(true);
                elements[12].SetActive(false);
            }
            // credits
            if (i == 2)
            {
                elements[18].SetActive(false);
                elements[19].SetActive(false);
                elements[12].SetActive(true);
                elements[12].GetComponent<Text>().text = "Programmer" + "\n" + "by Tulio Pulgrossi" + "\n" + "Sfxs by Chiptone" + "\n" + "Assets by Kenney" + "\n" + "Music by Eric Matyas" + "\n" + "www.soundimage.org";
            }
            // exit
            if (i == 3)
            {
                elements[18].SetActive(false);
                elements[19].SetActive(false);
                elements[12].SetActive(true);
                elements[12].GetComponent<Text>().text = "Are you sure?";
                elements[20].SetActive(true);
                elements[13].GetComponent<Text>().text = "No";
            }
            // confirm exit
            if (i == 4)
            {
                Application.Quit();
            }
        }
        #endregion
    }

    public void Reset()
    {
        //reload scene
        Scene game = SceneManager.GetActiveScene();
        SceneManager.LoadScene(game.buildIndex);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    #region CHECK TOGGLES
    void Check_Toggles()
    {
        #region TOGGLE MUSIC
        if (settings[5].GetComponent<Toggle>().isOn == false)
        {
            if (random_Color == 0)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_0[9];
            }
            if (random_Color == 1)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_1[9];
            }
            if (random_Color == 2)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_2[9];
            }
            if (random_Color == 3)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_3[9];
            }
            if (random_Color == 4)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_4[9];
            }
        }
        else
        {
            if (random_Color == 0)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_0[10];
            }
            if (random_Color == 1)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_1[10];
            }
            if (random_Color == 2)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_2[10];
            }
            if (random_Color == 3)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_3[10];
            }
            if (random_Color == 4)
            {
                settings[1].GetComponent<Image>().sprite = sprites_UI_4[10];
            }
        }
        #endregion

        #region TOGGLE SFX
        if (settings[6].GetComponent<Toggle>().isOn == false)
        {
            if (random_Color == 0)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_0[9];
            }
            if (random_Color == 1)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_1[9];
            }
            if (random_Color == 2)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_2[9];
            }
            if (random_Color == 3)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_3[9];
            }
            if (random_Color == 4)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_4[9];
            }
        }
        else
        {
            if (random_Color == 0)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_0[10];
            }
            if (random_Color == 1)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_1[10];
            }
            if (random_Color == 2)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_2[10];
            }
            if (random_Color == 3)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_3[10];
            }
            if (random_Color == 4)
            {
                settings[2].GetComponent<Image>().sprite = sprites_UI_4[10];
            }
        }
        #endregion
    }
    #endregion  
    #endregion
}