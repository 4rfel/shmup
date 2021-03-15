using UnityEngine;
using UnityEngine.UI;

public class GameoverScore : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private HUD hud;


    void Update()
    {
        txt.text = $"pontuacao final: {hud.points}";
    }
}
