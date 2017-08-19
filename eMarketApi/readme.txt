Code First hint:

//install EntityFramework
PM: install-package EntityFramework

//setup configuration migrations
PM: enable-migrations

//create category table also will create product because linked
PM: add-migration CreateCategory

//run migration command
PM: update-database