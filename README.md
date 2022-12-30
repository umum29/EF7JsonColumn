# EF7JsonColumn
Basically, the mainframe of this project is similar with https://github.com/umum29/EntityFrameworkCoreNote

However, in Entity Framework 7, it adds some security for certificate when connecting to Sql Server; 
we need to add "<b>Encrypt=False</b>" in connecction string to lower the default security restriction(for development purpose only).

This project shows how JsonColumn works in SQL SERVER by using "<b>navigationsBuilder.ToJson()</b>" in OnModelCreating method of DataContext class.


