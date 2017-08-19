Code First hints:

<b>install EntityFramework</b>
PM: install-package EntityFramework

<b>setup configuration migrations</b>
PM: enable-migrations

<b>create category table also will create product because linked</b>
PM: add-migration CreateCategory

<b>run migration command</b>
PM: update-database

<b>save persist data from Configuration.Seed</b>
PM: update-database