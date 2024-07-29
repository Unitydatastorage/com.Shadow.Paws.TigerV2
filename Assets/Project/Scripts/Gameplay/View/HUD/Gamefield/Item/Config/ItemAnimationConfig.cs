using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectAnimationConfig", menuName = "Project/Gameplay/Item/Animation/Config")]
public class ItemAnimationConfig : ScriptableObject
{
    public float CollapseDuration => _collapseDuration;
    [SerializeField] private float _collapseDuration;

    public Ease CollapseEase => _collapseEase;
    [SerializeField] private Ease _collapseEase;

    public float AppearanceDuration => _appearanceDuration;
    [Space]
    [SerializeField] private float _appearanceDuration;

    public Ease AppearanceEase => _appearanceEase;
    [SerializeField] private Ease _appearanceEase;
}