using UnityEngine;

public class BGManager : MonoBehaviour
{
    #region DEFAULT
    private Renderer rd_BG;
    private readonly Texture2D[] tx_BG = new Texture2D[5];
    public static int r, t;
    private Vector2 move_BG;

    void Awake()
    {
        r = Random.Range(0, 9);
        t = Random.Range(0, 5);

        rd_BG = GetComponent<Renderer>();

        for (int i = 0; i < 5; i++)
        {
            tx_BG[i] = Resources.Load("Sprites/Textures/BG/" + i + "") as Texture2D;
        }

        Texture2D t2d = tx_BG[t];
        rd_BG.material.mainTexture = t2d;
    }

    void Update()
    {
        #region MOVE BG
        if (r < 3)
        {
            // 0 1 2
            move_BG = new Vector2(Time.time * -0.5f, Time.time * 0.5f);
        }
        if (r == 3 || r == 4 || r == 5)
        {
            // 3 4 5
            move_BG = new Vector2(Time.time * 0.5f, Time.time * -0.5f);
        }
        if (r == 6 || r == 7)
        {
            // 6 7 
            move_BG = new Vector2(Time.time * 0.5f, Time.time * 0.5f);
        }
        if (r == 8)
        {
            // 8
            move_BG = new Vector2(Time.time * -0.5f, Time.time * -0.5f);
        }
        rd_BG.material.mainTextureOffset = move_BG;
        #endregion
    }
    #endregion
}