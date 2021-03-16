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
        Restart();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            pc.Die();
        }
        txt_hp.text = $"HP {pc.GetHP()}";
        txt_timer_points.text = $"{points}  {timer.ToString("F3")}s";
    }

    public void Restart()
    {
        points = 0;
        ResetTimer();
    }

    public void ResetTimer()
    {
        timer = 20;
    }
}
