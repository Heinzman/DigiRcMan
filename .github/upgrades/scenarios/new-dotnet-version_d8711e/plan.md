# .NET 10 Upgrade Plan — DigiRcMan

## Table of Contents
1. [Executive Summary](#1-executive-summary)
2. [Migration Strategy](#2-migration-strategy)
3. [Detailed Dependency Analysis](#3-detailed-dependency-analysis)
4. [Project-by-Project Plans](#4-project-by-project-plans)
   - [Tier 1 — Foundation (Level 0)](#tier-1--foundation-level-0)
   - [Tier 2 — Core Infrastructure (Level 1)](#tier-2--core-infrastructure-level-1)
   - [Tier 3 — Business Objects (Level 2)](#tier-3--business-objects-level-2)
   - [Tier 4 — Services & Parsers (Level 3)](#tier-4--services--parsers-level-3)
   - [Tier 5 — Mid-Level Services (Level 4)](#tier-5--mid-level-services-level-4)
   - [Tier 6 — Statistics & Consolidation (Level 5)](#tier-6--statistics--consolidation-level-5)
   - [Tier 7 — Domain Models (Level 6)](#tier-7--domain-models-level-6)
   - [Tier 8 — Race Control (Level 7)](#tier-8--race-control-level-7)
   - [Tier 9 — Presenters & Players (Level 8)](#tier-9--presenters--players-level-8)
   - [Tier 10 — Main Application (Level 9)](#tier-10--main-application-level-9)
   - [Tier 11 — Entry Point (Level 10)](#tier-11--entry-point-level-10)
5. [Risk Management](#5-risk-management)
6. [Testing & Validation Strategy](#6-testing--validation-strategy)
7. [Complexity & Effort Assessment](#7-complexity--effort-assessment)
8. [Source Control Strategy](#8-source-control-strategy)
9. [Success Criteria](#9-success-criteria)

---

## 1. Executive Summary

### Scenario
Upgrade the DigiRcMan solution from **.NET Framework 4.8** to **.NET 10.0 (Long Term Support)**. This is a full-solution framework migration involving SDK-style project conversion, target framework retargeting, NuGet package updates, and API compatibility remediation.

### Scope
| Metric | Value |
|---|---|
| Total projects | 34 |
| Projects requiring upgrade | 33 |
| Already on target | 1 (MrcLapCounterBle — net10.0-windows10.0.22621.0) |
| Current framework | .NET Framework 4.8 |
| Target framework | net10.0 / net10.0-windows |
| Dependency depth | 11 levels (Level 0 → Level 10) |
| Affected files | 215 |
| Incompatible NuGet packages | 2 (AutoMapper, NAudio) |
| Security vulnerabilities | 1 (AutoMapper in DigiRcMan) |

### Issue Breakdown
| Category | Count | Severity | Resolution |
|---|---|---|---|
| Binary incompatible APIs (Api.0001) | 28,579 | Mandatory | Automatically resolved by recompilation after retargeting |
| Source incompatible APIs (Api.0002) | 5,389 | Potential | May require code changes for changed/removed APIs |
| Behavioral changes (Api.0003) | 15 | Potential | Runtime behavior differences; review and test |
| SDK-style conversion (Project.0001) | 33 | Mandatory | Convert each `.csproj` to SDK-style format |
| Target framework change (Project.0002) | 33 | Mandatory | Update `TargetFramework` element |
| Incompatible NuGet packages (NuGet.0001) | 7 | Mandatory | Update to compatible versions |
| Security vulnerability (NuGet.0004) | 1 | Optional | Update AutoMapper 3.0.0 → 16.1.1 |

### Affected Technologies
| Technology | Issue Count | Impact |
|---|---|---|
| Windows Forms | 28,682 | Binary recompilation; WinForms is supported on .NET 10 |
| Windows Forms Legacy Controls | 5,376 | Some controls may have API changes |
| GDI+ / System.Drawing | 5,112 | Migrate to `System.Drawing.Common` (Windows-only) |
| Legacy Configuration System | 11 | `ConfigurationManager` requires NuGet package on .NET 10 |
| Speech & Voice Recognition | 8 | `System.Speech` requires Windows Compatibility Pack |
| Deprecated Remoting & Serialization | 6 | `BinaryFormatter` and remoting APIs removed; must replace |

### Complexity Classification
**Complex** — 33 projects, 11 dependency levels, 6 affected technologies, 1 security vulnerability, deprecated API usage (BinaryFormatter/Remoting).

### Selected Strategy
**Bottom-Up (Dependency-First)** — Upgrade projects sequentially from leaf nodes (Level 0) to the entry-point application (Level 10). Each tier is fully converted, built, and validated before the next tier begins. This minimizes risk and ensures each tier builds on a stable, already-upgraded foundation.

### Critical Issues
- **Security vulnerability**: AutoMapper 3.0.0 in DigiRcMan has a known vulnerability — will be addressed in Tier 11 (DigiRcMan upgrade)
- **BinaryFormatter/Remoting**: Used in HelperClasses, HelperLib, and Serialization — these APIs are removed in .NET 10 and must be replaced
- **Speech APIs**: `System.Speech` namespace used in ComputerSpeech — requires the `System.Speech` NuGet package or Windows Compatibility Pack on .NET 10
- **Legacy Configuration**: `ConfigurationManager` used in DigiRcMan — requires `System.Configuration.ConfigurationManager` NuGet package

---

## 2. Migration Strategy

### Approach: Bottom-Up (Dependency-First)

**Justification:**
- The solution has **33 projects** across **11 dependency levels** — too large and deeply nested for an all-at-once approach
- Clear dependency hierarchy with identifiable tiers enables systematic progression
- Each tier builds on stable, already-upgraded dependencies — no multi-targeting needed
- Risk is isolated to the current tier; issues found early inform later tiers
- The solution is a desktop WinForms application where incremental validation is practical

### Execution Model
- **Sequential by tier**: Tiers are upgraded in strict dependency order (Tier 1 first → Tier 11 last)
- **Parallel within tier**: Projects in the same tier have no interdependencies and can be upgraded together in a single batch
- **Each tier** consists of: Preparation → SDK Conversion & Retargeting → Package Updates → Code Fixes → Validation → Commit

### Per-Tier Workflow
For each tier:
1. **Preparation**: Review tier projects, confirm lower-tier dependencies are stable
2. **SDK-Style Conversion**: Convert all `.csproj` files in the tier from legacy format to SDK-style
3. **Target Framework Update**: Change `TargetFramework` to `net10.0` or `net10.0-windows` as appropriate
4. **Package Updates**: Update incompatible NuGet packages to compatible versions
5. **Code Fixes**: Address source-incompatible APIs, behavioral changes, and removed APIs
6. **Build & Test**: Build all tier projects, fix compilation errors, run tests
7. **Commit**: Commit tier as a checkpoint

### Tier Completion Criteria
A tier is complete when:
- All projects in the tier have SDK-style `.csproj` files
- All projects target `net10.0` or `net10.0-windows`
- All projects build without errors
- All NuGet packages are compatible
- Tests (if any) pass

---

## 3. Detailed Dependency Analysis

### Dependency Graph

```
Tier 11 (Level 10): [DigiRcMan]
                      ↓
Tier 10 (Level 9):  [Windows Forms Application]
                      ↓
Tier 9  (Level 8):  [Windows Forms Presenter] [MusicPlayer]
                      ↓
Tier 8  (Level 7):  [RaceControlService]
                      ↓
Tier 7  (Level 6):  [Domain Models]
                      ↓
Tier 6  (Level 5):  [RaceConsolidationService] [RaceStatisticsService]
                      ↓
Tier 5  (Level 4):  [Logger] [RaceDataService] [RaceSoundService] [Windows Forms View]
                      ↓
Tier 4  (Level 3):  [RaceActionSound] [RaceActionSpeech] [RaceOptionsService]
                    [RaceSound] [SerialPortDataParser] [SerialPortReader]
                      ↓
Tier 3  (Level 2):  [Business Objects]
                      ↓
Tier 2  (Level 1):  [Controls] [HelperLib] [ResourcesService] [SoundHandling] [ComputerSpeechTests]
                      ↓
Tier 1  (Level 0):  [BusinessObjectContracts] [ComputerSpeech] [Exceptions]
                    [FrameworkContracts] [HelperClasses] [Log]
                    [MouseKeyboardLibrary] [Serialization]
```

### Tier Breakdown

| Tier | Level | Projects | Depends On | Key Risks |
|---|---|---|---|---|
| 1 | 0 | 8 | None | BinaryFormatter/Remoting in HelperClasses, Serialization; Speech APIs in ComputerSpeech |
| 2 | 1 | 5 | Tier 1 | Controls has 807 issues (WinForms/GDI) |
| 3 | 2 | 1 | Tiers 1–2 | Business Objects is widely referenced (20 consumers); NAudio package |
| 4 | 3 | 6 | Tiers 1–3 | NAudio in RaceSound, RaceActionSound; 6 projects to batch |
| 5 | 4 | 4 | Tiers 1–4 | RaceSoundService has NAudio; Windows Forms View has 356 issues |
| 6 | 5 | 2 | Tiers 1–5 | Low complexity, behavioral changes in RaceStatisticsService |
| 7 | 6 | 1 | Tiers 1–6 | Domain Models depends on 12 projects; cross-cutting |
| 8 | 7 | 1 | Tiers 1–7 | Low issue count, moderate risk |
| 9 | 8 | 2 | Tiers 1–8 | Windows Forms Presenter has 2,064 issues (highest after WinForms App) |
| 10 | 9 | 1 | Tiers 1–9 | Windows Forms Application: 29,353 issues, 368 files, largest project |
| 11 | 10 | 1 | Tiers 1–10 | DigiRcMan: AutoMapper 3.0.0 → 16.1.1 (major breaking change + security fix), Legacy Configuration |

### Skipped Project
- **MrcLapCounterBle** — Already targets `net10.0-windows10.0.22621.0`. No action required.

---

## 4. Project-by-Project Plans

### Tier 1 — Foundation (Level 0)

**Projects (8):** BusinessObjectContracts, ComputerSpeech, Exceptions, FrameworkContracts, HelperClasses, Log, MouseKeyboardLibrary, Serialization

**Dependencies:** None (leaf nodes)

**Complexity:** Medium — Most projects are simple, but HelperClasses, ComputerSpeech, and Serialization have technology-specific concerns.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| BusinessObjectContracts | — | 2 | net10.0 | None |
| ComputerSpeech | 5 | 10 | net10.0 | Speech & Voice Recognition |
| Exceptions | — | 2 | net10.0 | None |
| FrameworkContracts | — | 2 | net10.0 | None |
| HelperClasses | 5 | 43 | net10.0-windows | WinForms, GDI+, Deprecated Remoting & Serialization |
| Log | — | 53 | net10.0-windows | WinForms |
| MouseKeyboardLibrary | — | 242 | net10.0-windows | WinForms |
| Serialization | 2 | 9 | net10.0 | Deprecated Remoting & Serialization |

#### Migration Steps

1. **SDK-Style Conversion**: Convert all 8 `.csproj` files to SDK-style format
2. **Target Framework Update**:
   - `net10.0`: BusinessObjectContracts, ComputerSpeech, Exceptions, FrameworkContracts, Serialization
   - `net10.0-windows`: HelperClasses, Log, MouseKeyboardLibrary
3. **Package Updates**: No NuGet package updates required for this tier
4. **Code Fixes — Critical**:
   - **ComputerSpeech**: `System.Speech` namespace (8 issues) — Add `System.Speech` NuGet package reference or use Windows Compatibility Pack. The `System.Speech` APIs are not included by default in .NET 10 but are available via NuGet.
   - **HelperClasses**: Deprecated Remoting & Serialization (2 issues) — Replace `BinaryFormatter` usage with `System.Text.Json` or `XmlSerializer`. `BinaryFormatter` is removed in .NET 10.
   - **HelperClasses**: Behavioral change (1 issue) — Review and test runtime behavior.
   - **Serialization**: Deprecated Remoting & Serialization (2 issues) — Replace `BinaryFormatter` with `System.Text.Json` or `XmlSerializer`. Behavioral changes (5 issues) — review serialization edge cases.
5. **Code Fixes — Binary/Source APIs**:
   - Binary incompatible APIs (across tier) will resolve upon recompilation
   - Source incompatible APIs: HelperClasses (8), ComputerSpeech (8), Serialization (2) — review and fix compilation errors

#### Validation
- [ ] All 8 projects converted to SDK-style
- [ ] All 8 projects build without errors
- [ ] No `BinaryFormatter` or `IFormatter` usage remains
- [ ] `System.Speech` compiles successfully in ComputerSpeech
- [ ] ComputerSpeechTests pass (tested in Tier 2)

---

### Tier 2 — Core Infrastructure (Level 1)

**Projects (5):** ComputerSpeechTests, Controls, HelperLib, ResourcesService, SoundHandling

**Dependencies:** Tier 1 only

**Complexity:** Medium — Controls is the most complex project in this tier with 807 issues (WinForms + GDI+ heavy). Others are low complexity.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| ComputerSpeechTests | — | 2 | net10.0 | Test project |
| Controls | 19 | 807 | net10.0-windows | WinForms, WinForms Legacy Controls, GDI+ |
| HelperLib | 6 | 15 | net10.0-windows | Deprecated Remoting & Serialization, WinForms |
| ResourcesService | — | 7 | net10.0-windows | WinForms |
| SoundHandling | — | 3 | net10.0 | None |

#### Migration Steps

1. **SDK-Style Conversion**: Convert all 5 `.csproj` files to SDK-style format
2. **Target Framework Update**:
   - `net10.0`: ComputerSpeechTests, SoundHandling
   - `net10.0-windows`: Controls, HelperLib, ResourcesService
3. **Package Updates**:
   - SoundHandling: Has NuGet.0001 — update incompatible package to compatible version
4. **Code Fixes — Critical**:
   - **HelperLib**: Deprecated Remoting & Serialization (2 issues) — Replace `BinaryFormatter`/remoting usage. Behavioral changes (7 issues) — review runtime differences.
   - **Controls**: WinForms Legacy Controls (84 issues) — Review for removed or changed control APIs. GDI+ / System.Drawing (368 source-incompatible issues) — Review `System.Drawing.Common` usage; on .NET 10 this is Windows-only (which is fine for this desktop app). Fix any changed method signatures.
5. **Code Fixes — Source APIs**:
   - Controls (368 source-incompatible), HelperLib (2 source-incompatible) — fix compilation errors
6. **Testing**:
   - Run ComputerSpeechTests to validate Tier 1's ComputerSpeech project

#### Validation
- [ ] All 5 projects converted to SDK-style
- [ ] All 5 projects build without errors
- [ ] ComputerSpeechTests pass
- [ ] Controls renders correctly (manual spot check)
- [ ] No `BinaryFormatter` usage remains in HelperLib

---

### Tier 3 — Business Objects (Level 2)

**Projects (1):** Business Objects

**Dependencies:** Tiers 1–2 (BusinessObjectContracts, HelperClasses, Log, ResourcesService)

**Complexity:** Medium — 384 issues, 90 files. Widely consumed by 20 downstream projects. NAudio package reference.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| Business Objects | 90 | 384 | net10.0-windows | WinForms (292), GDI+ (31) |

#### Migration Steps

1. **SDK-Style Conversion**: Convert `Business Objects.csproj` to SDK-style
2. **Target Framework Update**: Change to `net10.0-windows`
3. **Package Updates**:
   - NAudio: 1.8.5 — Assessment shows this package as incompatible at solution level but compatible at project level. Verify compatibility after retargeting; update to 2.3.0 if build fails.
4. **Code Fixes**:
   - Source incompatible APIs (89 issues) — Fix compilation errors from changed method signatures
   - Binary APIs (292) — Will resolve upon recompilation
5. **Build & validate**: This project is the foundation for 20 downstream consumers — stability here is critical

#### Validation
- [ ] Project converted to SDK-style
- [ ] Builds without errors
- [ ] NAudio dependency resolves correctly
- [ ] Tier 1 and Tier 2 projects still build (regression check)

---

### Tier 4 — Services & Parsers (Level 3)

**Projects (6):** RaceActionSound, RaceActionSpeech, RaceOptionsService, RaceSound, SerialPortDataParser, SerialPortReader

**Dependencies:** Tiers 1–3

**Complexity:** Low–Medium — Most projects have few issues. SerialPortReader has 69 issues (source-incompatible serial port APIs).

**Note:** MrcLapCounterBle is also at Level 3 but already targets net10.0 — no action needed.

#### Project Details

| Project | Files | Issues | Target | Key Technologies | NuGet |
|---|---|---|---|---|---|
| RaceActionSound | 2 | 5 | net10.0-windows | WinForms | NAudio 1.8.5 |
| RaceActionSpeech | — | 2 | net10.0 | None | — |
| RaceOptionsService | — | 2 | net10.0 | None | — |
| RaceSound | 3 | 7 | net10.0-windows | WinForms | NAudio 1.8.5 |
| SerialPortDataParser | — | 2 | net10.0 | None | — |
| SerialPortReader | — | 69 | net10.0 | None | — |

#### Migration Steps

1. **SDK-Style Conversion**: Convert all 6 `.csproj` files to SDK-style
2. **Target Framework Update**:
   - `net10.0`: RaceActionSpeech, RaceOptionsService, SerialPortDataParser, SerialPortReader
   - `net10.0-windows`: RaceActionSound, RaceSound
3. **Package Updates**:
   - NAudio in RaceActionSound and RaceSound: Verify compatibility; update to 2.3.0 if needed
4. **Code Fixes**:
   - SerialPortReader (67 source-incompatible) — Review serial port API changes
   - Other binary-incompatible issues resolve upon recompilation

#### Validation
- [ ] All 6 projects converted to SDK-style
- [ ] All 6 projects build without errors
- [ ] Serial port communication compiles (SerialPortReader)
- [ ] NAudio references resolve in RaceActionSound and RaceSound

---

### Tier 5 — Mid-Level Services (Level 4)

**Projects (4):** Logger, RaceDataService, RaceSoundService, Windows Forms View

**Dependencies:** Tiers 1–4

**Complexity:** Medium — Windows Forms View has 356 issues. RaceSoundService references NAudio.

#### Project Details

| Project | Files | Issues | Target | Key Technologies | NuGet |
|---|---|---|---|---|---|
| Logger | — | 2 | net10.0 | None | — |
| RaceDataService | — | 2 | net10.0 | None | — |
| RaceSoundService | 5 | 13 | net10.0-windows | WinForms | NAudio 1.8.5 |
| Windows Forms View | — | 356 | net10.0-windows | WinForms, WinForms Legacy Controls | — |

#### Migration Steps

1. **SDK-Style Conversion**: Convert all 4 `.csproj` files to SDK-style
2. **Target Framework Update**:
   - `net10.0`: Logger, RaceDataService
   - `net10.0-windows`: RaceSoundService, Windows Forms View
3. **Package Updates**:
   - RaceSoundService: NAudio 1.8.5 — verify compatibility; update to 2.3.0 if needed
4. **Code Fixes**:
   - Windows Forms View (353 mandatory binary) — recompilation resolves
   - RaceSoundService (10 mandatory binary) — recompilation resolves

#### Validation
- [ ] All 4 projects converted to SDK-style
- [ ] All 4 projects build without errors
- [ ] NAudio resolves in RaceSoundService
- [ ] Windows Forms View renders (manual spot check)

---

### Tier 6 — Statistics & Consolidation (Level 5)

**Projects (2):** RaceConsolidationService, RaceStatisticsService

**Dependencies:** Tiers 1–5

**Complexity:** Low — 2 and 4 issues respectively. RaceStatisticsService has behavioral changes.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| RaceConsolidationService | — | 2 | net10.0 | None |
| RaceStatisticsService | — | 4 | net10.0 | None |

#### Migration Steps

1. **SDK-Style Conversion**: Convert both `.csproj` files to SDK-style
2. **Target Framework Update**: Both to `net10.0`
3. **Package Updates**: None required
4. **Code Fixes**:
   - RaceStatisticsService: Behavioral change (2 issues) — review runtime behavior of statistics calculations to ensure correctness

#### Validation
- [ ] Both projects converted to SDK-style
- [ ] Both projects build without errors
- [ ] Statistics calculations produce correct results (manual or test validation)

---

### Tier 7 — Domain Models (Level 6)

**Projects (1):** Domain Models

**Dependencies:** Tiers 1–6 (depends on 12 projects: Business Objects, BusinessObjectContracts, ComputerSpeech, Exceptions, HelperClasses, Logger, Log, WinForms Presentation Framework, RaceDataService, RaceOptionsService, RaceStatisticsService, ResourcesService)

**Complexity:** Low–Medium — 23 issues, 28 files. Cross-cutting project with many dependencies.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| Domain Models | 28 | 23 | net10.0-windows | WinForms (9), GDI+ (12) |

#### Migration Steps

1. **SDK-Style Conversion**: Convert `Domain Models.csproj` to SDK-style
2. **Target Framework Update**: `net10.0-windows`
3. **Package Updates**: None required
4. **Code Fixes**:
   - Source incompatible APIs (12 GDI+) — Fix `System.Drawing` method signature changes
   - Binary APIs (9) — Resolve upon recompilation

#### Validation
- [ ] Project converted to SDK-style
- [ ] Builds without errors
- [ ] All 12 dependency projects still build (regression check)

---

### Tier 8 — Race Control (Level 7)

**Projects (1):** RaceControlService

**Dependencies:** Tiers 1–7 (Business Objects, Domain Models, Log, RaceOptionsService)

**Complexity:** Low — 5 issues, all mandatory binary incompatibilities.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| RaceControlService | — | 5 | net10.0-windows | WinForms |

#### Migration Steps

1. **SDK-Style Conversion**: Convert `RaceControlService.csproj` to SDK-style
2. **Target Framework Update**: `net10.0-windows`
3. **Package Updates**: None required
4. **Code Fixes**: Binary APIs (5) — resolve upon recompilation

#### Validation
- [ ] Project converted to SDK-style
- [ ] Builds without errors

---

### Tier 9 — Presenters & Players (Level 8)

**Projects (2):** MusicPlayer, Windows Forms Presenter

**Dependencies:** Tiers 1–8

**Complexity:** High — Windows Forms Presenter has 2,064 issues (1,822 binary + 240 source-incompatible), 53 files. MusicPlayer references NAudio.

#### Project Details

| Project | Files | Issues | Target | Key Technologies | NuGet |
|---|---|---|---|---|---|
| MusicPlayer | 5 | 4 | net10.0 | None | NAudio 1.8.5 |
| Windows Forms Presenter | 53 | 2,064 | net10.0-windows | WinForms, WinForms Legacy Controls (1,075), GDI+ (240) | — |

#### Migration Steps

1. **SDK-Style Conversion**: Convert both `.csproj` files to SDK-style
2. **Target Framework Update**:
   - `net10.0`: MusicPlayer
   - `net10.0-windows`: Windows Forms Presenter
3. **Package Updates**:
   - MusicPlayer: NAudio 1.8.5 — verify compatibility; update to 2.3.0 if needed
4. **Code Fixes**:
   - Windows Forms Presenter: Source incompatible APIs (240 GDI+ issues) — Fix `System.Drawing` usage. WinForms Legacy Controls (1,075) — Review for removed/changed control APIs and properties.
   - MusicPlayer: Source incompatible (1 issue) — fix compilation error

#### Validation
- [ ] Both projects converted to SDK-style
- [ ] Both projects build without errors
- [ ] NAudio resolves in MusicPlayer
- [ ] Windows Forms Presenter UI renders correctly (manual spot check)

---

### Tier 10 — Main Application (Level 9)

**Projects (1):** Windows Forms Application

**Dependencies:** Tiers 1–9 (depends on 17 projects)

**Complexity:** High — 29,353 issues (24,898 binary + 4,453 source-incompatible), 368 files. This is the largest project in the solution.

#### Project Details

| Project | Files | Issues | Target | Key Technologies |
|---|---|---|---|---|
| Windows Forms Application | 368 | 29,353 | net10.0-windows | WinForms (25,024), WinForms Legacy Controls (4,147), GDI+ (4,327) |

#### Migration Steps

1. **SDK-Style Conversion**: Convert `Windows Forms Application.csproj` to SDK-style
2. **Target Framework Update**: `net10.0-windows`
3. **Package Updates**: None required
4. **Code Fixes**:
   - Source incompatible APIs (4,453) — Fix `System.Drawing`, WinForms control APIs, and legacy control changes. This is the largest code change effort in the solution.
   - Binary APIs (24,898) — Resolve upon recompilation
   - WinForms Legacy Controls (4,147) — Review for removed properties, changed event signatures, and deprecated control patterns
   - GDI+ (4,327) — Fix `System.Drawing.Common` method signatures
5. **Approach**: Fix compilation errors iteratively — build, fix batch of errors, rebuild. Focus on most common error patterns first.

#### Validation
- [ ] Project converted to SDK-style
- [ ] Builds without errors
- [ ] Application launches and primary UI screens render correctly
- [ ] Core workflows functional (race management, settings, etc.)

---

### Tier 11 — Entry Point (Level 10)

**Projects (1):** DigiRcMan

**Dependencies:** All tiers (depends on 21 projects)

**Complexity:** Medium — 38 issues, 44 files. AutoMapper major version upgrade (3.0.0 → 16.1.1) with significant API breaking changes. Legacy Configuration System migration.

#### Project Details

| Project | Files | Issues | Target | Key Technologies | NuGet |
|---|---|---|---|---|---|
| DigiRcMan | 44 | 38 | net10.0-windows | WinForms (14), Legacy Configuration (11) | AutoMapper 3.0.0 → 16.1.1 |

#### Migration Steps

1. **SDK-Style Conversion**: Convert `DigiRcMan.csproj` to SDK-style
2. **Target Framework Update**: `net10.0-windows`
3. **Package Updates**:
   - **AutoMapper**: 3.0.0 → 16.1.1 (**major breaking change + security fix**)
     - AutoMapper 3.x used `Mapper.CreateMap<>()` static API — completely removed
     - AutoMapper 16.x uses `MapperConfiguration` + dependency injection pattern
     - All mapping configurations must be rewritten using `Profile` classes
     - All `Mapper.Map<>()` static calls must use injected `IMapper` instance
     - ⚠️ This is the highest-risk single change in the entire upgrade
4. **Code Fixes**:
   - **Legacy Configuration System** (11 issues): Add `System.Configuration.ConfigurationManager` NuGet package. Review `ConfigurationManager.AppSettings` and `ConfigurationManager.ConnectionStrings` usage.
   - **AutoMapper migration**: Rewrite mapping profiles and injection patterns (see package update above)
   - Source incompatible APIs (11) — Fix compilation errors
   - Binary APIs (23) — Resolve upon recompilation

#### Validation
- [ ] Project converted to SDK-style
- [ ] AutoMapper mapping configurations rewritten and functional
- [ ] `ConfigurationManager` references compile with NuGet package
- [ ] Application starts and runs end-to-end
- [ ] No security vulnerabilities remain
- [ ] Full solution builds without errors

---

## 5. Risk Management

### High-Risk Changes

| Risk | Tier | Project(s) | Description | Mitigation |
|---|---|---|---|---|
| BinaryFormatter removal | 1 | HelperClasses, Serialization, HelperLib | `BinaryFormatter` is removed in .NET 10. Any serialization/deserialization using it will fail at compile time. | Replace with `System.Text.Json`, `XmlSerializer`, or `DataContractSerializer`. Test serialized data compatibility if persisted data exists. |
| AutoMapper 3.x → 16.x | 11 | DigiRcMan | Complete API redesign between versions. Static `Mapper.CreateMap` and `Mapper.Map` patterns are removed. | Rewrite all mapping configurations using `Profile` classes and `MapperConfiguration`. Replace static `Mapper.Map` with injected `IMapper`. Consider intermediate upgrade to understand breaking changes. |
| Speech API migration | 1 | ComputerSpeech | `System.Speech` not included by default in .NET 10. | Add `System.Speech` NuGet package reference. Test speech synthesis and recognition. |
| WinForms Legacy Controls | 9, 10 | Windows Forms Presenter, Windows Forms Application | Large number of legacy control API changes (5,376 total). Some controls may have changed behavior or removed properties. | Build iteratively, fix by error pattern. Test UI rendering manually. |
| Legacy Configuration | 11 | DigiRcMan | `ConfigurationManager` requires explicit NuGet package in .NET 10. | Add `System.Configuration.ConfigurationManager` NuGet package. |
| Persisted serialized data | 1, 2 | Serialization, HelperClasses, HelperLib | If application persists data using `BinaryFormatter`, changing serializer will break deserialization of existing files. | ⚠️ Investigate whether any persisted binary-serialized data exists. If so, plan a data migration or dual-read strategy. |
| NAudio compatibility | 3, 4, 5, 9 | 5 projects | NAudio 1.8.5 shows conflicting compatibility signals (compatible per-project, incompatible globally). | Verify after retargeting. Update to 2.3.0 only if build fails. NAudio 2.x has minor API changes. |

### Security Vulnerabilities

| Package | Version | Project | Action |
|---|---|---|---|
| AutoMapper | 3.0.0 | DigiRcMan | Update to 16.1.1 (addressed in Tier 11) |

### Contingency Plans

- **If BinaryFormatter replacement breaks data compatibility**: Implement a data migration utility that reads old format and writes new format before the main application upgrade
- **If AutoMapper 16.x migration is too complex**: Consider AutoMapper 13.x as an intermediate step (last version before major DI changes)
- **If NAudio 2.3.0 introduces regressions**: NAudio 1.8.5 appears compatible with .NET 10 per individual project assessment; staying on 1.8.5 may be viable
- **If WinForms rendering breaks**: Test on Windows 10/11 with .NET 10 runtime; some GDI+ behaviors may differ — use `System.Drawing.Common` explicitly

---

## 6. Testing & Validation Strategy

### Per-Tier Testing

After completing each tier:
- [ ] All projects in the tier build without errors
- [ ] All projects in the tier build without new warnings
- [ ] No NuGet dependency conflicts
- [ ] Lower-tier projects still build (regression check)

### Test Project Execution

| Test Project | Tier Available | Tests For |
|---|---|---|
| ComputerSpeechTests | Tier 2 | ComputerSpeech (Tier 1) |

### Smoke Testing (After Each Tier)

- Build the entire solution (all upgraded + not-yet-upgraded projects)
- Verify no package restore failures
- Verify no assembly binding conflicts

### Full Solution Validation (After Tier 11)

- [ ] Complete solution builds without errors
- [ ] Complete solution builds without warnings
- [ ] All test projects pass
- [ ] Application launches successfully
- [ ] Primary UI workflows function:
  - [ ] Race management (start, pause, stop)
  - [ ] Settings configuration (race settings, options)
  - [ ] Sound playback (NAudio integration)
  - [ ] Speech synthesis (ComputerSpeech integration)
  - [ ] Serial port communication (if hardware available)
  - [ ] Lap counting and statistics
- [ ] No security vulnerabilities remain (verify with `dotnet list package --vulnerable`)
- [ ] Performance is acceptable (no obvious regressions)

---

## 7. Complexity & Effort Assessment

### Per-Tier Complexity

| Tier | Projects | Total Issues | Complexity | Key Challenge |
|---|---|---|---|---|
| 1 | 8 | 364 | **Medium** | BinaryFormatter removal, Speech API, foundational — must be stable |
| 2 | 5 | 834 | **Medium** | Controls (807 issues), GDI+ in Controls |
| 3 | 1 | 384 | **Medium** | Widely consumed (20 dependants), NAudio |
| 4 | 6 | 87 | **Low** | Batch of simple services, serial port APIs |
| 5 | 4 | 373 | **Medium** | Windows Forms View (356 issues) |
| 6 | 2 | 6 | **Low** | Behavioral changes only |
| 7 | 1 | 23 | **Low** | Cross-cutting dependencies but few issues |
| 8 | 1 | 5 | **Low** | Minimal changes |
| 9 | 2 | 2,068 | **High** | Windows Forms Presenter (2,064 issues), legacy controls |
| 10 | 1 | 29,353 | **High** | Largest project, 368 files, heavy WinForms/GDI+ |
| 11 | 1 | 38 | **High** | AutoMapper 3→16 migration, configuration system |

### Incremental Benefits

| After Tier | Benefit |
|---|---|
| Tier 1 | Foundation libraries on .NET 10; BinaryFormatter replaced; Speech migrated |
| Tier 2 | Core controls and helpers upgraded; test project validates Speech |
| Tier 3 | Central Business Objects on .NET 10 — unblocks all downstream |
| Tier 4 | All service-layer projects upgraded |
| Tier 5 | Mid-level services and View layer upgraded |
| Tier 6–8 | Domain, statistics, and control services complete |
| Tier 9 | Presenter and music player upgraded |
| Tier 10 | Main application fully on .NET 10 |
| Tier 11 | Entry point upgraded, security vulnerability resolved, **upgrade complete** |

---

## 8. Source Control Strategy

### Branch Structure

- **Source branch**: `feature/Update_Framework`
- **Upgrade branch**: `upgrade-to-NET10` (current working branch)

### Commit Strategy

- **One commit per tier** — Each tier is a logical checkpoint
- **Commit message format**: `chore: upgrade Tier N (<project list>) to net10.0`
- **Example**: `chore: upgrade Tier 1 (BusinessObjectContracts, ComputerSpeech, Exceptions, FrameworkContracts, HelperClasses, Log, MouseKeyboardLibrary, Serialization) to net10.0`

### Commit Checkpoints

| Checkpoint | Tier | Commit When |
|---|---|---|
| 1 | Tier 1 | All 8 foundation projects build on net10.0 |
| 2 | Tier 2 | All 5 infrastructure projects build; tests pass |
| 3 | Tier 3 | Business Objects builds on net10.0 |
| 4 | Tier 4 | All 6 services build on net10.0 |
| 5 | Tier 5 | All 4 mid-level services build on net10.0 |
| 6 | Tiers 6–8 | Domain, stats, and control services build |
| 7 | Tier 9 | Presenter and MusicPlayer build on net10.0 |
| 8 | Tier 10 | Windows Forms Application builds on net10.0 |
| 9 | Tier 11 | DigiRcMan builds; full solution validated |

### Review & Merge

- Review the completed upgrade on the `upgrade-to-NET10` branch
- Merge to `feature/Update_Framework` via pull request after full validation
- PR checklist: full build passes, tests pass, no vulnerabilities, application runs

---

## 9. Success Criteria

### Technical Criteria
- [ ] All 33 projects target `net10.0` or `net10.0-windows`
- [ ] All 33 projects use SDK-style `.csproj` format
- [ ] All projects build without errors
- [ ] All projects build without new warnings
- [ ] All NuGet packages are compatible with .NET 10
- [ ] No security vulnerabilities remain
- [ ] No `BinaryFormatter` or legacy remoting usage remains
- [ ] AutoMapper updated from 3.0.0 to 16.1.1

### Quality Criteria
- [ ] Test coverage maintained (ComputerSpeechTests pass)
- [ ] UI renders correctly (WinForms controls, GDI+ graphics)
- [ ] Application starts and core workflows function
- [ ] Sound and speech integration operational

### Process Criteria
- [ ] Bottom-up dependency order followed (Tier 1 → Tier 11)
- [ ] Each tier committed as checkpoint
- [ ] No tier started before previous tier validated
- [ ] All changes on `upgrade-to-NET10` branch
