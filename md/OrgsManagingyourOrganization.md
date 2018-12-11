# Managing your Organization

To create or manage Organizations, sign in to the [Unity ID](https://id.unity.com/) dashboard and select __Organizations__ from the left navigation bar.

## Creating Organizations

You can use Organizations to segregate your Projects by the entity for which they are being developed. You can create as many Organizations as you like. To keep your activities for different companies or personal use separate, use a seperate Organization for each entity.

Separating your activities through Organizations also facilitates seamless personnel changes. For example, if an employee leaves the company, you can reallocate their seat because the subscription is tied to the Organization instead of the user.

To create a new Organization:

1. Sign in to the[ Unity ID](https://id.unity.com/) dashboard.
2. In the left navigation bar, click __Organizations__.
3. In the __Organizations__ pane, click the __Add new__ button.
4. In the __Organization Name__ text field, enter the name of your Organization, and then click the __Create__ button.

The following sections describe the information and tasks available for your Organizations from the Unity ID dashboard.

<a name="membersandgroups"></a>
## Members & Groups

With an Organization selected, click __Members & Groups__ from the left navigation bar to view or add members and groups within that Organization, or assign user roles.

### Adding users

To work with other users, you must give them access to your Project(s). To do this, either:

* Add the user to your Organization. This allows the user to view all of the Projects within the Organization. If the user needs to modify information about your subscription, you can assign them an Owner or Manager role.

Or:

* Add the user directly to an individual Project. This gives the user access to one Project, with no access to Organization and subscription information.

Adding a user to an Organization or a Project allows them to view information about a Project. For example, they can view Project Analytics and the results of Performance Reporting.

For the user to work on Projects, as opposed to just viewing information, they must have a seat tier that matches the Organization’s subscription tier. If they do not have one of their own, you must assign them one.  For more information, see [Subscription Seats](#subs).

<a name="orgroles"></a>
### Organization roles

You can assign different administrative roles to members of your Organization. Each role grants access to certain functions within the Organization.

To assign a team member to a role:

1. Sign in to the[ Unity ID](https://id.unity.com/) dashboard.
2. Click __Organizations__ on the left navigation bar.The __Organizations__ page contains a list of the Organization names associated to your account.
3. Click the cog icon next to the name of the Organization.
4. Click __Members & Groups__ in the left navigation bar. This page contains all members associated with the Organization.
5. Find the name of the member whose role you want to change, and then click the pencil icon.
6. Choose the member's role from the drop-down menu titled __Organization Role__. Once you've selected the new role, click __Save__.

**Note**: Organization Managers can also assign member roles. However, they can only assign the role of User or Guest.

* __Owners__ can access all settings in any of their Organizations' subscriptions, across all Projects. Owners are the only users with access to payment instruments, invoices and billing data for the Organization.
* __Managers__ can access most settings in any of their Organizations' subscriptions, across all Projects. Managers can add users, access monetization data, and do almost everything an Owner can do. However, they cannot see billing and credit card information for the Organization.
* __Users__ can read and view all Organization and Services data, except Monetization data. They cannot edit Organization and Services data.
* __Guests__ are members of your Organization that have no permissions to view data within the Organization. The Guest role allows you to assign vendors and contractors a Teams Advanced seat in the Organization that allows them to use  the Collaboration service. Guests only have permission to access the specific project to which they are assigned.

All Organization members can access all of the Organization's Projects.

To assign a member a different role for a specific Project:

1. Sign in to the [Unity Services Dashboard](https://developer.cloud.unity3d.com).
2. Select the relevant Project.
3. In the left navigation column, click __Settings__, then click __Users__.
4. Click the __Add a person or group__ field.
5. Select a Organization user from the displayed list or enter the email address of a user who has not been added to the Organisation.

If the specified user does not have a Unity Teams seat, Unity assigns them a seat automatically. If you do not want the user to collaborate on the Project using Unity Teams, uncheck the __Also assign a Unity Teams Seat to this user__ checkbox. For more information on Unity Teams, see [Working with Unity Teams](OrgsWorkingwithUnityTeams).

For information on allowing Organization members to work a Project, see [Adding team members to your Unity Project](UnityCollaborateAddingTeammates).

**Note**: Because Services are enabled on a per Project basis, and each Project is tied to an Organization, only that Organization's Owner can enable and disable Services for its associated Projects. Regardless of your subscription tier or seat, you need certain roles or permissions within an Organization to use Services features or view related data on the Unity Services Dashboard.

<a name="subs"></a>
## Subscriptions & Services

With an Organization selected, click __Subscriptions & Services__ from the left navigation bar to manage your Editor and Unity Teams subscriptions.

To view the status of a subscription, select the subscription you wish to view from the list. The subscription details page allows you to add and assign seats for that Subscription. It also allows you to extend or upgrade your subscriptions.

## Service Usage

With an Organization selected, click __Service Usage__ from the left navigation bar to view your Unity Teams cloud storage allocation and usage.

Unity Teams includes some cloud storage, which you can adjust on a month-to-month basis. Click __Manage storage__ to add or subtract space. For more information on managing storage, see [How Do I Get More Cloud Storage](https://support.unity3d.com/hc/en-us/articles/115005492443-How-do-I-get-more-cloud-storage-) In the knowledge base.

## Edit Organization

With an Organization selected, click __Edit Organization__ from the left navigation bar to change the Organization’s name and contact information. Only the Owner can change these settings.

## Payment Methods

With an Organization selected, click __Payment Methods__ from the left navigation bar to manage the credit cards that Unity stores for the Organization. Valid payment methods are required to purchase subscriptions or cloud storage.

## Transaction History and Payouts

With an Organization selected, click __Transaction History__ from the left navigation bar to view records of your purchases and payouts. Select a date range to query, then click __Apply__ to view records for that period.

The __Purchases__ tab reports purchases you’ve made during the specified period. The __Payouts__ tab reports payments you received from Unity for ads revenue. To receive payouts, you must set up a payment profile by clicking __Payment Profile__ in the left navigation bar. For more information on Unity Ads revenue, see [Revenue and payment](https://unityads.unity3d.com/help/monetization/Revenue-and-payment).

---
* <span class="page-edit">2018-04-25 <!-- include IncludeTextNewPageYesEdit --></span>
