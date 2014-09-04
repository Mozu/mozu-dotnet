Mozu-NET-SDK
============

<B>Mozu - .NET Sample Application</b>
<br>
The .NET application is a simple Windows Form example that demonstrates how to authenticate and how to retrieve orders and products from a Mozu developmet store.  Follow these steps to get the application up & running:
<br>

In Mozu Development Center:<br>
<ul>
<li>Login to the development center.</li>
<li>Create a development store.</li>
<li>Documentation on creating a store: http://developer.mozu.com/article/getting-started-development-stores.</li>
<li>Populate the store with some initial products and orders.</li>
<li>Create an application of type Extension: Documentation on creating an app: http://developer.mozu.com/article/getting-started-applications.</li>
<li>The sample app requires the Behaviors of “Order Read” and “Product Read”.</li>
<li>Install the application into your Mozu development store.</li>
</ul>
<br>
In Microsoft Visual Studio<br>

<ul>
<li>Open Mozu.Api.sln file.</li>
<li>Build and Run the Sample app solution.</li>
<li>On the sample app UI (shown below), select the “Sandbox” environment.</li>
<li>Enter the application ID and Shared Secret (from Dev Center).</li>
<li>After authentication, you’ll be able to launch UI’s for retrieving products and orders.</li>
</ul>
