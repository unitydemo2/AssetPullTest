# UIElements Developer Guide

The Unity editor user interface has been mostly built around the immediate mode UI system. While IMGUI works well in some contexts, it has some serious design limitations that affect the productivity of everyone working on Editor features and extensions.

This was the motivation behind creating UIElements. UIElements is a retained-mode UI system that opens the door to improved performance and provides stylesheets, dynamic/contextual event handling, accessibility and data persistence.

Many concepts in UIElements are based on recognized web technologies. If you are familiar with XML, CSS, JQuery, the HTML DOM, and the DOM event system, then you may already be familiar with many UIElements concepts.

The goal of this guide is to help you take advantage of UIElements by describing the concepts behind the framework and by providing you with a clear explanation of how to build an interactive user interface (UI) with UIElements. 

## Selecting a UI toolkit

Unity provides three user interface (UI) toolkits. You should select a UI toolkit based on your answers to the following questions:

- Are you developing for a game or for the editor?
- If you are developing for a game, will the UI be shipped with the game?

|            | **Runtime dev UI** | **Runtime game UI** |    **Editor**      |
| ---------- | ---------------- | ----------------- | --------------- |
| **IMGUI**      | for debugging  |   not recommmended   |    &#x2714;     |
| **UGUI**       |     &#x2714;     |     &#x2714;      |  not available  |
| **UIElements** |      2019.x      |      2019.1       |      2019.1       |

UIElements is poised to become the toolkit of choice for both in-game and editor UI development.

## Disclaimer

UIElements is an experimental feature: it is incomplete and subject to API breaking changes. UIElements is still in active development.

In addition, changes to UIElements in 2018.3 will not be backported to older versions. If you upgrade, you must also upgrade some elements from previous Unity versions.

---
* <span class="page-edit">2018-11-16  <!-- include IncludeTextAmendPageSomeEdit --></span>

* <span class="page-history">New feature in [2018.3](https://docs.unity3d.com/2018.3/Documentation/Manual/30_search.html?q=newin20183) <span class="search-words">NewIn20183</span></span>
