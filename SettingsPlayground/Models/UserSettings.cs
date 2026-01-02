// Copyright Slav Povstianoj 2026

namespace SettingsPlayground.Models;

public class UserSettings
{
    public int SchemaVersion { get; set; } = 1;
    public ThemeMode Theme { get; set; } = ThemeMode.System;
    public AccentColour AccentColour { get; set; } = AccentColour.Blue;
    public double FontScale { get; set; } = 1.0;
    public DensityMode Density { get; set; } = DensityMode.Comfortable;
    public CornerStyle CornerRadius { get; set; } = CornerStyle.Rounded;
    public bool ReduceMotion { get; set; } = false;
    public bool HighContrast { get; set; } = false;
    public bool ConfirmDeletes { get; set; } = true;
    public StartPageOption StartPage { get; set; } = StartPageOption.Preview;

    public UserSettings Clone()
    {
        return new UserSettings
        {
            SchemaVersion = SchemaVersion,
            Theme = Theme,
            AccentColour = AccentColour,
            FontScale = FontScale,
            Density = Density,
            CornerRadius = CornerRadius,
            ReduceMotion = ReduceMotion,
            HighContrast = HighContrast,
            ConfirmDeletes = ConfirmDeletes,
            StartPage = StartPage
        };
    }

    public static UserSettings GetDefaults()
    {
        return new UserSettings();
    }
}

public enum ThemeMode
{
    System,
    Light,
    Dark
}

public enum AccentColour
{
    Blue,
    Purple,
    Green,
    Orange,
    Red,
    Pink
}

public enum DensityMode
{
    Compact,
    Comfortable
}

public enum CornerStyle
{
    Sharp,
    Rounded
}

public enum StartPageOption
{
    Preview,
    Settings
}


