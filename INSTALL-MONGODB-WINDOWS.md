# How to install MongoDB on Windows

Navigate to the [MongoDB download center](https://www.mongodb.com/download-center#community) and download the installation package for MongoDB community edition.

When the download has completed, run the installer. Follow the wizard: choose 'Custom' as setup type, click next on the feature page, make sure that on the next page you have 'MongoDB compass' checked, click next and install.

Wait for MongoDB and MongoDB Compass to install. It should take no more than 5 minutes.


## Configuring the MongoDB server

You should at first create a path for MongoDB to store data. Create a folder on your local computer, and remember its location.
For this example I'll use D:\mongodbdata

You will have to start MongoDB from your command line prompt. Start up cmd on your computer and run this command:

```
"C:\Program Files\MongoDB\Server\3.6\bin\mongod.exe" --dbpath="D:\mongodbdata"
```

Where D:\mongodbdata is your MongoDB data storage path.


## Check, check, double check

Does MongoDB output the following line in your console window?

```
I NETWORK  [initandlisten] waiting for connections on port 27017
```

If so, you are good to go!