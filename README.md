# RankSaty - Apartments 🏠

<img src="README/rankstay.png" align="right" height="55px" />

`RankStay` is an app that seeks to be the reliable source of information for university students in search of the most suitable place to live according to their criteria.

In `RankStay` users can rate from 1 to 5 their general experiencie in an apartment and comment, this valuable information aids individuals seeking the optimal accommodation during their college years, helping them make informed decisions.

> Happy staying!

**Technologies used**

<a href="https://dotnet.microsoft.com/en-us/learn/csharp" title="C#"><img src="README/csharp.png" height="55px"/></a>
<a href="https://dotnet.microsoft.com/en-us/" title=".NET"><img src="README/dotnet.png" height="55px"/></a>
<a href="https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16" title="SQL Server Management Studio SSMS"><img src="README/sql.png" height="55px"/></a>
<a href="https://www.postman.com/" title="Postman"><img src="README/postman.png" height="55px"/></a>
<a href="https://git-scm.com/" title="Git"><img src="README/git.png" height="55px"/></a>
<a href="https://getbootstrap.com/" title="Bootstrap"><img src="README/bootstrap.png" height="55px"/></a>
<a href="https://www.w3schools.com/html/" title="HTML"><img src="README/html.png" height="55px"/></a>
<a href="https://www.w3schools.com/css/" title="CSS"><img src="README/css.png" height="55px"/></a>

## Sections

- [Install RankStay locally](#install-rankstay-locally)

## Install RankStay locally

Go to `SQL/RankStay_script.sql` and execute the script in the <a href="https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver16">SQL Server Management Studio SSMS</a>

<img src="README/rankstaydata.png" title="RankStay database" />

Once you have the database locally, go to `RankStay_API/RankStay_API` and make sure your `appsettings.json` file looks like this:

*Note: server={SERVER\\\NAME};*

```js
{
  "ConnectionStrings": {
    "Connection": "server=; database=RankStayData; trusted_connection=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```