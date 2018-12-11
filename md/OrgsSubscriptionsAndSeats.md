# Subscriptions and seats

To use the Unity Editor and Services, you must create a Unity Developer Network (UDN) account.

When you create an account, you get:

* A default Organization
    * A Unity Personal Tier subscription (license) in the Organization
        * An Editor seat for the license in the subscription

If you are not eligible to use a Unity Personal tier subscription, you must upgrade to either the Unity Plus or Pro tier. When you subscribe to Plus or Pro, you get:

*  A subscription (license) attached to an Organization of your choice to your account.
    * An Editor seat for the license in the subscription

When you purchase additional Subscriptions, you do so through an Organization. You can purchase additional subscriptions on the[ Unity ID](https://id.unity.com/) dashboard (see [Members and groups](OrgsManagingyourOrganization#membersandgroups)). If you are part of a company, this allows you to organize your licenses under a company Organization while keeping your other activities in Unity separate. For more information, see [Managing your Organization](OrgsManagingyourOrganization).

<a name="subseats"></a>
## Subscription seats

A subscription seat represents a single user license, and allows users to work together on  Projects in the Editor. If your Organization uses a Pro or Plus subscription, all users working on your Organization’s Projects must have an Editor seat at the same tier or higher. If a user has a lower tier subscription, you must assign them a seat from your license.

**Note**: You must be an Owner or Manager in the Organization to assign seats, see [Organization roles](OrgsManagingyourOrganization#orgroles).

To assign seats:

1. Sign in to the[ Unity ID](https://id.unity.com/) dashboard.
2. In the left navigation bar, click __Organizations__.
3. Select the Organization.
4. In the left navigation pane, click __Subscriptions & Services__.
5. Select the subscription from which you are assigning the seat.
6. Click the __Manage seats__ button, then select the Organization member that you want to assign a seat to.
7. Click the __Assign Seat(s)__ button.

The selected member receives an email with information on how to activate Unity.

Assigning a seat gives the user access to Editor features at the Organization’s subscription level. This means the user can have a Personal tier license but use an assigned seat to access a higher tier subscription license.

You can purchase additional seats for your subscription at any time on [Unity’s website](https://unity3d.com/unity). For information on activating Unity, see [Online Activation](OnlineActivationGuide).

<a name="outsideorg"></a>
## Working with individuals outside of your Organization

If you want to collaborate with individuals outside your Organization without giving them access to your Organization’s sensitive information, add the user directly to a specific Project. If the contributor has their own Plus or Pro Editor Seat that matches the Organization’s subscription tier, you do not need to assign them one of yours.

To add a user to a specific Project:

1. Sign in to the [Unity Services Dashboard](https://developer.cloud.unity3d.com).
2. Select the Project that you want to add a user to.
3. In the left navigation column, click __Settings__, then click __Users__.
4. In the __Add a person or group__ field, enter the user’s email address.

To allow users to access the [Collaborate](UnityCollaborate) and [Cloud Build](UnityCloudBuild) features on your Project, you must assign them a [Unity Teams](https://unity3d.com/teams) seat, which is separate from the Editor seats associated with subscriptions. If the specified user does not have a Unity Teams seat, one is assigned by default. If you do not want the user to collaborate with Unity Teams, uncheck the __Also assign a Unity Teams Seat to this user__ checkbox.

For more information on Unity Teams, see [Working with Unity Teams](OrgsWorkingwithUnityTeams).

---
* <span class="page-edit">2018-04-25 <!-- include IncludeTextNewPageYesEdit --></span>