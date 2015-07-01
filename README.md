#Add-ins and Extensibility
1) https://msdn.microsoft.com/en-us/library/bb384200(v=vs.110).aspx

2) http://www.cnblogs.com/zgynhqf/archive/2009/11/21/1607733.html

3) http://www.cnblogs.com/huihui0630/archive/2010/06/30/1768387.html

# MAF
MAF demo, microsoft have more detail demos on codeplex


#Choosing between MEF and MAF (System.AddIn)
http://stackoverflow.com/questions/8891243/using-mef-and-maf-together

Questions:
The Managed Extensibility Framework (MEF) and Managed AddIn Framework (MAF, aka System.AddIn) seem to accomplish very similar tasks. According to this Stack Overflow question, Is MEF a replacement for System.Addin?, you can even use both at the same time.
When would you choose to use one vs. the other? Under what circumstances would you choose to use both together?

Answers:
I've been evaluating these options and here's the conclusion that I came to.

MAF is a true addon framework. You can separate your addons completely, even running them inside a separate app domain so that if an addon crashes, it won't take down your application. It also provides a very complete way of decoupling the addons from depending on anything but the contract you give them. In fact you can versionize your contract adapters to provide backwards compatability to old addons while you are upgrading the main App. While this sounds great, it comes with a heavy price you have to pay in order to cross appdomains. You pay this price in speed and also in the flexibility of the types that you can send back and forth.

MEF is more like dependency injection with some additional benefits such as discoverability and ... (drawing a blank on this one). The degree of isolation that MAF has is not present in MEF. They are two different frameworks for two different things.

Checkout http://kentb.blogspot.com/2009/02/maf-and-mef.html for some more details.
