# harvestsharp

C# 4 wrapper for the Harvest API

# Why?

I built this so that I could integrate a helpdesk application I use on a daily basis and I was tired of toggleing back and forth between the two when I needed to create a new project in Harvest.

# How?

Compile this class library, drop the dll into your app, and write some code:

	Harvest harvest = new Harvest("username", "password", "subdomain");
	List<HarvestProject> myProjects = harvest.GetProjects();

This will get you a strongly typed list of your harvest projects. 
    
	List<HarvestProject> projects

#What's available?

Projects GET - You can fetch a list of all projects    
Projects POST - You can post new projects given a client id

#What's missing?

Time Tracking    
Clients    
Client Contacts    
Tasks    
People    
Expenses    
Expense Tracking    
User Assignment    
Task Assignment    
Reports    
Invoices    
Invoice Messages    
Invoice Payments    
Invoice Categories    

But this is where you come in ;) - lets build this thing out and make a killer .net API for Harvest.

#Testing

I've added some unit tests; adding more all the time. Code coverage on the Harvest.cs class is 91% but I'd like to get it to 100%. I'm still a unit testing noob.