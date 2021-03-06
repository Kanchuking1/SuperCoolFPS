﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PostProcessProfile gameMenu;
    ColorGrading co;
    DepthOfField dp;

    float redValue;
    float coValue;
    float dpValue;
    public bool playerDead;
    public Color normalColorFilter;
    public Color deadColorFilter;
    Color tempColor;

    public GameObject gameOverScreen;
    public Text[] buttons = new Text[4];
    public Color initialTextAlpha;
    public Color finalTextAlpha;
    Color tempTextAlpha;
    public Image crosshair;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.TryGetSettings<ColorGrading>(out co);
        gameMenu.TryGetSettings<DepthOfField>(out dp);
        dp.focusDistance.value = 5.6f;
        co.temperature.value = -10f;
        co.saturation.value = 32;
        coValue = -32f;
        playerDead = false;
        dpValue = 5.6f;
        tempColor = normalColorFilter;
        co.colorFilter.value = tempColor;
        tempTextAlpha = initialTextAlpha;
        crosshair.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerDead)
        {
            gameOverScreen.SetActive(true);
            crosshair.enabled = false;
            //Debug.Log("works" + Mathf.Lerp(20f, 100f, 0.5f));
            tempColor = Color.Lerp(tempColor, deadColorFilter, Time.deltaTime * 32f);
            tempTextAlpha = Color.Lerp(tempTextAlpha, finalTextAlpha, Time.deltaTime * 32f);
            coValue = Mathf.Lerp(coValue, 64f, Time.deltaTime * 32f);
            dpValue = Mathf.Lerp(dpValue, 0.1f, Time.deltaTime * 32f);
            DeathMenu(coValue, dpValue, tempColor, tempTextAlpha);
        }
    }

    void DeathMenu(float cgvalue, float dfvalue, Color redvalue, Color alpha)
    {

        gameMenu.TryGetSettings<ColorGrading>(out co);
        gameMenu.TryGetSettings<DepthOfField>(out dp);
        dp.focusDistance.value = dfvalue;
        co.temperature.value = cgvalue;
        co.saturation.value = cgvalue;
        co.colorFilter.value = redvalue;

        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Text>().color = alpha;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PauseMenu()
    {
        //TODO
    }
}