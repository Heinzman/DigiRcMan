# DigiRcMan .NET 10 Upgrade Tasks

## Overview

This document tracks the bottom-up upgrade of the DigiRcMan solution from .NET Framework 4.8 to .NET 10.0. Projects are upgraded tier by tier, with each tier fully converted, built, tested, and committed before proceeding to the next.

**Progress**: 1/13 tasks complete (8%) ![0%](https://progress-bar.xyz/8)

---

## Tasks

### [✓] TASK-001: Verify prerequisites *(Completed: 2026-04-07 15:45)*
**References**: Plan §Prerequisites, Plan §8

- [✓] (1) Verify .NET 10.0 SDK is installed and available
- [✓] (2) .NET 10.0 SDK is present (**Verify**)
- [✓] (3) Verify NuGet CLI/tools are up to date and compatible
- [✓] (4) NuGet tools are compatible (**Verify**)
- [✓] (5) Check for presence and compatibility of any required configuration files (e.g., global.json)
- [✓] (6) Configuration files are compatible (**Verify**)

---

### [▶] TASK-002: Upgrade Tier 1 — Foundation projects
**References**: Plan §Tier 1, Plan §4, Plan §3

- [✓] (1) Convert all Tier 1 projects to SDK-style per Plan §Tier 1
- [✓] (2) Update target frameworks to net10.0 or net10.0-windows as specified in Plan §Tier 1
- [▶] (3) Add or update NuGet package references as required (e.g., System.Speech for ComputerSpeech)
- [ ] (4) Replace all BinaryFormatter/remoting usage in HelperClasses and Serialization per Plan §Tier 1
- [ ] (5) Fix all source-incompatible API issues per Plan §Tier 1
- [ ] (6) Build all Tier 1 projects and fix compilation errors
- [ ] (7) All Tier 1 projects build with 0 errors (**Verify**)
- [ ] (8) Commit changes with message: "chore: upgrade Tier 1 (BusinessObjectContracts, ComputerSpeech, Exceptions, FrameworkContracts, HelperClasses, Log, MouseKeyboardLibrary, Serialization) to net10.0"

---

### [ ] TASK-003: Validate Tier 1 and run regression tests
**References**: Plan §6, Plan §Tier 1

- [ ] (1) Build all Tier 1 projects and verify successful build
- [ ] (2) All Tier 1 projects build with 0 errors (**Verify**)
- [ ] (3) Build all lower tiers (if any) to check for regressions
- [ ] (4) No regressions in lower tiers (**Verify**)

---

### [ ] TASK-004: Upgrade Tier 2 — Core Infrastructure projects
**References**: Plan §Tier 2, Plan §4, Plan §3

- [ ] (1) Convert all Tier 2 projects to SDK-style per Plan §Tier 2
- [ ] (2) Update target frameworks to net10.0 or net10.0-windows as specified in Plan §Tier 2
- [ ] (3) Update incompatible NuGet packages in SoundHandling per Plan §Tier 2
- [ ] (4) Replace all BinaryFormatter/remoting usage in HelperLib per Plan §Tier 2
- [ ] (5) Fix all source-incompatible API issues per Plan §Tier 2
- [ ] (6) Build all Tier 2 projects and fix compilation errors
- [ ] (7) All Tier 2 projects build with 0 errors (**Verify**)
- [ ] (8) Commit changes with message: "chore: upgrade Tier 2 (ComputerSpeechTests, Controls, HelperLib, ResourcesService, SoundHandling) to net10.0"

---

### [ ] TASK-005: Validate Tier 2 and run ComputerSpeechTests
**References**: Plan §6, Plan §Tier 2

- [ ] (1) Build all Tier 2 projects and verify successful build
- [ ] (2) All Tier 2 projects build with 0 errors (**Verify**)
- [ ] (3) Run ComputerSpeechTests project
- [ ] (4) All ComputerSpeechTests pass with 0 failures (**Verify**)
- [ ] (5) Build all lower tiers to check for regressions
- [ ] (6) No regressions in lower tiers (**Verify**)

---

### [ ] TASK-006: Upgrade Tier 3 — Business Objects
**References**: Plan §Tier 3, Plan §4, Plan §3

- [ ] (1) Convert Business Objects project to SDK-style per Plan §Tier 3
- [ ] (2) Update target framework to net10.0-windows
- [ ] (3) Verify and update NAudio package if needed per Plan §Tier 3
- [ ] (4) Fix all source-incompatible API issues per Plan §Tier 3
- [ ] (5) Build Business Objects and fix compilation errors
- [ ] (6) Project builds with 0 errors (**Verify**)
- [ ] (7) Commit changes with message: "chore: upgrade Tier 3 (Business Objects) to net10.0"

---

### [ ] TASK-007: Validate Tier 3 and run regression checks
**References**: Plan §6, Plan §Tier 3

- [ ] (1) Build Business Objects and verify successful build
- [ ] (2) Project builds with 0 errors (**Verify**)
- [ ] (3) Build all lower tiers to check for regressions
- [ ] (4) No regressions in lower tiers (**Verify**)

---

### [ ] TASK-008: Upgrade Tier 4 — Services & Parsers
**References**: Plan §Tier 4, Plan §4, Plan §3

- [ ] (1) Convert all Tier 4 projects to SDK-style per Plan §Tier 4
- [ ] (2) Update target frameworks to net10.0 or net10.0-windows as specified in Plan §Tier 4
- [ ] (3) Verify and update NAudio package in RaceActionSound and RaceSound if needed per Plan §Tier 4
- [ ] (4) Fix all source-incompatible API issues per Plan §Tier 4
- [ ] (5) Build all Tier 4 projects and fix compilation errors
- [ ] (6) All Tier 4 projects build with 0 errors (**Verify**)
- [ ] (7) Commit changes with message: "chore: upgrade Tier 4 (RaceActionSound, RaceActionSpeech, RaceOptionsService, RaceSound, SerialPortDataParser, SerialPortReader) to net10.0"

---

### [ ] TASK-009: Validate Tier 4 and run regression checks
**References**: Plan §6, Plan §Tier 4

- [ ] (1) Build all Tier 4 projects and verify successful build
- [ ] (2) All Tier 4 projects build with 0 errors (**Verify**)
- [ ] (3) Build all lower tiers to check for regressions
- [ ] (4) No regressions in lower tiers (**Verify**)

---

### [ ] TASK-010: Upgrade Tiers 5–8 — Mid-Level, Statistics, Domain, Race Control
**References**: Plan §Tier 5, §Tier 6, §Tier 7, §Tier 8, Plan §4, Plan §3

- [ ] (1) Convert all projects in Tiers 5–8 to SDK-style per Plan §Tiers 5–8
- [ ] (2) Update target frameworks to net10.0 or net10.0-windows as specified in Plan §Tiers 5–8
- [ ] (3) Verify and update NAudio package in RaceSoundService and MusicPlayer if needed per Plan §Tiers 5–8
- [ ] (4) Fix all source-incompatible API issues per Plan §Tiers 5–8
- [ ] (5) Build all Tiers 5–8 projects and fix compilation errors
- [ ] (6) All Tiers 5–8 projects build with 0 errors (**Verify**)
- [ ] (7) Commit changes with message: "chore: upgrade Tiers 5–8 (Logger, RaceDataService, RaceSoundService, Windows Forms View, RaceConsolidationService, RaceStatisticsService, Domain Models, RaceControlService) to net10.0"

---

### [ ] TASK-011: Validate Tiers 5–8 and run regression checks
**References**: Plan §6, Plan §Tiers 5–8

- [ ] (1) Build all Tiers 5–8 projects and verify successful build
- [ ] (2) All Tiers 5–8 projects build with 0 errors (**Verify**)
- [ ] (3) Build all lower tiers to check for regressions
- [ ] (4) No regressions in lower tiers (**Verify**)

---

### [ ] TASK-012: Upgrade Tiers 9–11 — Presenters, Main Application, Entry Point
**References**: Plan §Tier 9, §Tier 10, §Tier 11, Plan §4, Plan §3

- [ ] (1) Convert all projects in Tiers 9–11 to SDK-style per Plan §Tiers 9–11
- [ ] (2) Update target frameworks to net10.0-windows as specified in Plan §Tiers 9–11
- [ ] (3) Update AutoMapper in DigiRcMan from 3.0.0 to 16.1.1 and rewrite mapping configurations per Plan §Tier 11
- [ ] (4) Add System.Configuration.ConfigurationManager NuGet package in DigiRcMan and update configuration usage per Plan §Tier 11
- [ ] (5) Verify and update NAudio package in MusicPlayer if needed per Plan §Tier 9
- [ ] (6) Fix all source-incompatible API issues per Plan §Tiers 9–11
- [ ] (7) Build all Tiers 9–11 projects and fix compilation errors
- [ ] (8) All Tiers 9–11 projects build with 0 errors (**Verify**)
- [ ] (9) Commit changes with message: "chore: upgrade Tiers 9–11 (MusicPlayer, Windows Forms Presenter, Windows Forms Application, DigiRcMan) to net10.0"

---

### [ ] TASK-013: Validate Tiers 9–11 and run full solution tests
**References**: Plan §6, Plan §Tier 9, §Tier 10, §Tier 11

- [ ] (1) Build all Tiers 9–11 projects and verify successful build
- [ ] (2) All Tiers 9–11 projects build with 0 errors (**Verify**)
- [ ] (3) Build all lower tiers to check for regressions
- [ ] (4) No regressions in lower tiers (**Verify**)
- [ ] (5) Run all test projects in the solution
- [ ] (6) All tests pass with 0 failures (**Verify**)

---






