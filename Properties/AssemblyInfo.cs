﻿using MelonLoader;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(RFDemolitionCompanion.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(RFDemolitionCompanion.BuildInfo.Company)]
[assembly: AssemblyProduct(RFDemolitionCompanion.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + RFDemolitionCompanion.BuildInfo.Author)]
[assembly: AssemblyTrademark(RFDemolitionCompanion.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(RFDemolitionCompanion.BuildInfo.Version)]
[assembly: AssemblyFileVersion(RFDemolitionCompanion.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(RFDemolitionCompanion.RFDemolitionCompanion), RFDemolitionCompanion.BuildInfo.Name, RFDemolitionCompanion.BuildInfo.Version, RFDemolitionCompanion.BuildInfo.Author, RFDemolitionCompanion.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]