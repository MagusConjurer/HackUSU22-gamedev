using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.SceneManagement;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : Enemy {
    public GameObject healthbarCanvas;

    private enum BossPhase {
        Unbegun,
        Phase1,
        Phase2,
        SatanPhase,
    }
    private BossPhase phase = BossPhase.Unbegun;

    // Please overwrite
    public string BossName;

    protected override void OnStart() {
        healthbarCanvas.SetActive(false);
    }

    protected override void OnUpdate() {
        if (phase == BossPhase.Unbegun) {
            var d = Vector2.Distance(player.position, transform.position);
            if (d < 50) {
                StartBossBattle();
            }
        } else {
            var s = healthbarCanvas.GetComponentInChildren<Text>();
            s.text = GetDamageIndicator();
        }

        if (phase == BossPhase.Phase1) {
            if (currentHealth < 130) {
                phase = BossPhase.Phase2;
            }
        }

        if (phase == BossPhase.Phase2) {
            if (UnityEngine.Random.Range(0,100) < 20) {
                Jump();
            }
        }
    }

    private void StartBossBattle() {
        var namebar = healthbarCanvas.GetComponentInChildren<UnityEngine.UI.Text>();
        Debug.Log(BossName);
        namebar.text = BossName;
        healthbarCanvas.SetActive(true);
        phase = BossPhase.Phase1;
    }
}