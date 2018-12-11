# Automated Build Generation

Automated Build Generation is a feature of Cloud Build for Unity Teams Advanced. It provides continuous integration by automating the publishing of changes and building your Project whenever a team member makes changes to the project. When a team member commits a change, Cloud Build uses the latest code from the shared repository to build your Project.

The goal of Automated Build Generation is to compile your project every time there is a change. This gives you the most accurate idea of when and where errors occur and ensures you always have a build of your game based on the last good commit.

## How Automated Build Generation works

Unity Cloud Build connects to either [Unity Collaborate](UnityCollaborate) or your source control system, and monitors that system for changes to your Project. When it detects changes to your Project, it downloads your project and builds it for all of your target platforms. When the builds finish, Unity Cloud Build emails you the results, along with links to download and install the builds. If there are errors, Unity Cloud Build informs you straight away, allowing you to quickly fix them, commit the changes, and trigger new builds.


-----
<span class="page-edit">2018-04-10  <!-- include IncludeTextAmendPageYesEdit --></span>