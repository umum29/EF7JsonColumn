# EF7JsonColumn
Basically, the mainframe of this project is similar with https://github.com/umum29/EntityFrameworkCoreNote

However, in Entity Framework 7, it adds some security for certificate when connecting to Sql Server; 
we need to add "<b>Encrypt=False</b>" in connecction string to lower the default security restriction(for development purpose only).
https://stackoverflow.com/questions/74540508/net-7-a-connection-was-successfully-established-with-the-server-but-then-an-e
https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/breaking-changes#encrypt-true

This project shows how JsonColumn works in SQL SERVER by using "<b>navigationsBuilder.ToJson()</b>" in OnModelCreating method of DataContext class.


