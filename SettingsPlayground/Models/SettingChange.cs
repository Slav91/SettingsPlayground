// Copyright Slav Povstianoj 2026

namespace SettingsPlayground.Models;

public class SettingChange
{
    public string SettingName { get; set; } = string.Empty;
    public string OldValue { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
    public UserSettings PreviousSettings { get; set; } = new();
    public DateTime Timestamp { get; set; } = DateTime.Now;
}


