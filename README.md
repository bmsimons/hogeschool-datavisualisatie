# Data visualization Application

This is the repository for Project 3 of year one at the University Of Applied Sciences. The goal of the project is to create a application which visualizes datasets. 

For this project we chose an interesting and uncommon tech stack. We create the 'back-end' data parser and aggregator in .NET (which was mandatory). As for the 'front-end' application we chose for Electron. The database we use is MongoDB.

## Getting started

### Installing Mongo DB

Navigate to the [MongoDB download center](https://www.mongodb.com/download-center#atlas) and download the installation package for MongoDB community edition.

When the download has completed, run the installer. Follow the wizard: choose 'Custom' as setup type, click next on the feature page, make sure that on the next page you have 'MongoDB compass' checked, click next and install.

Wait for MongoDB and MongoDB Compass to install. It should take no more than 5 minutes.

#### Configuring the MongoDB server
You should at first create a path for MongoDB to store data. Create a folder on your local computer, and remember its location. For this example I'll use D:\mongodbdata

You will have to start MongoDB from your command line prompt. Start up cmd on your computer and run this command:

"C:\Program Files\MongoDB\Server\3.6\bin\mongod.exe" --dbpath="D:\mongodbdata"
Where D:\mongodbdata is your MongoDB data storage path.

#### Check, check, double check
Does MongoDB output the following line in your console window?

```
I NETWORK  [initandlisten] waiting for connections on port 27017
```
If so, you are good to go!
## Project definition

For our project we need to do the following:

- Visualization of data in data sets.
- Parsing data from data sets.
- Storing parsed data in a database.
- Defining correlations between multiple datasets.
- Visualize answers to the questions of our product owner.

## Project Members
- [Bart Simons](https://github.com/bmsimons)
- [Vincent du Mez](https://github.com/vindmc)
- [Tim van Keulen](https://github.com/TimvanKeulen)
- [Jasper Hetterscheid](https://github.com/jasperh97)
- [Maikel Veen](https://github.com/MaikelVeen)
