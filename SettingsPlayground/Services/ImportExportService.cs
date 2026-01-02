// Copyright Slav Povstianoj 2026

using System.Text.Json;
using SettingsPlayground.Models;

namespace SettingsPlayground.Services;

public class ImportExportService
{
    private readonly JsonSerializerOptions _jsonOptions;

    public ImportExportService()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public string ExportToJson(UserSettings settings)
    {
        return JsonSerializer.Serialize(settings, _jsonOptions);
    }

    public (bool IsValid, UserSettings? Settings, string ErrorMessage) ImportFromJson(string json)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return (false, null, "JSON is empty");
            }

            var settings = JsonSerializer.Deserialize<UserSettings>(json, _jsonOptions);
            
            if (settings == null)
            {
                return (false, null, "Failed to parse JSON");
            }

            if (!Enum.IsDefined(typeof(ThemeMode), settings.Theme))
            {
                return (false, null, "Invalid theme value");
            }

            if (!Enum.IsDefined(typeof(AccentColour), settings.AccentColour))
            {
                return (false, null, "Invalid accent colour value");
            }

            if (!Enum.IsDefined(typeof(DensityMode), settings.Density))
            {
                return (false, null, "Invalid density value");
            }

            if (!Enum.IsDefined(typeof(CornerStyle), settings.CornerRadius))
            {
                return (false, null, "Invalid corner radius value");
            }

            if (!Enum.IsDefined(typeof(StartPageOption), settings.StartPage))
            {
                return (false, null, "Invalid start page value");
            }

            if (settings.FontScale < 0.5 || settings.FontScale > 2.0)
            {
                settings.FontScale = 1.0;
            }

            if (settings.SchemaVersion != 1)
            {
                settings.SchemaVersion = 1;
            }

            return (true, settings, string.Empty);
        }
        catch (JsonException ex)
        {
            return (false, null, $"JSON parsing error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return (false, null, $"Import error: {ex.Message}");
        }
    }
}


