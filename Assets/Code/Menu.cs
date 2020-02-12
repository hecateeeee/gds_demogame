using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Texture2D cursor;
    public Image fade;

    private void Awake () {
        var buttons = transform.Find("Buttons");

        var startbtn = buttons.Find("Start").GetComponent<Button>();
        startbtn.onClick.AddListener(() => { StartCoroutine(FadeScreen()); });

        var optionbtn = buttons.Find("Options").GetComponent<Button>();
        optionbtn.onClick.AddListener(ShowOptions);

        var quitbtn = buttons.Find("Quit").GetComponent<Button>();
        quitbtn.onClick.AddListener(QuitGame);

        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    private void StartGame () {
        SceneManager.LoadScene(1);
    }

    private IEnumerator FadeScreen () {
        float alpha = 0f;
        while (alpha < 1f) {
            alpha += Time.deltaTime / 2f;
            var c = fade.color;
            c.a = alpha;
            fade.color = c;
            yield return null;
        }

        StartGame();
    }

    private void QuitGame () {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void ShowOptions () {
        Debug.Log("Please implement me.");
    }
}
