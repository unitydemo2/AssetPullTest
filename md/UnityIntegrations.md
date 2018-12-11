# Unity Integrations

Unity Integrations allow you to connect the following Unity Services in your development workflow to non-Unity tools:

* [Cloud Build](UnityCloudBuild)
* [Cloud Diagnostics](https://unitytech.github.io/clouddiagnostics/)
* [Collaborate](UnityCollaborate)

To add an integration, you must be an Owner or Manager on the Project. For information on assigning roles, see the Members & Groups section of [Managing your Organization](OrgsManagingyourOrganization).

Unity Integrations supports the following non-Unity tools:

* [Webhooks](#webhooks): A user-defined callback that allows Unity to send POST requests to an external service.
* [Discord](#discord): Send notifications to your team’s Discord channel through a Discord-defined webhook.
* [Slack](#slack): Send notifications to your team’s Slack channel through a Slack-defined webhook.
* [JIRA](#jira): Create or update JIRA tickets using a JIRA-defined webhook.

## Number of integrations

Unity Personal limits users to one integration for all events, but multiple Unity services can use that integration. [Unity Teams](https://unity3d.com/teams), [Plus](https://store.unity.com/products/unity-plus), and [Pro](https://store.unity.com/products/unity-pro) users can have up to 100 integrations. If your Unity Teams, Pro, or Plus subscription expires, Unity keeps all of your current integrations, but automatically disables them. If this happens, you can still sign into the Unity Services Dashboard and enable a single integration.

## Adding an integration

To add an integration to your workflow:

1. Sign in to the [Unity Services Dashboard](https://developer.cloud.unity3d.com/).
2. Select the Project that you want to add an integration to.
3. In the left navigation bar, click __Settings__, then click __Integrations__.
4. Click the __NEW INTEGRATION__ button.
5. In the __New Integration__ dialog box:
    1.  Select the program to integrate with, then click the __NEXT__ button to configure the integration.
    2.  Select the events that trigger the action the integration takes, then click the __NEXT__ button.

If you select a webhook or JIRA integration, the __Configure options__ step opens. Otherwise, the configurations screen for the selected tool opens.

<a name="webhooks"></a>
## Webhook integrations

To configure a webhook integration, you must supply the following information:

| Parameter| Description |
|:---|:---| 
| Display Name| A name to identify the integration in the integrations list. |
| Webhook URL| The URL of the server endpoint that receives the webhook POST requests from the Unity service. |
| Authentication Secret| The client secret of your receiving application. |
| Content Type| The MIME type of the content. Select the content type of your data from the drop-down menu. |
| Disable SSL/TLS Verification| Tick this checkbox to disable verification of SSL/TLS security certificates. <br/> Verifying SSL/TLS certificates helps ensure that your data is sent securely to the above Webhook URL. Turning this option on is not recommended, so only do this if you absolutely know what you're doing. |

<a name="discord"></a>
## Discord integrations

To configure Discord integrations, Unity calls an app that uses the Discord API to register a webhook to a Discord channel. If you do not have a Discord server, see [How do I create a server?](https://support.discordapp.com/hc/en-us/articles/204849977-How-do-I-create-a-server-) in the Discord documentation. 

**Important**: You must enable webhooks on the account with which you are integrating.

To complete the configuration:

1. Sign in to your Discord account.
2. From the __Select a server__ drop-down menu, select your Discord server.
3. From the __Select a channel__ menu, select a channel to post notifications to.
4. Click the __Authorize__ button.

<a name="slack"></a>
## Slack integrations

To configure Slack integrations, Unity calls an app that uses the Slack API to register a webhook to a Slack channel. If you do not have a Slack server, see [Create a Slack workspace](https://get.slack.help/hc/en-us/articles/206845317-Create-a-Slack-workspace) in the Slack documentation.

To complete the configuration:

1. Sign in to your Slack account.
2. In the right-hand corner of the of the app, select a Slack workspace.
3. From the __Post to__ drop-down menu, select the Slack channel to post notifications to.
4. Click the __Authorize__ button.

<a name="jira"></a>
## JIRA integration

The Unity JIRA integration allows you to interact with JIRA as follows:

* Cloud Diagnostics: Create a new issue when you receive a report. Unity creates the issue with one of the following labels: unity-user-report, unity-crash-report, or unity-exception-report. You must have permission to create an issue and modify the label column for these integrations to work.
* Collaborate: Add a comment to an existing issue when you publish a change in Collaborate.

To configure a JIRA integration for Collaborate or Cloud Diagnostics, you must supply the following information:

| Parameter| Description |
|:---|:---| 
| Display Name| A name to identify the integration in the integrations list. |
| JIRA Site URL| The URL of your JIRA instance. |
| JIRA Username| The user ID of an account that can post updates to your JIRA instance. |
| JIRA REST API Token| The API token to authenticate Integration requests to your JIRA server. For instructions on how to create a token, see [Atlassian’s documentation](https://confluence.atlassian.com/cloud/api-tokens-938839638.html). |

After you have entered the information for your JIRA instance, you must supply the following additional information for Cloud Diagnostics:

| Parameter| Description |
|:---|:---| 
| Create Issues In This Project| Select the project in which to create the issues. |
| Mark Incoming Issues As| Select the type of issue to log the report as. |

When you make changes in Collaborate, update JIRA-associated issues by referencing the issue key in your commit message. For example, "I fixed the crashes caused by ISS–42" adds publish details to issue "ISS–42".

## Editing an integration

To edit an existing integration:

1. Sign in to the [Unity Services Dashboard](https://developer.cloud.unity3d.com/).
2. Select the Project that you want to edit an integration for.
3. In the left navigation column, click __Settings__, then click __Integrations__.
4. Click __EDIT__ next to the integration to modify.

The types of edits you can make depend on the integration. For Slack and Discord integrations, you can update the display name or delete the integration.

For webhook and JIRA integrations, you can modify any of the configuration parameters that you supplied when you created them.

##  Enabling or disabling an integration

To enable or disable an integration from the dashboard.

1. Sign in to the [Unity Services Dashboard](https://developer.cloud.unity3d.com/).
2. Select the Project that you want to edit an integration for.
3. In the left navigation column, click __Settings__, then click __Integrations__.
4. Click the toggle in the __Status__ column to quickly enable or disable an integration.

