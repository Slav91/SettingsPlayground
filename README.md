# Settings Playground - User Manual

**Copyright Slav Povstianoj 2026**

## Table of Contents

1. [Overview](#overview)
2. [Getting Started](#getting-started)
3. [Features](#features)
4. [Using the App](#using-the-app)
5. [Settings Explained](#settings-explained)
6. [Architecture](#architecture)
7. [Development Guidelines](#development-guidelines)
8. [Extending the App](#extending-the-app)
9. [Troubleshooting](#troubleshooting)

---

## Overview

**Settings Playground** is a professional MAUI Blazor Hybrid application that demonstrates how UI settings affect the user interface in real-time. It's designed as both a functional app and a learning tool for building responsive, theme-aware applications.

### What It Does

- Provides a live preview system showing how settings changes affect UI components
- Demonstrates professional design system implementation with CSS custom properties
- Showcases accessibility features and responsive design
- Serves as a template for building settings-driven applications

### Platform Support

- ✅ **Android** (API 21+)
- ✅ **iOS** (iOS 11+)
- ✅ **Windows** (Windows 10+)
- ✅ **macOS** (macOS 10.15+)

---

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 (17.8+) or JetBrains Rider
- Platform-specific SDKs:
  - **Android**: Android SDK (API 34)
  - **iOS/macOS**: Xcode 14+
  - **Windows**: Windows SDK 10.0.19041.0

### Building the Project

1. Open `SettingsPlayground.sln` in Visual Studio
2. Select your target platform (Android, iOS, Windows, etc.)
3. Press **F5** to build and run

### First Launch

On first launch, the app:
1. Creates a settings file in the app's data directory
2. Loads default settings (Light theme, Blue accent, Medium font size)
3. Opens the Preview page (configurable in Settings)

---

## Features

### Core Features

#### 1. Live Preview System
- **6 preview components** showing different UI patterns
- **Instant updates** when settings change
- **Real-world examples** (profile cards, forms, statistics, etc.)

#### 2. Comprehensive Settings
- **9 configurable options** across 3 categories
- **Visual feedback** for all changes
- **Persistent storage** - settings saved automatically

#### 3. Undo System
- **Last 10 changes** tracked with history
- **Visual banner** showing what changed (e.g., "Theme: Light → Dark")
- **One-tap undo** to revert any change
- **4-second auto-dismiss** for the undo banner

#### 4. Import/Export
- **JSON-based** settings exchange
- **Validation** - rejects invalid settings
- **Error messages** - clear feedback on import failures
- **Schema versioning** - future-proof for migrations

#### 5. Professional Theme System
- **CSS custom properties** for all styling
- **Design tokens** - colours, spacing, typography
- **Smooth transitions** - respects reduced motion preference
- **Platform-aware** - adapts to iOS/Android conventions

---

## Using the App

### Navigation

The app has **two main screens** accessible via bottom navigation:

#### Preview Page
Shows how your settings affect real UI components:
- Profile card with user information
- Dashboard statistics with metrics
- Button showcase with different styles
- Activity list with notifications
- Form elements (inputs, checkboxes, dropdowns)
- Article with typography examples

#### Settings Page
Configure all app preferences organized into sections:
- **Appearance** - Theme, colours, typography, spacing
- **Accessibility** - Motion and contrast options
- **Preferences** - Confirmations and start page
- **Data** - Export, import, and reset

### Making Changes

1. **Tap a setting** to open its controls
2. **Adjust the value** (toggle, segment, slider)
3. **Changes apply instantly** - no save button needed
4. **Switch to Preview** to see the effect
5. **Tap Undo** in the banner to revert (if needed)

### Undo a Change

When you change a setting:
1. A banner appears: "Changed [Setting]: [Old] → [New]"
2. Tap **Undo** button to revert
3. Banner auto-dismisses after 4 seconds
4. History maintains last 10 changes

### Export Your Settings

1. Go to **Settings page**
2. Tap **Export Settings**
3. JSON is copied to clipboard
4. Share via messaging, email, or save to file

### Import Settings

1. Copy settings JSON to clipboard
2. Go to **Settings page**
3. Tap **Import Settings**
4. Paste JSON and tap **Import**
5. If valid, settings apply immediately
6. If invalid, error message shows what's wrong

### Reset to Defaults

1. Go to **Settings page**
2. Scroll to **Data** section
3. Tap **Reset to Defaults**
4. All settings revert to initial values

---

## Settings Explained

### Appearance Settings

#### Theme
**What it does:** Changes the colour scheme of the entire app

**Options:**
- **System** - Follows device light/dark mode
- **Light** - Light backgrounds, dark text
- **Dark** - Dark backgrounds, light text

**Preview effect:** All components change background and text colours

---

#### Accent Colour
**What it does:** Sets the primary colour for interactive elements

**Options:** Blue, Purple, Green, Orange, Red, Pink

**Preview effect:** 
- All buttons change colour
- Links and highlights update
- Focus indicators change
- Progress bars and badges change

---

#### Font Scale
**What it does:** Adjusts text size for better readability

**Options:** 
- **S (0.9)** - Compact text
- **M (1.0)** - Standard size (default)
- **L (1.1)** - Slightly larger
- **XL (1.25)** - Large text

**Preview effect:**
- All text resizes proportionally
- Buttons and cards adjust to fit content
- Maintains proper spacing and hierarchy

---

#### Density
**What it does:** Controls spacing between UI elements

**Options:**
- **Compact** - Tighter spacing (75% of default)
- **Comfortable** - Standard spacing (default)

**Preview effect:**
- Padding in cards increases/decreases
- Row heights adjust
- List item spacing changes
- Button padding changes

---

#### Corner Radius
**What it does:** Changes edge style of UI elements

**Options:**
- **Sharp** - Square corners (0px radius)
- **Rounded** - Smooth corners (4-12px radius)

**Preview effect:**
- All cards and buttons change corner style
- Input fields update
- Chips and badges change shape

---

### Accessibility Settings

#### Reduce Motion
**What it does:** Minimizes animations and transitions

**Options:** On / Off

**When enabled:**
- Transitions become instant (0.01ms)
- Hover effects still work (no animation)
- Scroll behaviour remains smooth
- No auto-playing animations

**Use case:** For users sensitive to motion or on slower devices

---

#### High Contrast
**What it does:** Increases contrast for better visibility

**Options:** On / Off

**When enabled:**
- Text becomes pure black (light mode) or white (dark mode)
- Borders become more visible
- Subtle greys replaced with stronger colours

**Use case:** For users with visual impairments or in bright sunlight

---

### Preferences Settings

#### Confirm Deletes
**What it does:** Shows confirmation dialog before destructive actions

**Options:** On / Off

**Effect:** When enabled, app asks "Are you sure?" before deletions

---

#### Start Page
**What it does:** Sets which page opens when app launches

**Options:**
- **Preview** - Opens to preview screen (default)
- **Settings** - Opens directly to settings

**Use case:** Set to Settings if you frequently adjust preferences

---

## Architecture

### Three-Layer Design

The app follows a clean architecture with three distinct layers:

```
┌─────────────────────────────────────┐
│         UI Layer (Components)       │
│  - Pages (Preview, Settings)        │
│  - Reusable Components (Rows, Cards)│
│  - Bottom Navigation                │
└─────────────────────────────────────┘
                 ↓
┌─────────────────────────────────────┐
│      State Layer (Services)         │
│  - SettingsState (single source)    │
│  - ThemeService (applies changes)   │
│  - ImportExportService (validation) │
└─────────────────────────────────────┘
                 ↓
┌─────────────────────────────────────┐
│    Persistence Layer (Storage)      │
│  - SettingsStore (load/save)        │
│  - JSON file in app data directory  │
└─────────────────────────────────────┘
```

### Key Components

#### SettingsState (Service)
- **Single source of truth** for all settings
- Holds current `UserSettings` object
- Raises `SettingsChanged` event when values change
- Manages undo history stack (last 10 changes)
- Thread-safe updates via `UpdateAsync()`

#### SettingsStore (Service)
- Handles file I/O operations
- Saves settings as JSON to app data directory
- Loads settings on startup (or creates defaults)
- Provides `Reset()` to delete saved settings

#### ThemeService (Service)
- Applies theme changes via JavaScript interop
- Sets HTML attributes (`data-theme`, `data-accent`, etc.)
- Updates CSS custom properties (`--font-scale`)
- Handles system theme detection

#### UserSettings (Model)
- Plain C# class with all setting properties
- Includes `Clone()` for undo system
- Schema version for future migrations
- Default values defined in `GetDefaults()`

### How Settings Flow Through the App

1. **User changes a setting** (e.g., toggles Dark mode)
2. **Component calls** `SettingsState.UpdateAsync()`
3. **State updates** current settings and adds to history
4. **State saves** to disk via `SettingsStore`
5. **State raises** `SettingsChanged` event
6. **ThemeService listens** and applies via JavaScript
7. **All components** subscribed to event re-render
8. **Preview updates** with new theme values

### Design Token System

All styling uses CSS custom properties defined in `theme.css`:

**Colour Tokens:**
```css
--app-background    /* Page background */
--card-background   /* Card surfaces */
--text-primary      /* Main text */
--text-secondary    /* Muted text */
--border-colour     /* Lines and dividers */
--accent            /* Interactive elements */
```

**Spacing Tokens:**
```css
--space-xs   /* 4px */
--space-s    /* 8px */
--space-m    /* 16px */
--space-l    /* 24px */
--space-xl   /* 32px */
```

**Typography Tokens:**
```css
--font-scale  /* User's selected multiplier */
--font-xs     /* calc(12px * var(--font-scale)) */
--font-s      /* calc(14px * var(--font-scale)) */
--font-m      /* calc(16px * var(--font-scale)) */
--font-l      /* calc(20px * var(--font-scale)) */
--font-xl     /* calc(24px * var(--font-scale)) */
```

**Why This Works:**
- Change one token → entire app updates
- No hardcoded colours in components
- Easy to add new themes
- Consistent spacing everywhere

---

## Support & Feedback

For questions, issues, or feature requests, please contact the developer.

**Version:** 1.0  
**Last Updated:** January 2026
