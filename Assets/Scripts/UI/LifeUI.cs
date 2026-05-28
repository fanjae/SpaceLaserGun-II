using TMPro;
using UnityEditor;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private int life = 5;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text winLoseText;

    private bool isGameOver = false;

    private void Start()
    {
        UpdateLifeText();

        if (winLoseText != null)
            winLoseText.gameObject.SetActive(false); // 끄기
    }

    private void Update()
    {
        if (isGameOver && Input.anyKeyDown) // 게임 오버일때 아무키나 누르면 창 꺼짐
        {
            QuitGame();
        }
    }

    public void Damage()
    {
        if (isGameOver) return; // 게임 종료됐으면 데미지 X

        life--;
        UpdateLifeText(); // Life 재 업데이트

        if (life <= 0) GameOver();
    }

    private void UpdateLifeText() // Life 
    {
        lifeText.text = "Life : " + life;
    }

    private void GameOver() // 게임오버
    {
        isGameOver = true;

        if (winLoseText != null) 
        {
            winLoseText.gameObject.SetActive(true);
            winLoseText.text = "You Lose!\nPress any key to quit";
        }
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}