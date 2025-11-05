using UnityEngine;
using UnityEngine.UI;

public class SwordCooldownManager : MonoBehaviour
{
    public Image Cooldown;         // assign in Inspector
    public float Fill = 1f;        // default cooldown duration in seconds

    public static SwordCooldownManager instance;

    private float _remaining;
    private bool _isCooling;

    public void Awake()
    {
        instance = this;
    }

        void Start()
    {
        // no startup logic required
        if (Cooldown != null)
            Cooldown.fillAmount = 0f;
    }

    void Update()
    {
        if (!_isCooling) return;

        _remaining -= Time.deltaTime;

        if (Cooldown != null)
        {
            // avoid division by zero
            float fill = (Fill > 0f) ? Mathf.Clamp01(_remaining / Fill) : 0f;
            Cooldown.fillAmount = fill;
        }

        if (_remaining <= 0f)
        {
            _isCooling = false;
            _remaining = 0f;
            if (Cooldown != null) Cooldown.fillAmount = 0f;
        }
    }

    // Start a cooldown. Pass duration in seconds. If duration <= 0 uses the 'Fill' default.
    public void CooldownStart(float durationSeconds)
    {
        if (durationSeconds <= 0f) durationSeconds = Fill;

        Fill = durationSeconds;    // update stored duration (visible in Inspector)
        _remaining = Fill;
        _isCooling = true;

        if (Cooldown != null)
            Cooldown.fillAmount = 1f; // start full
    }
}
