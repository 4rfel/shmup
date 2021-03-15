using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text txt_timer_points;
    [SerializeField] private Text txt_hp;
    [SerializeField] private PlayerController pc;

    private float timer;
    public int points;

    void Start()
    {
        points = 0;
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        txt_hp.text = $"HP {pc.GetHP()}";
        txt_timer_points.text = $"{points}  {timer.ToString("F3")}s";
    }

    public void Restart()
    {
        points = 0;
        timer = 0;
    }
}
