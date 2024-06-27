using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainHandler : MonoBehaviour
{
    [SerializeField] private Button playAgain;

    public int world { get; private set; }
    public int stage { get; private set; }

    private void Awake()
    {
        playAgain.onClick.AddListener(() => PlayAgain(1, 1));
    }

    //public void PlayAgain() => SceneManager.LoadScene("LevelScene");

    public void PlayAgain(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }
}
