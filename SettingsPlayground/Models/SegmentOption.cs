// Copyright Slav Povstianoj 2026

namespace SettingsPlayground.Models;

public class SegmentOption<TValue>
{
    public string Label { get; set; } = string.Empty;
    public TValue Value { get; set; } = default!;
}


